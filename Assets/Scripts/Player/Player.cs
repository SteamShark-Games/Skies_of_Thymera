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


    float light_gravityScale = 5f;
    float fallgravityScale = 10f;

    [SerializeField] private AudioSource jumpsfx;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        Jump();
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
            rb.velocity = new Vector2(0.0f , rb.velocity.y);
            
        }


        if (Input.GetKeyDown(KeyCode.Space) && totalJumps < 2)
        {
            Jump();

        }

        // IF the player 
        if (rb.velocity.y < 0)
        {
            rb.gravityScale = fallgravityScale;
        }
        else
        {
            rb.gravityScale = light_gravityScale;
        }

        // Updating Animator per frame
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

    void Jump()
    {
        totalJumps++;

        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        jumpForce = Mathf.Sqrt(jumpHeight * (Physics2D.gravity.y * rb.gravityScale) * -2) * rb.mass;
        jumping = true;
        jumpsfx.Play();
    }

}

     
