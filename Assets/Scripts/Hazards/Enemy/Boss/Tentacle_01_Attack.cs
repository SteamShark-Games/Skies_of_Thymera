using UnityEngine;

public class Tentacle_01_Attack : MonoBehaviour
{
    public float activationDelay = 1.5f;
    private float elapsedTime = 0f;
    private bool colliderActivated = false;

    void Update()
    {
        // Increment elapsed time
        elapsedTime += Time.deltaTime;

        // Check if the delay has passed and the collider hasn't been activated yet
        if (elapsedTime >= activationDelay && !colliderActivated)
        {
            GetComponent<BoxCollider2D>().enabled = true;
            GetComponent<SpriteRenderer>().color = Color.white;
            colliderActivated = true; // Set the flag to indicate collider is activated 
        }
    }
}

