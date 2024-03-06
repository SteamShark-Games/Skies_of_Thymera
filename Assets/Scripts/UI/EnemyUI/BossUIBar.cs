using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossUIBar : MonoBehaviour
{
    // UI assets
    public GameObject bossHPBar;
    public List<GameObject> BossHealth;

    // Floats
    float health;
    float maxHealth = 8.0f;


    public void Start()
    {
        health = maxHealth;
    }


    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;

        if (health == 8.0f)
        {
            Debug.Log("Boss Engaged!");
            //Debug.Log("Current Health: 8");
        }
        else if (health == 7.0f)
        {
            BossHealth[7].SetActive(false);
            //Debug.Log("Current Health: 7");
        }
        else if (health == 6.0f)
        {
            BossHealth[6].SetActive(false);
            //Debug.Log("Current Health: 6");

        }
        else if (health == 5.0f)
        {
            BossHealth[5].SetActive(false);
            //Debug.Log("Current Health: 5");
        }
        else if (health == 4.0f)
        {
            BossHealth[4].SetActive(false);
            //Debug.Log("Current Health: 4");
        }
        else if (health == 3.0f)
        {
            BossHealth[3].SetActive(false);
            //Debug.Log("Current Health: 3");
        }
        else if (health == 2.0f)
        {
            BossHealth[2].SetActive(false);
            //Debug.Log("Current Health: 2");

        }
        else if (health == 1.0f)
        {
            BossHealth[1].SetActive(false);
            //Debug.Log("Current Health: 1");
        }
        
        if (health <= 0.0f)
        {
            BossHealth[0].SetActive(false);
            bossHPBar.SetActive(false);
            Destroy(gameObject);
            Debug.Log("Boss Defeated!");
        }
    }


    // will be making things such as 'boss name' and activating once it is in range of a boss
    //gonna do those once i return in a few hours, posting it though just to let you guys see it! (apologies for the wait!)

}
