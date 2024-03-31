using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toggle : MonoBehaviour
{
    public GameObject[] needed;
    public GameObject[] placeholder;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null && collision.CompareTag("Player"))
        {
            foreach (GameObject go in needed)
            {
                go.SetActive(true);
            }
            foreach (GameObject go in placeholder)
            {
                go.SetActive(false);
            }
        }
    }
}
