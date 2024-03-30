using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Shield : MonoBehaviour
{
    public Boss_Generator Boss_Generator;

    void Update()
    {
        // Find all GameObjects with the "Generator" tag
        GameObject[] generators = GameObject.FindGameObjectsWithTag("Vents");

        // If no generators are found, destroy this GameObject
        if (generators.Length == 0)
        {
            Boss_Generator.shieldOn = false;
        }
    }
}
