using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class Menu : MonoBehaviour
{
    public GameObject popUp;
    public GameObject highscore;
    public GameObject inputField;
    public static string nameInput = "";

    void Start()
    {
        DisplayHighscore();
        PlayerName();
    }

    // ================================================================================================
    // Highscore
    // ================================================================================================

    public void DisplayHighscore()
    {
        if (GameManager.Instance.highscore_name != "")
        {
            highscore.GetComponent<TextMeshProUGUI>().text = "Best Score: " + GameManager.Instance.highscore_name + ": " + GameManager.Instance.highscore_score;
        }
    }
    // ================================================================================================
    // Input Name
    // ================================================================================================

    void PlayerName()
    {
        if (GameManager.Instance.highscore_name != "")
        {
            inputField.GetComponent<TMP_InputField>().text = nameInput;
        }

    }

    public void ReadInput(string s)
    {
        // GameManager.Instance.inputName = s;
        nameInput = s;
    }

    // ================================================================================================
    // Sart Game
    // ================================================================================================

    public void StartGame()
    {
        if (nameInput != "")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            StartCoroutine(PopUpWindow());
        }

    }

    // ================================================================================================
    // Quit Game
    // ================================================================================================

    public void QuitGame()
    {


#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    // ================================================================================================
    // Pop Up Window on invalid input
    // ================================================================================================

    IEnumerator PopUpWindow()
    {
        popUp.SetActive(true);
        yield return new WaitForSeconds(2f);
        popUp.SetActive(false);
    }


    // // ================================================================================================
    // // Save/Load Color on Click
    // // ================================================================================================

    // public void SaveColorClicked()
    // {
    //     GameManager.Instance.SaveScore();
    // }

    // public void LoadColorClicked()
    // {
    //     GameManager.Instance.LoadScore();
    // }
}
