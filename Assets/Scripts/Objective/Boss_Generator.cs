using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Generator : MonoBehaviour
{
    public float health;
    public float maxHealth;
    Color currentColor;
    Color startColor;
    public bool shieldOn;

    public void Start()
    {
        health = maxHealth;
        startColor = GetComponent<SpriteRenderer>().color;
    }

    private void Update()
    {
        if (shieldOn) currentColor = Color.blue;
        else currentColor = startColor;
    }

    public void TakeDamage(float damageAmount)
    {
        if (!shieldOn)
        {
            health -= damageAmount;
            currentColor = Color.red;
            if (health <= 0)
            {
                gameObject.SetActive(false);
            }
        }
    }

}
