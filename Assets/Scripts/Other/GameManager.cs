using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private int totalCoins = 0;
    private float totalTime = 0f;
    public float finalscore = 0f;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        // Check if the current scene is the MainMenu scene
        if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            // Clear variables
            totalCoins = 0;
            totalTime = 0f;
        }
    }

    public void AddCoins(int coins)
    {
        totalCoins += coins;
    }

    public void AddTime(float time)
    {
        totalTime += time;
    }

    public void CalculateFinalScore()
    {
        finalscore = totalCoins + totalTime;
    }
}

