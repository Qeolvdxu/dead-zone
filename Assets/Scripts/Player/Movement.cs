using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    [Header("Inspector - Set Values")]
    public float movementSpeed;
    private Rigidbody rigid;
    public static Movement player;
    public GameObject gameoverText;
    public static int test = 0;



    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        player = GetComponent<Movement>();
        print("Test: " + test);
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

   public void EndGame()
    {
        test++;
        GameObject localText;
        Vector3 gameOverLocation = MoveWithPlayerCamera.cameraInstance.GetCameraPosition();
        gameOverLocation.y = gameOverLocation.y - 20.0f;
        localText = Instantiate<GameObject>(gameoverText);
        gameoverText.transform.position = gameOverLocation;
        Destroy(this.gameObject);
        SceneManager.LoadScene("level_0");
    }


}
