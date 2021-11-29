using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [Header("Inspector - Set Values")]
    public float movementSpeed;
    private Rigidbody rigid;
    private Vector3 spawnPosition;



    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        spawnPosition = this.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        DirectionalMovement();
        VelocityDampener();
        FacingDirection();
        rigid.AddForce(Physics.gravity * rigid.mass * 5);
    }

    void VelocityDampener()
    {
        //So player doesn't keep moving indefinitely when adding velocity for movement
        if (Mathf.Abs(rigid.velocity.x) > 0)
        {
            float y, z;
            Vector3 temp;
            y = rigid.velocity.y;
            z = rigid.velocity.z;
            temp = Vector3.Lerp(rigid.velocity, Vector3.zero, 0.08f);
            temp.y = y;
            temp.z = z;
            rigid.velocity = temp;
        }
        if (Mathf.Abs(rigid.velocity.z) > 0)
        {
            float x, y;
            Vector3 temp;
            x = rigid.velocity.x;
            y = rigid.velocity.y;
            temp = Vector3.Lerp(rigid.velocity, Vector3.zero, 0.08f);
            temp.x = x;
            temp.y = y;
            rigid.velocity = temp;
        }
    }

    void DirectionalMovement()
    {
        //Move player with velocity and only when not using grappling hook
        //Using Vector3.ClampMagnitude() to prevent diagonal movement being much faster than cardinal movement
        if (Input.GetKey("w"))
        {
            Vector3 velocity = new Vector3(rigid.velocity.x, rigid.velocity.y, rigid.velocity.z + movementSpeed);
            velocity = Vector3.ClampMagnitude(velocity, 50.0f);
            rigid.velocity = velocity;
        }
        if (Input.GetKey("a"))
        {
            Vector3 velocity = new Vector3(rigid.velocity.x - movementSpeed, rigid.velocity.y, rigid.velocity.z);
            velocity = Vector3.ClampMagnitude(velocity, 50.0f);
            rigid.velocity = velocity;
        }
        if (Input.GetKey("s"))
        {
            Vector3 velocity = new Vector3(rigid.velocity.x, rigid.velocity.y, rigid.velocity.z - movementSpeed);
            velocity = Vector3.ClampMagnitude(velocity, 50.0f);
            rigid.velocity = velocity;
        }
        if (Input.GetKey("d"))
        {
            Vector3 velocity = new Vector3(rigid.velocity.x + movementSpeed, rigid.velocity.y, rigid.velocity.z);
            velocity = Vector3.ClampMagnitude(velocity, 50.0f);
            rigid.velocity = velocity;
        }
    }


    
    private void FacingDirection()
    {
        //Make the player face in the direction they're moving
        if(rigid.velocity != Vector3.zero)
        {
            Vector3 temp = this.transform.rotation.eulerAngles;
            Quaternion temp2 = Quaternion.LookRotation(rigid.velocity);
            //Only modify the y angle of the player according to their facing direction   
            float y = temp2.eulerAngles.y;
            temp2 = Quaternion.Euler(temp.x, y, temp.z);
            
            this.transform.rotation = temp2;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //If the main treasure falls into a pit, it gets teleported back to where it originally spawned at
        if (collision.gameObject.tag == "Death")
        {
            this.transform.position = spawnPosition;
        }
    }


}
