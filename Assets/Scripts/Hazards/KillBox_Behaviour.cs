using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillBox_Behaviour : MonoBehaviour
{
    public Transform respawn;
    public void OnCollisionEnter2D(Collision2D collision)
    {
        // If the bullet collides with an Enemy, That Enemy takes damage;
        if (collision.gameObject.CompareTag("Player"))
        {
           collision.transform.position = respawn.position;
        }
    }
}
