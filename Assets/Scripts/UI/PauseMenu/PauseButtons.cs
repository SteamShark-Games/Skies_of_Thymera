using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseButtons : MonoBehaviour
{
    // UI 
    public GameObject PauseMenu;

    public void ResumeButton() // Gameplay is resumed
    {
        PauseMenu.SetActive(false);
        Time.timeScale = 1;
        Debug.Log("Unpaused");
    }

    public void RestartButton()
    {
        SceneManager.LoadScene("TestingGrounds");
        Time.timeScale = 1;
        Debug.Log("Restarted");
    }

    public void QuitButton() //Back to the Main Menu
    {
        SceneManager.LoadScene("Main Menu");
        Time.timeScale = 1;
        Debug.Log("Quit");
    }
}
