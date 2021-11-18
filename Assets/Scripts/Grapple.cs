using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grapple : MonoBehaviour
{
    [Header("Inspector - Set Values")]
    public GameObject grapplingHookPrefab;
    public bool isGrappling = false;
    private int directionFlag;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DirectionButton();
    }
    
    void DirectionButton()
    {
        if(Input.GetKeyDown("up") && !isGrappling)
        {
            isGrappling = true;
            directionFlag = 0;
            ShootGrapple();
            StartCoroutine(GrappleCooldown());
            
        }
        if (Input.GetKeyDown("left") && !isGrappling)
        {
            isGrappling = true;
            directionFlag = 1;
            ShootGrapple();
            StartCoroutine(GrappleCooldown());
        }
        if (Input.GetKeyDown("down") && !isGrappling)
        {
            isGrappling = true;
            directionFlag = 2;
            ShootGrapple();
            StartCoroutine(GrappleCooldown());
        }
        if (Input.GetKeyDown("right") && !isGrappling)
        {
            isGrappling = true;
            directionFlag = 3;
            ShootGrapple();
            StartCoroutine(GrappleCooldown());
        }

    }
    IEnumerator GrappleCooldown()
    {
        yield return new WaitForSeconds(3);
        isGrappling = false;
    }

    void ShootGrapple()
    {
        GameObject localHook;
        Rigidbody hookRigid;
        localHook = Instantiate<GameObject>(grapplingHookPrefab);
        localHook.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
        hookRigid = localHook.GetComponent<Rigidbody>();
        switch(directionFlag)
        {
            case 0:
                hookRigid.velocity = new Vector3(0.0f, 0.0f, 60.0f);
                break;
            case 1:
                hookRigid.velocity = new Vector3(-60.0f, 0.0f, 0.0f);
                break;
            case 2:
                hookRigid.velocity = new Vector3(0.0f, 0.0f, -60.0f);
                break;
            case 3:
                hookRigid.velocity = new Vector3(60.0f, 0.0f, 0.0f);
                break;
        }

    }


}
