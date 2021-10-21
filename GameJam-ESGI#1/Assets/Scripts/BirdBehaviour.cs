using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdBehaviour : MonoBehaviour
{
    public bool isRight;
    public float birdSpeed = 2;

    void Start()
    {
        
    }

    void FixedUpdate()
    {
        int dir = isRight ? 1 : -1;

        transform.position += Vector3.right * dir * birdSpeed * Time.fixedDeltaTime;
    }
}
