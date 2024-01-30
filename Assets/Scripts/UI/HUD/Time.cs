using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Time : MonoBehaviour
    // getting errors atm, going to push this and restart unity+vis - daytona

{
    // Variables
    public float CurrentTime = 200f;
    public bool TimerRunning = false;

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
            }
            else
            {
                Debug.Log("Time has run out!");
                CurrentTime = 0;
                TimerRunning = false;
            }
        }
    }
}
