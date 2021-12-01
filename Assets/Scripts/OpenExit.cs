using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenExit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Treasure")
        {
            //Destroy Treasure
            GetTreasurePosition.treasure.DestroyTreasure();
            //Destroy wall
            Destroy(this.gameObject);
            //Used to enable grappling hook in tutorial level
            GrappleUse.grappleInstance.EnableGrapple();
            //Destroy parent to get rid of ExitText object
            Destroy(transform.parent.gameObject);
        }
    }
}
