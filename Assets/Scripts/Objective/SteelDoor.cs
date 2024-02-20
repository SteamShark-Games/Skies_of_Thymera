using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteelDoor : MonoBehaviour
{
    void Update()
    {
        // Find all GameObjects with the "Generator" tag
        GameObject[] generators = GameObject.FindGameObjectsWithTag("Generator");

        // If no generators are found, destroy this GameObject
        if (generators.Length == 0)
        {
         
            Destroy(gameObject);
        }
    }
}
