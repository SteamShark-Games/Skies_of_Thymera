using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    // Reference to waypoints
    public List<Transform> points;
    // The int value for the next point index
    int nextID = 0;
    // The value that applies to ID for changing
    int idChangeValue = 1;
    // Speed of movement or flying
    public float speed = 2;

    // Initial scale of the game object
    private Vector3 initialScale;

    private void Start()
    {
        // Store the initial scale of the game object
        initialScale = transform.localScale;
    }

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
        GameObject p1 = new GameObject("Point1"); p1.transform.SetParent(waypoints.transform); p1.transform.position = root.transform.position;
        GameObject p2 = new GameObject("Point2"); p2.transform.SetParent(waypoints.transform); p2.transform.position = root.transform.position;
        // Init points list then add the points to it
        points = new List<Transform>
        {
            p1.transform,
            p2.transform
        };
    }

    private void Update()
    {
        // Get the next Point transform
        Transform goalPoint = points[nextID];
        // Flip the enemy transform to look into the point's direction
        if (goalPoint.transform.position.x > transform.position.x) transform.localScale = new Vector3(-initialScale.x, initialScale.y, initialScale.z);
        else transform.localScale = initialScale;
        // Move the enemy towards the goal point
        transform.position = Vector2.MoveTowards(transform.position, goalPoint.position, speed * Time.deltaTime);
        // Check the distance between enemy and goal point to trigger the next point
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

