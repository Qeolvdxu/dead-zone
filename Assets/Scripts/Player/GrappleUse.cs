using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrappleUse : MonoBehaviour
{
    [Header("Inspector - Set Values")]
    public GameObject grapplingHookPrefab;
    public static GrappleUse grappleInstance; // Used so other scripts can access the public methods here
    public float hookVelocity;
    public float grappleCooldown;
    public bool grappleAllowed;
    public float grappleTreasureForce;
    private bool isGrappling = false;
    private bool unclampMagnitude = false;
    private int directionFlag;
    private Vector3 hookLocation;
    private Rigidbody rigid;
    private Rigidbody rigidTreasure;


    // Start is called before the first frame update
    void Start()
    {
        //used to access functions in this script from other scripts
        grappleInstance = GetComponent<GrappleUse>();
        //used to modify velocity
        rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        DirectionButton();
        //Reclamp player max speed velocity magnitude once the grapple has finished
        if(Vector3.Distance(this.transform.position, hookLocation) < 10.0f)
        {
            unclampMagnitude = false;
        }
    }
    
    void DirectionButton()
    {
        //Detect when player presses an arrow key, and set a flag to indicate which direction, and start the grapple cooldown timer
        if(Input.GetKeyDown("up") && !isGrappling && grappleAllowed)
        {
            isGrappling = true;
            directionFlag = 0;
            ShootGrapple();
            StartCoroutine(GrappleCooldown());
            
        }
        if (Input.GetKeyDown("left") && !isGrappling && grappleAllowed)
        {
            isGrappling = true;
            directionFlag = 1;
            ShootGrapple();
            StartCoroutine(GrappleCooldown());
        }
        if (Input.GetKeyDown("down") && !isGrappling && grappleAllowed)
        {
            isGrappling = true;
            directionFlag = 2;
            ShootGrapple();
            StartCoroutine(GrappleCooldown());
        }
        if (Input.GetKeyDown("right") && !isGrappling && grappleAllowed)
        {
            isGrappling = true;
            directionFlag = 3;
            ShootGrapple();
            StartCoroutine(GrappleCooldown());
        }

    }
    //Cooldown for reseting isGrappling flag
    IEnumerator GrappleCooldown()
    {
        yield return new WaitForSeconds(grappleCooldown);
        isGrappling = false;
        unclampMagnitude = false;
    }

    
    void ShootGrapple()
    {
        GameObject localHook;
        Rigidbody hookRigid;
        localHook = Instantiate<GameObject>(grapplingHookPrefab);
        hookRigid = localHook.GetComponent<Rigidbody>();
        //only allows to use grapple if the game hasn't ended
        if(!Movement.player.IsEnded())
        {
            //Shoot grapple in direction according to the direction flag
            switch (directionFlag)
            {
                case 0:
                    localHook.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - 4, this.transform.position.z + 11f);
                    hookRigid.velocity = new Vector3(0.0f, 0.0f, hookVelocity);
                    break;
                case 1:
                    localHook.transform.position = new Vector3(this.transform.position.x - 11f, this.transform.position.y - 4, this.transform.position.z);
                    hookRigid.velocity = new Vector3(-hookVelocity, 0.0f, 0.0f);
                    break;
                case 2:
                    localHook.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - 4, this.transform.position.z - 11f);
                    hookRigid.velocity = new Vector3(0.0f, 0.0f, -hookVelocity);
                    break;
                case 3:
                    localHook.transform.position = new Vector3(this.transform.position.x + 11f, this.transform.position.y - 4, this.transform.position.z);
                    hookRigid.velocity = new Vector3(hookVelocity, 0.0f, 0.0f);
                    break;
            }
            //make the grapple hook face in the direction it's moving
            localHook.transform.rotation = Quaternion.LookRotation(hookRigid.velocity);
            localHook.transform.rotation = Quaternion.Euler(localHook.transform.rotation.eulerAngles.x + 90, localHook.transform.rotation.eulerAngles.y, localHook.transform.rotation.eulerAngles.z);
        }
        
    }

    //allows other functions to test if currently grappling
    public bool TestGrappling()
    {
        return isGrappling;
    }

    //allows other functions to change isGrappling value
    public void SetNotGrappling()
    {
        isGrappling = false;
    }

    //Pull user to grapple location
    public void GrapplePull(Vector3 grappleLocation)
    {
        unclampMagnitude = true;
        StartCoroutine(GrappleCooldown());
        Vector3 direction;
        //Get the vector going from the player to the location to grapple towards
        direction = new Vector3(grappleLocation.x - this.transform.position.x, grappleLocation.y - this.transform.position.y, grappleLocation.z - this.transform.position.z);
        //apply the velocity vector and scale it to adjust grappling speed
        rigid.velocity = direction*8;
        
    }

    //pull grappled treasure to the player
    public void GrappleTreasure(GameObject treasure)
    {
        rigidTreasure = treasure.GetComponent<Rigidbody>();
        Vector3 direction;
        direction = new Vector3(this.transform.position.x - treasure.transform.position.x, this.transform.position.y - treasure.transform.position.y, this.transform.position.z - treasure.transform.position.z);
        rigidTreasure.velocity = direction*grappleTreasureForce;
    }

    //allows other scripts to modify grappleEnabled variable
    public void EnableGrapple()
    {
        grappleAllowed = true;
    }

    //allows other scripts to test if the player's velicty magnitude is clamped or not
    public bool TestClampMagnitude()
    {
        return unclampMagnitude;
    }

    //used to test where the hook is currently at
    public void updateHookLocation(Vector3 input)
    {
        hookLocation = input;
    }
}
