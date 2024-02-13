using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack_Ranged_Hit : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // If the bullet collides with an Enemy, That Enemy takes damage;
        if (collision.gameObject.TryGetComponent<Enemy>(out Enemy enemy))
        {
            // bullet deals one damage to an Enemy
            enemy.TakeDamage(1);
        }

        else if (collision.gameObject.TryGetComponent<BossUIBar>(out BossUIBar bossuibar))
        {
            // bullet deals one damage to boss (Updates BossUIBar)
            bossuibar.TakeDamage(1);
        }
        Destroy(gameObject);
    }


}
