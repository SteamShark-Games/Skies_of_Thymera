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


    // Note: I'll add later
    // Wall Silde
    //float clampedFall = 10f;
    //bool isWallSliding;
    //float wallSlideSpeed;
    public GameObject wallCheck;
    public LayerMask walllayer;

    public Material defaultMaterial; // Assuming the player's material is changeable
    public float flashDuration = 1f; // Duration of the flash in seconds

    // Gravity Scales
    float light_gravityScale = 5f;
    float fallgravityScale = 10f;

    AudioManager audioManager;

    // Start is called before the first frame update
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        Time.timeScale = 1f;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        anim = GetComponent<Animator>();
        MovementState state;

        // ---- Joystick Movement ----
        float horiz = Input.GetAxis("Horizontal");
        

        // ---- Movement ------ 
        if (Input.GetKey(KeyCode.D) || horiz == 1.00)
        {
            state = MovementState.running;
            if (!facingLeft && isKissingWall()) rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y);
            else if (!facingLeft) rb.velocity = new Vector2(speed, rb.velocity.y);
            if (facingLeft) Turn();
            
        }
        else if (Input.GetKey(KeyCode.A) || horiz == -1.00)
        {
            state = MovementState.running;
            if (facingLeft && isKissingWall()) rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y);
            else if (facingLeft) rb.velocity = new Vector2(-speed, rb.velocity.y);
            if (!facingLeft) Turn();
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
            audioManager.PlaySFX(audioManager.jump);
            if (isGrounded || doubleJump)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
                
                isGrounded = false;
                doubleJump = !doubleJump;
            }
        }
        if ((Input.GetKeyUp(KeyCode.Space) || Input.GetButtonUp("JoystickJump")) && rb.velocity.y > 0f) rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);

        // ------- Attacks --------
        if (Input.GetMouseButtonDown(0) || Input.GetButtonDown("JoystickRanged"))

        {
            // If the player is facing left, shoot left
            audioManager.PlaySFX(audioManager.shoot);
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
            audioManager.PlaySFX(audioManager.melee);
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
        //WallSlide();
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
    // Note: No time to make it useful
    bool isKissingWall()
    {
        return Physics2D.OverlapCircle(wallCheck.transform.position, 0.2f, walllayer);
    }

    private bool canTakeDamage = true;

    public void TakingDamage()
    {
        if (canTakeDamage)
        {
            HealthBar.PlayerDamaged(1);
            audioManager.PlaySFX(audioManager.hurt);
            StartCoroutine(WaitForDamageCooldown());
        }
    }

    IEnumerator WaitForDamageCooldown()
    {
        canTakeDamage = false;
        yield return new WaitForSeconds(1f); // Wait for one second
        canTakeDamage = true;
    }
}
