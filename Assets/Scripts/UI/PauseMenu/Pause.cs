using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    // UI 
    public GameObject PauseMenu;
    public GameObject player;

    public static float LocalTimeScale = 1f;
    public static float deltaTime;

    private void Start()
    {
         player.GetComponent<Player>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab) && gameObject == false) // Gameplay is paused
        {
            PauseMenu.SetActive(true);
            player.GetComponent<Player>().enabled = false;
            Time.timeScale = 0f;
            Debug.Log("Paused");
        }
        else if (Input.GetKeyDown(KeyCode.Tab) && gameObject == true) // Gameplay is unpaused ()
        {
            ResumeButton();
        }
    }

    public void ResumeButton() // Gameplay is resumed
    {
        player.GetComponent<Player>().enabled = true;
        PauseMenu.SetActive(false);
        Time.timeScale = 1;
        Debug.Log("Unpaused");
    }

    public void RestartButton()
    {
        string currentScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene("currentScene");
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
