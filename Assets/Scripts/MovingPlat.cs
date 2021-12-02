using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlat : MonoBehaviour
{

    public float rightLimit;
    public float leftLimit;
    public int speed;
    private int direction = 1;
    Vector3 movement;

    void Start()
    {
        rightLimit += transform.position.x;
        leftLimit -= transform.position.x;
        leftLimit *= -1;
    }

    void Update()
    {
        //Move a platform back and forth by the specified distance and speed

        if (transform.position.x > rightLimit)
        {
            direction = -1;
        }
        else if (transform.position.x < leftLimit)
        {
            direction = 1;
        }
        movement = Vector3.right * direction * speed * Time.deltaTime;
        transform.Translate(movement);
    }
}