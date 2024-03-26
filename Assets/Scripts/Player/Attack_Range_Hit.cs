using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack_Ranged_Hit : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // If the bullet collides with an Enemy, That Enemy takes damage;
        if (collision.gameObject.TryGetComponent<Enemy>(out Enemy enemy)) enemy.TakeDamage(1); 
        else if (collision.gameObject.TryGetComponent<BossUIBar>(out BossUIBar bossuibar)) bossuibar.TakeDamage(1);
        else if (collision.gameObject.TryGetComponent<Boss_Generator>(out Boss_Generator genrator)) genrator.TakeDamage(1);

        Destroy(gameObject);
    }
}
