using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [Header("Inspector - Set Values")]
    public float movementSpeed;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 position;
        if (Input.GetKey("w"))
        { 
            position = this.transform.position;
            position.z += movementSpeed;
            this.transform.position = position;
        }
        if (Input.GetKey("a"))
        {
            position = this.transform.position;
            position.x -= movementSpeed;
            this.transform.position = position;
        }
        if (Input.GetKey("s"))
        {
            position = this.transform.position;
            position.z -= movementSpeed;
            this.transform.position = position;
        }
        if (Input.GetKey("d"))
        {
            position = this.transform.position;
            position.x += movementSpeed;
            this.transform.position = position;
        }
        
    }
}
