using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [Header("Inspector - Set Values")]
    public float movementSpeed;
    private Rigidbody rigid;
    public static Movement player;
    
    private bool gameEnded = false;

    // Start is called before the first frame update
    void Start()
    {
        //used to modify velocity
        rigid = GetComponent<Rigidbody>();
        //used to call functions in this script in other scripts
        player = GetComponent<Movement>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        DirectionalMovement();
        VelocityDampener();
        FacingDirection();
        //Add more gravity to just the player
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
        //Move player with velocity
        //Disables movement when a gameover occurs
        //Using Vector3.ClampMagnitude() to prevent diagonal movement being much faster than cardinal movement
        if(!gameEnded)
        {
            if (Input.GetKey("w"))
            {
                Vector3 velocity = new Vector3(rigid.velocity.x, rigid.velocity.y, rigid.velocity.z + movementSpeed);
                if (!GrappleUse.grappleInstance.TestClampMagnitude())
                {
                    velocity = Vector3.ClampMagnitude(velocity, 50.0f);
                }
                rigid.velocity = velocity;
            }
            if (Input.GetKey("a"))
            {
                Vector3 velocity = new Vector3(rigid.velocity.x - movementSpeed, rigid.velocity.y, rigid.velocity.z);
                if (!GrappleUse.grappleInstance.TestClampMagnitude())
                {
                    velocity = Vector3.ClampMagnitude(velocity, 50.0f);
                }
                rigid.velocity = velocity;
            }
            if (Input.GetKey("s"))
            {
                Vector3 velocity = new Vector3(rigid.velocity.x, rigid.velocity.y, rigid.velocity.z - movementSpeed);
                if (!GrappleUse.grappleInstance.TestClampMagnitude())
                {
                    velocity = Vector3.ClampMagnitude(velocity, 50.0f);
                }
                rigid.velocity = velocity;
            }
            if (Input.GetKey("d"))
            {
                Vector3 velocity = new Vector3(rigid.velocity.x + movementSpeed, rigid.velocity.y, rigid.velocity.z);
                if (!GrappleUse.grappleInstance.TestClampMagnitude())
                {
                    velocity = Vector3.ClampMagnitude(velocity, 50.0f);
                }
                rigid.velocity = velocity;
            }
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Exit")
        {
            LevelHandler.levelHandlerInstance.NextLevel();
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

    public bool IsEnded()
    {
        return gameEnded;
    }    

   public void EndGame()
    {
        HUD.playerHUD.ShowGameover();
        //test++;
        gameEnded = true;
        StartCoroutine(Gameover());
    }



    IEnumerator Gameover()
    {
        yield return new WaitForSeconds(2);
        LevelHandler.levelHandlerInstance.Gameover();
    }

}
