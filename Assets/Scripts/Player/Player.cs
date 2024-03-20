using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // References
    Rigidbody2D rb;
    Animator anim;
    enum MovementState { idle, running, jumping, falling, melee, shoot }
    public GameObject BulletPrefab;
    public GameObject MeleePrefab;
    public Health HealthBar;

    // Player Variables
    public float speed = 8f;
    //Vector2 move;
    bool facingLeft;
    bool doubleJump;
    public float jumpHeight = 20f;
    public bool isGrounded;
    float projectileSpeed = 15f;

    // Wall Silde
    bool isWallSliding;
    float wallSlideSpeed;
    public GameObject wallCheck;
    public LayerMask walllayer;

    // Gravity Scales
    float light_gravityScale = 5f;
    float fallgravityScale = 10f;

    [SerializeField] private AudioSource jumpSoundEffect;
    [SerializeField] private AudioSource shootSoundEffect;
    [SerializeField] private AudioSource meleeSoundEffect;
    [SerializeField] private AudioSource damagedSoundEffect;
    // Start is called before the first frame update
    private void Awake()
    {
        Time.timeScale = 1f;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    /* For Later testing
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(move.x * speed * Time.deltaTime, rb.velocity.y);
    }*/

    // Update is called once per frame
    void Update()
    {
        anim = GetComponent<Animator>();
        //move = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        MovementState state;

        // ---- Joystick Movement ----
        float horiz = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(horiz * speed, rb.velocity.y);

        // ---- Movement ------ 
        if (Input.GetKey(KeyCode.D))
        {
            if (!facingLeft && isKissingWall())
            {
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y);
            }
            else
            {
                // Sets X velocity to speed
                rb.velocity = new Vector2(speed, rb.velocity.y);
            }
            state = MovementState.running;
            if (facingLeft)
            {
                Turn();
            }
        }
        else if (Input.GetKey(KeyCode.A))
        {
            if (facingLeft && isKissingWall())
            {
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y);
            }
            else
            {
                // Sets X velocity to -speed
                rb.velocity = new Vector2(-speed, rb.velocity.y);
            }
            state = MovementState.running;
            if (!facingLeft)
            {
                Turn();
            }
        }
        else
        {
            state = MovementState.idle;
            rb.velocity = new Vector2(0.0f, rb.velocity.y); // Note: Need to rework this so that the conveyor belt works better 
        }

        // ------ Jumping --------
        // The longer you hold down space, the higher you go
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("JoystickJump"))
        {
            if (isGrounded || doubleJump)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
                jumpSoundEffect.Play();
                isGrounded = false;
                doubleJump = !doubleJump;
            }
        }
        if (Input.GetKeyUp(KeyCode.Space) && rb.velocity.y > 0f) rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);

        // ------- Attacks --------

        if (Input.GetMouseButtonDown(0) || Input.GetButtonDown("JoystickRanged"))
        {
            // If the player is facing left, shoot left
            shootSoundEffect.Play();
            if (facingLeft)
            {
                Shoot(-transform.right, projectileSpeed);
            }
            // else shoot right
            else
            {
                Shoot(transform.right, projectileSpeed);
            }
            state = MovementState.shoot;
        }

        if (Input.GetMouseButtonDown(1) || Input.GetButtonDown("JoystickMelee"))
        {
            // If the player is facing left, Swing left
            meleeSoundEffect.Play();
            if (facingLeft)
            {
                Melee(-transform.right);
            }
            // else swing right
            else
            {
                Melee(transform.right);
            }
             state = MovementState.melee;
        }

        // ---- Gravity --------
        if (rb.velocity.y < 0 && !isGrounded)
        {
            state = MovementState.falling;
            rb.gravityScale = fallgravityScale;
        }
        else
        {
            rb.gravityScale = light_gravityScale;
          
        }
        if (rb.velocity.y > 1.5f)
        {
            state = MovementState.jumping;
        }

        // Updating Animator per frame
        anim.SetInteger("state", (int)state);
        WallSlide();
    }

    void Turn()
    {
        //stores scale and flips the player along the x axis, 
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
        facingLeft = !facingLeft;
    }

    public GameObject Shoot(Vector3 direction, float speed)
    {
        GameObject projectile = Instantiate(BulletPrefab);
        projectile.transform.position = new Vector3(transform.position.x, transform.position.y + .5f, transform.position.z) + direction;
        projectile.GetComponent<Rigidbody2D>().velocity = direction * speed;
        Destroy(projectile, 1.0f);
        return projectile;
    }

    public GameObject Melee(Vector3 direction)
    {
        GameObject hitscan = Instantiate(MeleePrefab);
        hitscan.transform.position = new Vector3(transform.position.x, transform.position.y + .7f, transform.position.z) + direction;;
        Destroy(hitscan, 0.3f);
        return hitscan;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground") || collision.CompareTag("ElevatorPlatform"))
        {
            doubleJump = false;
            isGrounded = true;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // If the bullet collides with an Enemy, That Enemy takes damage;
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("KillBox") || collision.gameObject.CompareTag("Boss"))
        {
            //Deals one damage to the player
            TakingDamage();
        }
    }

    bool isKissingWall()
    {
        return Physics2D.OverlapCircle(wallCheck.transform.position, 0.2f, walllayer);
    }
    void WallSlide()
    {
        if (isKissingWall() && !isGrounded)
        {
            isWallSliding = true;
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Clamp(rb.velocity.y, -wallSlideSpeed, float.MaxValue));
        }
        else isWallSliding = false;
    }

    public void TakingDamage()
    {
        HealthBar.PlayerDamaged(1);
        damagedSoundEffect.Play();
    }
}