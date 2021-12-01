using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLives : MonoBehaviour
{
    public static PlayerLives PLives;
    private Vector3 spawnPosition;
    private static int numLives = 3;

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
        //If the main treasure falls into a pit, it gets teleported back to where it originally spawned at
        if (collision.gameObject.tag == "Death" || collision.gameObject.tag == "Angler")
        {
            HUD.playerHUD.RemoveLife();
            if(PlayerLives.PLives.GetLives() != 0)
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
