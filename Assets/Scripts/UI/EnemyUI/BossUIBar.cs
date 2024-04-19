using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BossUIBar : MonoBehaviour
{
    // UI assets
    public GameObject bossHPBar;
    public List<GameObject> BossHealth;

    // Floats
    public float health;
    float maxHealth = 8.0f;
    public bool ShieldOn;

    Battery_Logic battery;
    public GameController gameController;

    public void Start()
    {
        health = maxHealth;
        ShieldOn = true;
    }

    public void Update()
    {
        GameObject[] batteries = GameObject.FindGameObjectsWithTag("Battery");
        if (batteries.Length == 0) 
        {
            ShieldOn = false;
        }
    }


    public void TakeDamage(float damageAmount)
    {
        if (!ShieldOn)
        {
            health -= damageAmount;

            if (health == 7.0f)
            {
                BossHealth[7].SetActive(false);
            }
            else if (health == 6.0f)
            {
                BossHealth[6].SetActive(false);

            }
            else if (health == 5.0f)
            {
                BossHealth[5].SetActive(false);
            }
            else if (health == 4.0f)
            {
                BossHealth[4].SetActive(false);
                ShieldOn = !ShieldOn;
                Battery_Logic.instance.ResetBatteries();
                // Half Health
            }
            else if (health == 3.0f)
            {
                BossHealth[3].SetActive(false);
            }
            else if (health == 2.0f)
            {
                BossHealth[2].SetActive(false);
            }
            else if (health == 1.0f)
            {
                BossHealth[1].SetActive(false);
            }
            
            if (health == 0.0f)
            {
                gameController.LevelComplete();
                BossHealth[0].SetActive(false);
                bossHPBar.SetActive(false);
                gameObject.SetActive(false);
            }
        }
    }
}
