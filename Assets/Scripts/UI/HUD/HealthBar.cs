using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
   
    // UI assets
    public GameObject HealthBar;
    public List<GameObject> health;

    // Floats
    float CurrentHealth = 5.0f;

    void Update()
    {
        if (CurrentHealth == 5.0f)
        {
            health[4].SetActive(true);
        }
        else if (CurrentHealth == 4.0f)
        {
            health[3].SetActive(true);
            health[4].SetActive(false);
        }
        else if (CurrentHealth == 3.0f)
        {
            health[2].SetActive(true);
            health[3].SetActive(false);
        }
        else if (CurrentHealth == 2.0f)
        {
            health[1].SetActive(true);
            health[2].SetActive(false);
        }
        else if (CurrentHealth == 1.0f)
        {
            health[0].SetActive(true);
            health[1].SetActive(false);
        }
        // 
        if (CurrentHealth == 0.0f)
        {
            health[0].SetActive(false);
            SceneManager.LoadScene("GameOver");
        }
    }

    public void PlayerDamaged(float amount)
    {
        CurrentHealth -= amount;
    }

    public void PlayerHeal(float amount)
    {
        CurrentHealth += amount;
    }
}
