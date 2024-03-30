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
    SpriteRenderer spriteRenderer;

    public void Start()
    {
        health = maxHealth;
        spriteRenderer = GetComponent<SpriteRenderer>();
        startColor = spriteRenderer.color;
        currentColor = startColor;
    }

    private void Update()
    {
        if (shieldOn)
        {
            currentColor = Color.blue;
        }
        else if (!shieldOn && health == maxHealth)
        {
            currentColor = startColor;
        }
        spriteRenderer.color = currentColor;
    }

    public void TakeDamage(float damageAmount)
    {
        if (!shieldOn)
        {
            health -= damageAmount;
            currentColor = Color.red;
            spriteRenderer.color = currentColor;
            if (health <= 0)
            {
                gameObject.SetActive(false);
            }
        }
    }
}

