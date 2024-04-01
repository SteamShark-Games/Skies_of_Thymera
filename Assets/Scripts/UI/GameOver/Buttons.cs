using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverButtons : MonoBehaviour
{
    public void GetUp()
    {
        // Load the last scene before GameOver using the SceneNameKeeper
        string lastSceneName = SceneNameKeeper.Instance.GetLastSceneName();
        if (!string.IsNullOrEmpty(lastSceneName))
        {
            SceneManager.LoadScene(lastSceneName);
        }
        else
        {
            Debug.LogWarning("Last scene name is not available. Loading default scene.");
            SceneManager.LoadScene("Main Menu"); // Load default scene if last scene name is not available
        }
    }

    public void GiveUp()
    {
        // Load the Main Menu scene
        SceneManager.LoadScene("Main Menu");
    }
}

