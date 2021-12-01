using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenExit : MonoBehaviour
{
    private Vector3 mainTreasureLocation;
    private Vector3 playerLocation;
    private Renderer text;
    // Start is called before the first frame update
    void Start()
    {
        text = this.transform.Find("TipText").GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        mainTreasureLocation = GetTreasurePosition.treasure.GetPosition();
        if (Vector3.Distance(this.transform.position, mainTreasureLocation) < 25.0f)
        {
            //Destroy treasure object when it comes close to the exit wall
            //and destroy the wall
            GetTreasurePosition.treasure.DestroyTreasure();
            Destroy(this.gameObject);
            GrappleUse.grappleInstance.EnableGrapple();
        }

        playerLocation = GetPlayerPosition.player.GetPosition();
        if (Vector3.Distance(this.transform.position, playerLocation) < 50.0f)
        {
            text.enabled = true;
        }
        else if(Vector3.Distance(this.transform.position, playerLocation) > 50.0f)
        {
            text.enabled = false;
        }
    }
}
