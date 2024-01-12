using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Animator anim;
    public float speed = 10.0f;
    Rigidbody2D rb;

    private enum MovementState { idle, running, jumping, falling, attack }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        MovementState state;

        // Basic Movement Logic 
        Vector3 direction = Vector3.zero;

        // D to move Pos in the X axis
        if (Input.GetKey(KeyCode.D))
        {
            direction += transform.right;
            state = MovementState.running;
        }
        // A to move Neg in the X axis
        else if (Input.GetKey(KeyCode.A))
        {
            direction += -transform.right;
            state = MovementState.running;
        }
        else
        {
            state = MovementState.idle;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            direction += transform.forward;
        }
        rb.velocity = direction.normalized * speed;
    }
}
