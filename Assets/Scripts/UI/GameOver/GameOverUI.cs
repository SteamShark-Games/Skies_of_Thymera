using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    public void GetUpButton() // Respawn in the Testing Grounds
    {
        SceneManager.LoadScene("TestingGrounds");
    }

    public void GiveUpButton() // Head back to the Main Menu
    {
        SceneManager.LoadScene("Main Menu");
    }
}