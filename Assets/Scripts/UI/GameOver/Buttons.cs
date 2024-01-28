using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverButtons : MonoBehaviour
{
    public void GetUp()
    {
        SceneManager.LoadScene("TestingGrounds");
    }

    public void GiveUp()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
