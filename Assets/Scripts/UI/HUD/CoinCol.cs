using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinCol : MonoBehaviour
{
    // UI assets
    public TMP_Text CurrentTotal;

    // Current coins 
    float CurrentCoin = 0.0f; 

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Coin"))
        {
            CurrentCoin += 1;
            //Destroy(Coin.gameObject); // Commented out till we add more around the level(s)
            Debug.Log(CurrentCoin);
            CurrentTotal.SetText("x " + CurrentCoin.ToString());
        }
    }
}
