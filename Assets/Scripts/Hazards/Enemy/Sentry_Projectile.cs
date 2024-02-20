using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sentry_Projectile : MonoBehaviour
{
    Player player;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // If the projectile collides with the player
        if (collision.gameObject.CompareTag("Player"))
        {
            //Projectile deals one damage to the player
            Destroy(gameObject);
            player.TakingDamage();
        }
        Destroy(gameObject);
    }
}
