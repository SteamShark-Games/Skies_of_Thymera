using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject optionMenu;
    public GameObject creditsMenu;
    public bool optionsOpen = false;

    public void Start()
    {
        Time.timeScale = 1.0f;
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

    public void CreditsButton()
    {
        mainMenu.SetActive(false);
        creditsMenu.SetActive(true);
    }

    public void CloseOptionsButton()
    {
        mainMenu.SetActive(true);
        optionMenu.SetActive(false);
    }

    public void CloseCreditsButton()
    {
        mainMenu.SetActive(true);
        creditsMenu.SetActive(false);
    }


    public void QuitButton()
    {
        // Funny Quit :)
        // Application.Quit(); ------ Deactive for LevelUp
        Debug.Log("Get out loser");
    }
}
