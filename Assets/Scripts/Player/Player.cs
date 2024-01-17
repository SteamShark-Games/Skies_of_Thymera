using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Animator anim;
    private enum MovementState { idle, running, jumping, falling, attack }



    Rigidbody2D rb;

    float speed = 10f;
    float jumpForce = 20f;


    float gravityScale = 5f;
    float fallgravityScale = 10f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Gravity();
    }

    // Basic Movement Logic 
    void Movement()
    {
        // Animation states?
        MovementState state;
        
        //Vector3 direction = Vector3.zero;
        if (Input.GetKey(KeyCode.D))
        {
            // Sets X velocity to speed
            rb.velocity = new Vector2 (speed, rb.velocity.y);
            state = MovementState.running;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            // Sets X velocity to -speed
            rb.velocity = new Vector2(-speed, rb.velocity.y);
            state = MovementState.running;
        }
        else
        {
            state = MovementState.idle;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    void Gravity()
    {
        // If the player is moving downwards
        if (rb.velocity.y > 0)
        {
            rb.gravityScale = gravityScale;
        }
        else 
        {
            rb.gravityScale = fallgravityScale;
        }
    }
}
