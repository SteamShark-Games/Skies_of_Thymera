using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack_Square
{
    public Vector3 position;
    public Vector3 extents;
}

public class Boss_Attack_01 : MonoBehaviour
{
    public enum BossState
    {
        Idle,
        Attacking
    }

    Attack_Square squ = new Attack_Square();
    LineRenderer lineRenderer;
    public GameObject bossAttackPrefab; // Assign the boss attack prefab in the Inspector
    public GameObject player; // Assign the player GameObject in the Inspector
    private float timer = 0f;
    public float interval;
    private bool playerInRange = false;

    void Start()
    {
        lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.positionCount = 2;
        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInRange)
        {
            squ.position = transform.position;
            squ.extents = new Vector3(transform.localScale.x * 0.5f, 0, 0); // Only considering x scale for horizontal line
            DrawHorizontalLine(squ.position, squ.extents);

            // Timer for instantiation
            timer += Time.deltaTime;
            if (timer >= interval)
            {
                BossAttack_01();
                timer = 0f;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }

    void DrawHorizontalLine(Vector3 position, Vector3 extents)
    {
        lineRenderer.SetPosition(0, position - extents);
        lineRenderer.SetPosition(1, position + extents);
    }

    

    Vector3 GetClosestPointOnLine(Vector3 playerPosition)
    {
        Vector3 lineStart = squ.position - squ.extents;
        Vector3 lineEnd = squ.position + squ.extents;
        Vector3 closestPoint = Vector3.zero;

        Vector3 lineDirection = lineEnd - lineStart;
        float lineLength = lineDirection.magnitude;
        lineDirection.Normalize();

        Vector3 pointToPlayer = playerPosition - lineStart;
        float dotProduct = Vector3.Dot(pointToPlayer, lineDirection);

        if (dotProduct <= 0)
        {
            closestPoint = lineStart;
        }
        else if (dotProduct >= lineLength)
        {
            closestPoint = lineEnd;
        }
        else
        {
            closestPoint = lineStart + lineDirection * dotProduct;
        }

        return closestPoint;
    }

    void BossAttack_01()
    {
        if (player != null)
        {
            Vector3 closestPoint = GetClosestPointOnLine(player.transform.position);
            GameObject Tentacle = Instantiate(bossAttackPrefab, closestPoint, Quaternion.identity);
            Destroy(Tentacle, 3f);
        }
    }
}



