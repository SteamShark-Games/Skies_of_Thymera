using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinCol : MonoBehaviour
{
    // UI assets
    public TMP_Text CurrentTotal;
    public TMP_Text FinalTotal;

    AudioManager audioManager;

    // Current coins 
    float CurrentCoin = 0.0f;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Coin"))
        {
            CurrentCoin += 1;
            Debug.Log(CurrentCoin);
            CurrentTotal.SetText("x " + CurrentCoin.ToString());
            FinalTotal.SetText("Total Coins: " + CurrentCoin.ToString());
            Destroy(collision.gameObject);
            audioManager.PlaySFX(audioManager.coin);
            // Update GameManager with collected coins
            GameManager.instance.AddCoins(1);
        }
    }

    public void Update()
    {
        FinalTotal.SetText("Total Coins: " + CurrentCoin.ToString());
    }
}

