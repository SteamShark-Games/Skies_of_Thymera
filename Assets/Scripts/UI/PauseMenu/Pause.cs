using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public GameObject player;
    public GameObject pauseMenuUI;
    bool GameIsPaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetButtonDown("JoystickPause")) // Gameplay is paused
        {
            if (GameIsPaused)
            {
                ResumeButton();
            }
            else
            {
                PauseGame();
            }
        }

        // Joystick substitute for RestartButton
        if (GameIsPaused == true && Input.GetButtonDown("JoystickRanged"))
        {
            RestartButton();
        }

        // Joystick substitute for QuitButton
        if (GameIsPaused == true && Input.GetButtonDown("JoystickCancel"))
        {
            QuitButton();
        }

    }

    void PauseGame()
    {
        pauseMenuUI.SetActive(true);
        player.GetComponent<Player>().enabled = false;
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void ResumeButton() // Gameplay is resumed
    {
        pauseMenuUI.SetActive(false);
        player.GetComponent<Player>().enabled = true;
        Time.timeScale = 1;
        GameIsPaused = false;
        Debug.Log("Unpaused");
    }

    public void RestartButton()
    {
        //string currentScene = SceneManager.GetActiveScene().name;
        Time.timeScale = 1;
        Debug.Log("Restarted");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitButton() //Back to the Main Menu
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Main Menu");
    }
}
