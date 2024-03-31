using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform[] points; // List of points the platform moves between
    public float speed = 2f; // Speed of the platform

    private int currentIndex = 0;
    private bool moving = false;

    private void FixedUpdate()
    {
        if (moving)
        {
            MovePlatform();
        }
    }

    private void MovePlatform()
    {
        Vector2 targetPosition = points[currentIndex].position;
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.fixedDeltaTime);

        if (Vector2.Distance(transform.position, targetPosition) < 0.01f)
        {
            // If the platform has reached the target position, switch to the next point
            currentIndex = (currentIndex + 1) % points.Length;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(this.transform);
            moving = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(null);
            moving = false;
        }
    }

    // Method to draw Gizmos to visualize the path
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;

        if (points.Length > 0)
        {
            for (int i = 0; i < points.Length; i++)
            {
                if (i < points.Length - 1)
                {
                    Gizmos.DrawLine(points[i].position, points[i + 1].position);
                }
            }
        }
    }
}





