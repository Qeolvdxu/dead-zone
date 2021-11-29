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
        //text = GetComponentInChildren<Renderer>();
        text = this.transform.Find("TipText").GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        mainTreasureLocation = GetTreasurePosition.treasure.GetPosition();
        if(Mathf.Sqrt(Mathf.Pow((this.transform.position.x - mainTreasureLocation.x), 2) + Mathf.Pow((this.transform.position.y - mainTreasureLocation.y), 2) + Mathf.Pow((this.transform.position.z - mainTreasureLocation.z), 2)) < 25.0f)
        {
            Destroy(this.gameObject);
        }
        playerLocation = GetPlayerPosition.player.GetPosition();
        if (Vector3.Distance(this.transform.position, playerLocation) < 50.0f)
        {
            text.enabled = true;
        }
        else if(Mathf.Sqrt(Mathf.Pow((this.transform.position.x - playerLocation.x), 2) + Mathf.Pow((this.transform.position.y - playerLocation.y), 2) + Mathf.Pow((this.transform.position.z - playerLocation.z), 2)) > 50.0f)
        {
            text.enabled = false;
        }
    }
}
