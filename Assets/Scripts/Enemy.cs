using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    float timer = 0;
    float timeToMove = 0.5f;
    int numOfMovements = 0;
    float speed = 4.5f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer > timeToMove)
        {
            transform.Translate(new Vector3(speed, 0, 0));
            timer = 0;
            numOfMovements++;
        }
        if(numOfMovements == 10)
        {
            transform.Translate(new Vector3(0, -15f, 0));
            numOfMovements = 0;
            speed = -speed;
        }
    }
}
