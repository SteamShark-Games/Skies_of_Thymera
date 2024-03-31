using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack_Melee_Hit : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Enemy>(out Enemy enemy)) enemy.TakeDamage(3);
        else if (collision.gameObject.TryGetComponent<BossUIBar>(out BossUIBar bossuibar)) bossuibar.TakeDamage(1);
        else if (collision.gameObject.TryGetComponent<Boss_Generator>(out Boss_Generator genrator)) genrator.TakeDamage(3f);
        Destroy(gameObject);
    }
}
