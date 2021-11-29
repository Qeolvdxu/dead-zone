using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetPlayerPosition : MonoBehaviour
{
    public static GetPlayerPosition player;
    // Start is called before the first frame update
    void Start()
    {
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
