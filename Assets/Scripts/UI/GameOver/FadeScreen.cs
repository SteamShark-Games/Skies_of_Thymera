using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeScreen : MonoBehaviour
{
    private void Start()
    {
        gameObject.GetComponent<Image>();
        Time.timeScale = 1.0f;
    }

    private void Update()
    {
        if (gameObject.GetComponent<Image>().color.a == 0) Destroy(gameObject);
    }
}
