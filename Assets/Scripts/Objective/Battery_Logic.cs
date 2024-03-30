using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battery_Logic : MonoBehaviour
{
    public List<GameObject> Batteries;
    public bool On_Off_toggle;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) ToggleBatteryShields();

        if (Input.GetKeyDown(KeyCode.Alpha2)) ResetBatteries();   
    }

    void ToggleBatteryShields()
    {
        foreach (GameObject battery in Batteries)
        {
            Boss_Generator bossGenerator = battery.GetComponent<Boss_Generator>();
            if (bossGenerator != null)
            {
                bossGenerator.shieldOn = !bossGenerator.shieldOn;
                Debug.Log("Shield set to " + bossGenerator.shieldOn);
            }
        }
    }

    void ResetBatteries()
    {
        foreach (GameObject battery in Batteries)
        { 
            battery.SetActive(true);
            Boss_Generator bossGenerator = battery.GetComponent<Boss_Generator>();
            if (bossGenerator != null)
            {
                bossGenerator.health = bossGenerator.maxHealth;
                bossGenerator.shieldOn = true;
            }
        }
        Debug.Log("Batteries Reset");
    }
}
