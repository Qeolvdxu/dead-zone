using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [Header("Inspector - Set Values")]
    public float movementSpeed;
    public float move2;
    private Rigidbody rigid;
    private Grapple grappleScript; //Used to grab variables from Grapple script on same object



    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        grappleScript = GetComponent<Grapple>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        DirectionalMovement();
        VelocityDampener();
        FacingDirection();
    }

    void VelocityDampener()
    {
        if (Mathf.Abs(rigid.velocity.x) > 0)
        {
            float y, z;
            Vector3 temp;
            y = rigid.velocity.y;
            z = rigid.velocity.z;
            temp = Vector3.Lerp(rigid.velocity, Vector3.zero, 0.1f);
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
            temp = Vector3.Lerp(rigid.velocity, Vector3.zero, 0.1f);
            temp.x = x;
            temp.y = y;
            rigid.velocity = temp;
        }
    }

    void DirectionalMovement()
    {
        //Move player with velocity
        if (Input.GetKey("w"))
        {
            rigid.velocity = new Vector3(rigid.velocity.x, rigid.velocity.y, rigid.velocity.z + movementSpeed);
        }
        if (Input.GetKey("a"))
        {
            rigid.velocity = new Vector3(rigid.velocity.x - movementSpeed, rigid.velocity.y, rigid.velocity.z);
        }
        if (Input.GetKey("s"))
        {
            rigid.velocity = new Vector3(rigid.velocity.x, rigid.velocity.y, rigid.velocity.z - movementSpeed);
        }
        if (Input.GetKey("d"))
        {
            rigid.velocity = new Vector3(rigid.velocity.x + movementSpeed, rigid.velocity.y, rigid.velocity.z);
        }
    }


    
    private void FacingDirection()
    {
        //Make the player face in the direction they're moving
        this.transform.rotation = Quaternion.LookRotation(rigid.velocity);
    }



    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Bullet")
        {
            print("test");
            Physics.IgnoreCollision(collision.gameObject.GetComponent<Collider>(), GetComponent<Collider>());
        }

    }

}
