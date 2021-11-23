using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class angler : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject player;
    void Start()
    {
         player = GameObject.FindGameObjectWithTag("Player");
         if(!player)
             Debug.Log("Make sure your player is tagged!!");
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<UnityEngine.AI.NavMeshAgent>().destination = player.transform.position;
    }
}
