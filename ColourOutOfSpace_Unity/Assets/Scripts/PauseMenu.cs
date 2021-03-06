﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenuUI; 

    [SerializeField] private bool isPaused;

    public AudioMixer audioMixer;


    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
        }

        if (isPaused)
        {
            ActiveMenu();
        }
        else
        {
            DeactivateMenu();
        }
        //if (Input.GetKeyDown(KeyCode.Delete))
        //{
        //    SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
        //    Cursor.visible = true;
        //    Cursor.lockState = CursorLockMode.None;
        //}
    }

    void ActiveMenu()
    {
        //AudioListener.pause = true;
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void DeactivateMenu()
    {
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        //AudioListener.pause = false;
        pauseMenuUI.SetActive(false);
        isPaused = false;
    }
    public void ToMainMenu()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }
    public void QuitGame()
    {
        Application.Quit();
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
        //audioMixer.SetFloat("volume", Mathf.Log10(volume) * 20);
    }

    public void SetFullScreen (bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
}
