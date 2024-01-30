using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public GameObject player;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab) && gameObject == false) // Gameplay is paused
        {
            gameObject.SetActive(true);
            player.GetComponent<Player>().enabled = false;
            Time.timeScale = 0;
            Debug.Log("Paused");
        }
        else if (Input.GetKeyDown(KeyCode.Tab) && gameObject == true) // Gameplay is unpaused ()
        {
            ResumeButton();
        }
    }

    public void ResumeButton() // Gameplay is resumed
    {
        gameObject.SetActive(false);
        player.GetComponent<Player>().enabled = false;
        Time.timeScale = 1;
        Debug.Log("Unpaused");
    }

    public void RestartButton()
    {
        string currentScene = SceneManager.GetActiveScene().name;
        Time.timeScale = 1;
        Debug.Log("Restarted");
        SceneManager.LoadScene("currentScene");
    }

    public void QuitButton() //Back to the Main Menu
    {
        Time.timeScale = 1;
        Debug.Log("Quit");
        SceneManager.LoadScene("MainMenu");
    }
}
