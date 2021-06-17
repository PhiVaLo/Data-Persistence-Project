using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int highscore_score;
    public string highscore_name = "";

    string FILE_NAME = "/savefile.json";

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadScore();
    }

    // ================================================================================================
    // Save (Serializable -> Deserializable)
    // ================================================================================================

    [System.Serializable]
    class SaveData
    {
        public int highscore_score;
        public string highscore_name;

        public string nameInput;
    }

    public void SaveScore()
    {
        SaveData data = new SaveData();
        data.highscore_score = highscore_score;
        data.highscore_name = highscore_name;
        data.nameInput = Menu.nameInput;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + FILE_NAME, json);
    }

    public void LoadScore()
    {
        string path = Application.persistentDataPath + FILE_NAME;
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);

            SaveData data = JsonUtility.FromJson<SaveData>(json);

            highscore_score = data.highscore_score;
            highscore_name = data.highscore_name;
            Menu.nameInput = data.nameInput;
        }
    }











}
