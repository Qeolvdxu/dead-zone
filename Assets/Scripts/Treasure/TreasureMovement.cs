using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureMovement : MonoBehaviour
{
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
        VelocityDampener();
    }

    void VelocityDampener()
    {
        if (Mathf.Abs(rigid.velocity.x) > 0)
        {
            float y, z;
            Vector3 temp;
            y = rigid.velocity.y;
            z = rigid.velocity.z;
            temp = Vector3.Lerp(rigid.velocity, Vector3.zero, 0.02f);
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
            temp = Vector3.Lerp(rigid.velocity, Vector3.zero, 0.02f);
            temp.x = x;
            temp.y = y;
            rigid.velocity = temp;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //If the main treasure falls into a pit, it gets teleported back to where it originally spawned at
        if(collision.gameObject.tag == "Death")
        {
            this.transform.position = spawnPosition;
        }
    }
}
    
