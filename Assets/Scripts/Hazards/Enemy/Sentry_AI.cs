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

    // Update is called once per frame
    void Update()
    {
        pps += Time.deltaTime;

        if (playerInRange && pps > 2)
        {
            pps = 0;
            fire();
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
}
