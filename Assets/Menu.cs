using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class Menu : MonoBehaviour
{
    public static string inputName;
    public GameObject popUp;

    // ================================================================================================
    // Input Name
    // ================================================================================================

    public void ReadInput(string s)
    {
        inputName = s;
        Debug.Log(inputName);
    }

    // ================================================================================================
    // Sart Game
    // ================================================================================================

    public void StartGame()
    {
        if (inputName != null)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        else
            StartCoroutine(PopUpWindow());

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
    // -
    // ================================================================================================

    IEnumerator PopUpWindow()
    {
        popUp.SetActive(true);
        yield return new WaitForSeconds(2f);
        popUp.SetActive(false);
    }

}
