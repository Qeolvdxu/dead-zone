using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetPlayerPosition : MonoBehaviour
{
    //used to call this function from other scripts
    public static GetPlayerPosition player;
    // Start is called before the first frame update
    void Start()
    {
        //used to call this function from other scripts
        player = GetComponent<GetPlayerPosition>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public Vector3 GetPosition()
    {
        Vector3 position = this.transform.position;
        return position;
    }
}
