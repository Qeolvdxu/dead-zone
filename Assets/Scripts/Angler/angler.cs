using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class angler : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject player;
    private Vector3 spawnPosition;
    void Start()
    {
        //spawn position used to reset anglers when the player dies
        spawnPosition = this.transform.position;
        //finds player to track with the pathfinding
        player = GameObject.FindGameObjectWithTag("Player");
        if(!player)
            Debug.Log("Make sure your player is tagged!!");
    }

    // Update is called once per frame
    void Update()
    {
        //Reset positions of the anglers if the player died
        if(PlayerLives.PLives.testJustDied())
        {
            ResetPositions();
        }
        //If the player wins, stop angler movement, otherwise, pathfind to player
        if(!Movement.player.IsEnded())
        {
            GetComponent<UnityEngine.AI.NavMeshAgent>().destination = player.transform.position;
        }
        else
        {
            GetComponent<UnityEngine.AI.NavMeshAgent>().isStopped = true;
        }
    }


    //Used to return anglers to their spawn position
    void ResetPositions()
    {
        this.transform.position = spawnPosition;
    }
}
