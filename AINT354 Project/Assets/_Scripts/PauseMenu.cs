using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool isPaused = false;

    public GameObject pauseMenuUI, mainMenuUI, optionsMenuUI, controlsUI;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        isPaused = true;
        Time.timeScale = 0.0f;
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        isPaused = false;
        Time.timeScale = 1f;
    }

    public void QuitButton()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void ResetButton()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("EndlessWasteland");
    }

    public void OptionsButton()
    {
        Debug.Log("Bleh");
        optionsMenuUI.SetActive(true);
        mainMenuUI.SetActive(false);
    }

    public void ControlsButton()
    {
        mainMenuUI.SetActive(false);
        controlsUI.SetActive(true);
    }

    public void ExitButton()
    {
        Application.Quit();
    }

    public void mute()
    {
        AudioListener.volume = 1 - AudioListener.volume;
    }

    public void ReturnButton()
    {
        optionsMenuUI.SetActive(false); 
        controlsUI.SetActive(false);
        mainMenuUI.SetActive(true);
    }

}
