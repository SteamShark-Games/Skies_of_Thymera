using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBelt : MonoBehaviour
{
    public float speed;
    public bool clockwise;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Vector2 pos = rb.position;
        if (clockwise) rb.position += Vector2.left * speed * Time.deltaTime;
        else rb.position += Vector2.right * speed * Time.fixedDeltaTime;
        rb.MovePosition(pos);
    }

}
