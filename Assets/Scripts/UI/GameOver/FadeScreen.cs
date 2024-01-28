using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeScreen : MonoBehaviour
{
    private void Start()
    {
        gameObject.GetComponent<Image>();
    }

    private void Update()
    {
        if (gameObject.GetComponent<Image>().color.a == 0) Destroy(gameObject);
    }
}
