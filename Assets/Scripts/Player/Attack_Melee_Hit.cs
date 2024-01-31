using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack_Melee_Hit : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // If the bullet collides with an Enemy, That Enemy takes damage;
        if (collision.gameObject.TryGetComponent<Enemy>(out Enemy enemy))
        {
            // bullet deals three damage to an Enemy
            enemy.TakeDamage(3);
        }
        Destroy(gameObject);
    }
}
