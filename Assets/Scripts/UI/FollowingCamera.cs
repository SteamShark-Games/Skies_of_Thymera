using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingCamera : MonoBehaviour
{
    Vector3 offset = new Vector3 (0, 3, -5f);
    float smoothFollowing = 0.25f;
    Vector3 vel = Vector3.zero;

    public Transform player;

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPosition = player.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, playerPosition, ref vel, smoothFollowing);
    }
}
