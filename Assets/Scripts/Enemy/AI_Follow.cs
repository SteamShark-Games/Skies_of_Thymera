using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Follow : MonoBehaviour
{
    public GameObject player;
    public float followSpeed;
    float followingDistance;
    public float detectionRad;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        followingDistance = Vector2.Distance(transform.position, player.transform.position);
        if (followingDistance < detectionRad)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, followSpeed * Time.deltaTime);
        }
    }
}
