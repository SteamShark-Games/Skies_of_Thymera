using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject optionMenu;

    public void PlayButton()
    {
        SceneManager.LoadScene("TestingGrounds");
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
