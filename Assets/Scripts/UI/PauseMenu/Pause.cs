using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    // UI 
    public GameObject PauseMenu;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab) && PauseMenu.active == false) // Gameplay is paused
        {
            PauseMenu.SetActive(true);
            Time.timeScale = 0;
            Debug.Log("Paused");
        }
        else if (Input.GetKeyDown(KeyCode.Tab) && PauseMenu.active == true) // Gameplay is unpaused ()
        {
            PauseMenu.SetActive(false);
            Time.timeScale = 1;
            Debug.Log("Unpaused");
        }
    }

}
