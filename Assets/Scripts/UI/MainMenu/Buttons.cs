using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject optionMenu;
    public bool optionsOpen = false;

    public void Start()
    {
        Time.timeScale = 1.0f;
    }

    void Update()
    {
        // Joystick substitute for PlayButton
        if (Input.GetButtonDown("JoystickConfirm"))
        {
            if (optionsOpen == false)
            {
                SceneManager.LoadScene("Level 1");
            }
        }

        // Joystick substitute for OptionsButton
        if (Input.GetButtonDown("JoystickPause"))
        {
            OptionsButton();
            optionsOpen = true;

        }

        // Joystick substitute for CloseButton
        if (optionsOpen == true && Input.GetButtonDown("JoystickCancel"))
        {
            CloseButton();
            optionsOpen = false;
        }
    }

    public void PlayButton()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void OptionsButton()
    {
        mainMenu.SetActive(false);
        optionMenu.SetActive(true);
    }

    public void CloseButton()
    {
        mainMenu.SetActive(true);
        optionMenu.SetActive(false);
    }


    public void QuitButton()
    {
        // Funny Quit :)
        Application.Quit();
        Debug.Log("Get out loser");
    }
}
