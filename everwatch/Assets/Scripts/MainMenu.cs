using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame ()
    {
        SceneManager.LoadScene("BackupMap");
    }

    public void Settings ()
    {
        SceneManager.LoadScene("Settings");
    }

    public void MenuScene()
    {
        SceneManager.LoadScene("MenuScene");
    }

    public void HowToPlay ()
    {
        SceneManager.LoadScene("HowToPlay");
    }

    public void QuitGame ()
    {
        Application.Quit();
        Debug.Log("QUIT!");
    }

    public void Restart ()
    {
        SceneManager.LoadScene("MenuScene");
    }
}
