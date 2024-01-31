using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class TimeCount : MonoBehaviour
{
    // Variables
    public float CurrentTime = 200;
    public bool TimerRunning = false;

    public static float LocalTimeScale = 1;
    public static float deltaTime;

    // UI Assets
    public GameObject Timer;
    public TMP_Text CurrentTimeDisplay;
    public float startTime = 120f;

    private void Start()
    {
        TimerRunning = true;
    }

    public void Update()
    {
        int min = Mathf.FloorToInt(startTime / 60);
        int sec = Mathf.FloorToInt(startTime % 60);
        if (startTime > 0)
        {
            startTime -= Time.deltaTime;
        }
        else if (startTime <= 0)
        {
            startTime = 0;
            SceneManager.LoadScene("GameOver");
        }
        CurrentTimeDisplay.text = string.Format("{0:00}:{1:00}", min, sec);
    }
}
