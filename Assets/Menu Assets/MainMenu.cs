using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
        Debug.Log("Ba�latt�m");
    }
    public void QuitGame()
    {
        Debug.Log("oyundan ciktik");
        Application.Quit();

    }
    public void ReturnMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
