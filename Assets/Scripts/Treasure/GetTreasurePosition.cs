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

    public Vector3 GetPosition()
    {
        Vector3 position = this.transform.position;
        return position;
    }

    public void DestroyTreasure()
    {
        PlayerScore.PScore.IncreaseScore(100);
        Destroy(this.gameObject);
    }
}
