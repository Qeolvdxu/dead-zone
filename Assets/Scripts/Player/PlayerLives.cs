using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLives : MonoBehaviour
{
    private Vector3 spawnPosition;

    // Start is called before the first frame update
    void Start()
    {
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
            this.transform.position = spawnPosition;
            HUD.playerHUD.RemoveLife();
        }
    }

}
