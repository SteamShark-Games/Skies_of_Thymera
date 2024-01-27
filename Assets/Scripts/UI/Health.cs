using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    // UI assets
    public GameObject HealthBar;
    public GameObject HP1;
    public GameObject HP2;
    public GameObject HP3;
    public GameObject HP4;
    public GameObject HP5;

    // Floats
    public float CurrentHealth = 5.0f;
    float CapHealth = 5.0f;

    float Damaged = 1.0f;
    float Heal = 1.0f;
    // --------------------

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // Temp Spacebar, will be changed to collision with attacks 
        {
            CurrentHealth -= Damaged;
        }
        else if (Input.GetKeyDown(KeyCode.Q)) // Temp Q, will be changed to collison with health items
        {
            CurrentHealth += Heal;
        }
        // can be changed to add different health/damage values of course


        if (CurrentHealth == 5.0f)
        {
            HP5.SetActive(true);
        }
        else if (CurrentHealth == 4.0f)
        {
            HP4.SetActive(true);
            HP5.SetActive(false);
        }
        else if (CurrentHealth == 3.0f)
        {
            HP3.SetActive(true);
            HP4.SetActive(false);
        }
        else if (CurrentHealth == 2.0f)
        {
            HP2.SetActive(true);
            HP3.SetActive(false);
        }
        else if (CurrentHealth == 1.0f)
        {
            HP1.SetActive(true);
            HP2.SetActive(false);
        }
        //if (CurrentHealth == 0.0f)
        //{
            //HP1.SetActive(false);
            //SceneManager.LoadScene("GameOver");
        //}
        // trigger end screen 'gameover' :)
    }
}
