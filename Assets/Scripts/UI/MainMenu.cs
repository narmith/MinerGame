﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public bool GodMode = false;

    public void Start()
    {
        Cursor.lockState = CursorLockMode.None;
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Nivel1");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadLevel(string menu)
    {
        SceneManager.LoadScene(menu);
    }

    public void GodModeOption()
    {
        if (!GodMode) //enables the option
        {
            GodMode = true;
            StaticGlobals.GodMode = true;
            Debug.Log("GodMode: " + StaticGlobals.GodMode);
        }
        else if (GodMode) //disables the option
        {
            GodMode = false;
            StaticGlobals.GodMode = false;
            Debug.Log("GodMode: " + StaticGlobals.GodMode);
        }
    }

}
