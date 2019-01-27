using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        Debug.Log("Ładowanie Sceny");
        SceneManager.LoadScene("FinalScene");
    }

    public void ExitGame()
    {
        Debug.Log("Wyłączenie aplikacji");
        Application.Quit();
    }

    public void RunCredits()
    {
        Debug.Log("Włączenie credits'ów");
        SceneManager.LoadScene("CreditScene");
    }

    public void RunReadme()
    {
        Debug.Log("Włączenie readme");
        SceneManager.LoadScene("ReadmeScene");
    }

}
