using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteelDoor : MonoBehaviour
{
    public GameObject[] generators;

    void Update()
    {
        bool generatorsFound = false;

        foreach (GameObject generator in generators)
        {
            if (generator != null)
            {
                generatorsFound = true;
                break;
            }
        }

        // If no generators are found, destroy this GameObject
        if (!generatorsFound)
        {
            Destroy(gameObject);
        }
    }
}
