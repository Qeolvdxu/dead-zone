using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLives : MonoBehaviour
{
    public static PlayerLives PLives;
    private Vector3 spawnPosition;
    private int numLives = 3;

    // Start is called before the first frame update
    void Start()
    {
        PLives = GetComponent<PlayerLives>();
        numLives = 3;
        spawnPosition = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        //If the player falls into a death pit, or collides w/ the angler, the player respawns and loses a life
        if (collision.gameObject.tag == "Death" || collision.gameObject.tag == "Angler")
        {
            HUD.playerHUD.RemoveLife();
            if(numLives != 0)
            {
                this.transform.position = spawnPosition;
            }
            
        }
    }

    public int GetLives()
    {
        return numLives;
    }

    public void RemoveLife()
    {
        numLives--;
    }

}
