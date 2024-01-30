using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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

    private void Start()
    {
        TimerRunning = true;
    }
    void Update()
    {
        if (TimerRunning)
        {
            if (CurrentTime > 0)
            {
                CurrentTime -= Time.deltaTime;
                CurrentTimeDisplay.SetText(CurrentTime.ToString());
            }
            else
            {
                Debug.Log("Time has run out!");
                CurrentTime = 0;
                TimerRunning = false;
            }
        }


        void CurrentTime(float CurrentTime)
        {
            CurrentTime += 1;
            float min = Mathf.FloorToInt(CurrentTime / 60);
            float sec = Mathf.FloorToInt(CurrentTime % 60);
            CurrentTimeDisplay.text = string.Format("{0:00}:{1:00}", min, sec);
        }
    }
}