using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWithPlayerCamera : MonoBehaviour
{
    [Header("Inspector - Set Values")]
    public GameObject player;
    private float linearInterpolant;

    // Start is called before the first frame update
    void Start()
    {
        linearInterpolant = 0.05f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 playerPosition;
        float yPosition;
        yPosition = this.transform.position.y;

        playerPosition = Vector3.Lerp(this.transform.position, player.transform.position, linearInterpolant);
        playerPosition.y = yPosition;

        
        this.transform.position = playerPosition;
    }
}
