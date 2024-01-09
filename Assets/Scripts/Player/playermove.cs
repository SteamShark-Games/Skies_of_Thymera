using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playermove : MonoBehaviour
{
    private float horizontal;
    private float speed = 10f;
    private float jumpingPower = 25f;
    private bool isFacingRight = true;
    private Animator anim;
    public AudioClip coinSound;
    public bool isGrounded;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;


    private enum MovementState { idle, running, jumping, falling, attack }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        anim = GetComponent<Animator>();

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)

        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }


        Flip();
        UpdateAnimationState();

    }

    private void UpdateAnimationState()
    {
        MovementState state;

        if (horizontal > 0f)
        {
            state = MovementState.running;
        }
        else if (horizontal < 0f)
        {
            state = MovementState.running;
        }
        else
        {
            state = MovementState.idle;
        }

        if (rb.velocity.y > 1.5f)
        {
            state = MovementState.jumping;
        }
        else if (rb.velocity.y < -1.5f)
        {
            state = MovementState.falling;
        }

        anim.SetInteger("state", (int)state);
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        isGrounded = IsGrounded();
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.3f, groundLayer);
    }
    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            AudioSource.PlayClipAtPoint(coinSound, transform.position);
        }

        if (other.gameObject.CompareTag("Fall"))
        {
            SceneManager.LoadScene("GameOver");

        }
    }
}