using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionalTreasureCollide : MonoBehaviour
{
    private bool hasCollided = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "TreasureOpt")
        {
            if(hasCollided == false)
            {
                hasCollided = true;
                Destroy(collision.gameObject);
                PlayerScore.PScore.IncreaseScore(20);
                StartCoroutine(resetCollider());
            }
            
        }
    }

    IEnumerator resetCollider()
    {
        yield return new WaitForSeconds(0.1f);
        hasCollided = false;
    }
}
