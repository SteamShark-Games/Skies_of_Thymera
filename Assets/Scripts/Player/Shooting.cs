using UnityEngine;

public class Shooting: MonoBehaviour


    // Attach to player for the script
    // Connect to Prefab Object acting as the projectile (ShootingItem)
    // Connect Shooting Point to know location of the spawning projectile
{
    public float speed;
    public float damageValue;
    private void Update()
    {
        transform.Translate(transform.right * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            return;

        //Trigger the custom action on the other object IF IT EXISTS
       if (collision.GetComponent<ShootingAction>())
           collision.GetComponent<ShootingAction>().Action();
        //Destroy
        Destroy(gameObject);

    }























}
