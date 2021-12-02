using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetTreasurePosition : MonoBehaviour
{
    public static GetTreasurePosition treasure;
    // Start is called before the first frame update
    void Start()
    {
        treasure = GetComponent<GetTreasurePosition>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Other scripts can get current treasure position
    public Vector3 GetPosition()
    {
        Vector3 position = this.transform.position;
        return position;
    }

    //Other scripts can destroy main treasure
    public void DestroyTreasure()
    {
        PlayerScore.PScore.IncreaseScore(100);
        Destroy(this.gameObject);
    }
}
