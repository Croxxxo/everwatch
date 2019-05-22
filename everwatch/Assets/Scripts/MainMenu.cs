﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame ()
    {
        SceneManager.LoadScene("TestScene");
    }

    public void Settings ()
    {
        SceneManager.LoadScene("Settings");
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
}
