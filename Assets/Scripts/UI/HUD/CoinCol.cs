using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinCol : MonoBehaviour
{
    // UI assets
    public GameObject CoinDisplay;
    public GameObject CoinSprite;
    public TMP_Text CurrentTotal;

    // Game assets
    public GameObject Coin;

    // Floats 
    public float CurrentCoin = 0.0f; // Current coins 
    public float CoinVal = 1.0f; // Coin value

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (Coin.gameObject.CompareTag("Coin"))
        {
            CurrentCoin += CoinVal;
            //Destroy(Coin.gameObject); // Commented out till we add more around the level(s)
            Debug.Log(CurrentCoin);
            CurrentTotal.SetText(CurrentCoin.ToString());
        }
    }
}
