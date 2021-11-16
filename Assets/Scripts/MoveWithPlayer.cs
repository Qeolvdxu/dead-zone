using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWithPlayer : MonoBehaviour
{
    [Header("Inspector - Set Values")]
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPosition;
        playerPosition = this.transform.position;
        playerPosition.x = player.transform.position.x;
        playerPosition.z = player.transform.position.z;
        this.transform.position = playerPosition;
    }
}
