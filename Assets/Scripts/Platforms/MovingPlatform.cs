using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    // Reference to waypoints
    public List<Transform> points;
    int nextID = 0;
    int idChangeValue = 1;
    public float speed = 2;
    public bool isStandingOnit;

    private void Reset()
    {
        Init();
    }

    void Init()
    {
        // Make Capsule collider trigger
        GetComponent<CapsuleCollider2D>().isTrigger = true;
        // Create Root object
        GameObject root = new GameObject(name + "_Root");
        // Reset Position of Root to enemy object
        root.transform.position = transform.position;
        // Set enemy object as child of root
        transform.SetParent(root.transform);
        // Create Waypoints object
        GameObject waypoints = new GameObject("Waypoints");
        // Reset waypoints position to root        
        waypoints.transform.SetParent(root.transform);
        // Make waypoints object child of root
        waypoints.transform.position = root.transform.position;
        // Create two points (gameobject) and reset their position to waypoints objects
        // Make the points children of waypoint object
        GameObject top = new GameObject("Point1"); top.transform.SetParent(waypoints.transform); top.transform.position = root.transform.position;
        GameObject bottom = new GameObject("Point2"); bottom.transform.SetParent(waypoints.transform); bottom.transform.position = root.transform.position;
        // Init points list then add the points to it
        points = new List<Transform>
        {
            top.transform,
            bottom.transform
        };
    }

    private void Update()
    {
        // Get the next Point transform
        Transform goalPoint = points[nextID];
        if (isStandingOnit)
        {
            transform.position = Vector2.MoveTowards(transform.position, goalPoint.position, speed * Time.deltaTime);
            if (Vector2.Distance(transform.position, goalPoint.position) < 0.2f)
            {
                // Check if we are at the end of the line (make the change -1)
                if (nextID == points.Count - 1) idChangeValue = -1;
                // Check if we are at the start of the line (make the change +1)
                if (nextID == 0) idChangeValue = 1;
                // Apply the change on the nextID
                nextID += idChangeValue;
            }
        }
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("GroundCheck"))
        {
            isStandingOnit = true;
        }
        else
        {
            isStandingOnit = false;
        }
    }
}
