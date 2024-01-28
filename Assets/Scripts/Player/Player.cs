using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // References
    Rigidbody2D rb;
    Animator anim;
    enum MovementState { idle, running, jumping, falling, attack }
    public AudioSource jumpsfx;
    public GameObject BulletPrefab;
    public GameObject MeleePrefab;

    // Player Variables
    public float speed = 8f;
    float projectileSpeed = 15f;
    public float jumpHeight = 4f;
    public float totalJumps;
    float jumpForce;
    bool facingLeft;

    // Gravity Scales
    float light_gravityScale = 5f;
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
        MovementState state;

        // Basic Movement Logic 
        if (Input.GetKey(KeyCode.D))
        {
            // Sets X velocity to speed
            rb.velocity = new Vector2(speed, rb.velocity.y);
            state = MovementState.running;
            if (facingLeft)
            {
                Turn();
            }
        }
        else if (Input.GetKey(KeyCode.A))
        {
            // Sets X velocity to -speed
            rb.velocity = new Vector2(-speed, rb.velocity.y);
            state = MovementState.running;
            if (!facingLeft)
            {
                Turn();
            }
        }
        else
        {
            state = MovementState.idle;
            rb.velocity = new Vector2(0.0f , rb.velocity.y); 
        }

        if (Input.GetMouseButtonDown(0))
        {
            // If the player is facing left, shoot left
            if (facingLeft)
            {
                Shoot(-transform.right, projectileSpeed); 
            }
            // else shoot right
            else
            {
                Shoot(transform.right, projectileSpeed);
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            // If the player is facing left, Swing left
            if (facingLeft)
            {
                Melee(-transform.right);
            }
            // else swing right
            else
            {
                Melee(transform.right);
            }
        }

        if (Input.GetKeyDown(KeyCode.Space) && totalJumps < 2)
        {
            Jump();
        }

        // IF the player the player is at the arc of the jump, incease gravity
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
        facingLeft = !facingLeft;
    }

    void Jump()
    {
        totalJumps++;
        jumpForce = Mathf.Sqrt(jumpHeight * (Physics2D.gravity.y * rb.gravityScale) * -2) * rb.mass;
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        jumpsfx.Play();
    }

    public GameObject Shoot(Vector3 direction, float speed)
    {
        GameObject projectile = Instantiate(BulletPrefab);
        projectile.transform.position = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z) + direction;
        projectile.GetComponent<Rigidbody2D>().velocity = direction * speed;
        Destroy(projectile, 2.0f);
        return projectile;
    }

    public GameObject Melee(Vector3 direction)
    {
        GameObject hitscan = Instantiate(MeleePrefab);
        hitscan.transform.position = new Vector3(transform.position.x, transform.position.y + 1.2f, transform.position.z) + direction;;
        Destroy(hitscan, 0.1f);
        return hitscan;
    }
}

     
