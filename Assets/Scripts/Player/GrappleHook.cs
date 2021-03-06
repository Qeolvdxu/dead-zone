using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrappleHook : MonoBehaviour
{
    [Header("Inspector - Set Values")]
    public GrappleUse playerTest;
    public float grappleLength;
    private Vector3 hookSpawnLocation;
    
    // Start is called before the first frame update
    void Start()
    {
        hookSpawnLocation = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //destroy the grappling hook if it doesn't find anything to latch onto
        if (Vector3.Distance(this.transform.position, hookSpawnLocation) > grappleLength)
        {
            Destroy(this.gameObject);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        //Disable collider and set velocity to 0 so the hook doesn't go anywhere after hitting the wall
        Collider self = GetComponent<Collider>();
        Rigidbody rigid = GetComponent<Rigidbody>();
        rigid.velocity = Vector3.zero;
        self.enabled = false;

        //If collide with wall, run GrapplePull function from the GrappleUse script
        if (collision.gameObject.tag == "Wall")
        {
            GrappleUse.grappleInstance.GrapplePull(this.transform.position);
            GrappleUse.grappleInstance.updateHookLocation(this.transform.position);
            StartCoroutine(destroySelfAfterSeconds(0.5f));
        }
        //if collide w/ main treasure, run GrappleTreasure function from the GrappleUse script
        else if(collision.gameObject.tag == "Treasure")
        {
            GrappleUse.grappleInstance.GrappleTreasure(collision.gameObject);
            Destroy(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }


    IEnumerator destroySelfAfterSeconds(float wait)
    {
        //Use to wait a certain amount of seconds before destroying the cabbage
        yield return new WaitForSeconds(wait);
        Destroy(this.gameObject);
    }

}
