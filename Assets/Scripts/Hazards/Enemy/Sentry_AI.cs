using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class Sentry_AI : MonoBehaviour
{
    public GameObject projectile;
    public Transform firePoint;
    public Transform target;

    float projectileSpeed = 5;
    float pps; // Projectile per Second
    bool playerInRange;
    bool facingLeft;

    // Update is called once per frame
    void Update()
    {
        pps += Time.deltaTime;

        if (playerInRange && pps > 2)
        {
            pps = 0;
            fire();
        }

        // Check if target is to the left and not facing left, or to the right and facing left
        if ((target.position.x < transform.position.x && facingLeft) ||
            (target.position.x > transform.position.x && !facingLeft))
        {
            Turn();
        }
    }

    private void fire()
    {
        Vector3 toTarget = target.position - transform.position;
        Vector3 direction = toTarget.normalized;
        GameObject bulletClone = Instantiate(projectile, firePoint.position, Quaternion.identity);
        bulletClone.GetComponent<Rigidbody2D>().velocity = direction * projectileSpeed;
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

    void Turn()
    {
        //stores scale and flips the player along the x axis, 
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
        facingLeft = !facingLeft;
    }
}



