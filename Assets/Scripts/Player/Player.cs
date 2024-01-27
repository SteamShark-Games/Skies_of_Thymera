using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Animator anim;
    Rigidbody2D rb;
    private enum MovementState { idle, running, jumping, falling, attack }




    public float speed = 10f;
    bool facingRight;

    float jumpForce;
    public float jumpHeight = 15;
    public float totalJumps;
    bool jumping;


    float gravityScale = 5f;
    float fallgravityScale = 10f;

    [SerializeField] private AudioSource jumpsfx;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Animation states?
        MovementState state;

        // Basic Movement Logic 
        if (Input.GetKey(KeyCode.D))
        {
            // Sets X velocity to speed
            rb.velocity = new Vector2(speed, rb.velocity.y);
            if (facingRight)
            {
                Turn();
            }
            state = MovementState.running;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            // Sets X velocity to -speed
            rb.velocity = new Vector2(-speed, rb.velocity.y);
            state = MovementState.running;
            if (!facingRight)
            {
                Turn();
            }
        }
        else
        {
            state = MovementState.idle;
        }
        if (Input.GetKeyDown(KeyCode.Space) && totalJumps < 2)
        {
            totalJumps++;
            rb.gravityScale = gravityScale;
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            jumpForce = Mathf.Sqrt(jumpHeight * (Physics2D.gravity.y * rb.gravityScale) * -2) * rb.mass;
            jumping = true;
            jumpsfx.Play();

        }

        // If the player is moving downwards
        if (rb.velocity.y < 0)
        {
            rb.gravityScale = gravityScale;
        }
        else
        {
            rb.gravityScale = fallgravityScale;
        }
           anim.SetInteger("state", (int)state);
    }

    void Turn()
    {
        //stores scale and flips the player along the x axis, 
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
        facingRight = !facingRight;
    }
}

     
