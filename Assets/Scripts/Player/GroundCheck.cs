using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public Player player;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
           player.totalJumps = 0;
        }
        if (collision.gameObject.CompareTag("ElevatorPlatform"))
        {
           player.totalJumps = 0;
        }
    }
}
