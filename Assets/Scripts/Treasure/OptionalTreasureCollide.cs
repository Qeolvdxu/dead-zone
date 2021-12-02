using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionalTreasureCollide : MonoBehaviour
{
    private bool hasCollided = false;
    private Light light;
    public float rangeAdd;

    // Start is called before the first frame update
    void Start()
    {
        light = GetComponentInChildren<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //If player collides with optional treasure, increase score. If player collides with fuel, increase light range around player
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "TreasureOpt")
        {
            //hasCollided used to make sure multiple collisions w/ the treasure don't count for multiple points
            if(hasCollided == false)
            {
                hasCollided = true;
                Destroy(collision.gameObject);
                PlayerScore.PScore.IncreaseScore(20);
                StartCoroutine(resetCollider());
            }
            
        }
        if (collision.gameObject.tag == "Fuel")
        {
            light.range += rangeAdd;
            Destroy(collision.gameObject);
            StartCoroutine(resetCollider());
        }
    }

    IEnumerator resetCollider()
    {
        yield return new WaitForSeconds(0.1f);
        hasCollided = false;
    }
}
