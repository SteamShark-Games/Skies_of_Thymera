using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Generator : MonoBehaviour
{
    float health;
    public float maxHealth;
    Color currentColor;
    float timeWhenHit;
    public bool hit;

    public void Start()
    {
        health = maxHealth;
        currentColor = GetComponent<SpriteRenderer>().color;
    }

    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

}
