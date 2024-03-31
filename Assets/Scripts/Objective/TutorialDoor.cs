using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialDoor : MonoBehaviour
{
    void Update()
    {
        // Find all GameObjects with the "Generator" tag
        GameObject[] tutorialGen = GameObject.FindGameObjectsWithTag("TutorialGenerator");

        // If no generators are found, destroy this GameObject
        if (tutorialGen.Length == 0)
        {

            Destroy(gameObject);
        }
    }
}
