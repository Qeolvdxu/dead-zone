using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionalTreasureFloat : MonoBehaviour
{
    [Header("Inspector - Set Values")]
    private float speed = 2;
    private Vector3 spawnPosition;
    
    // Start is called before the first frame update
    void Start()
    {
        spawnPosition = this.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Make the treasure float up and down smoothly using a sine function
        Vector3 currentPos = this.transform.position;
        float newY = Mathf.Sin(Time.time * speed);
        this.transform.position = new Vector3(currentPos.x, newY + spawnPosition.y, currentPos.z);
    }
}
