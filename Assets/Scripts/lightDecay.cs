using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightDecay : MonoBehaviour
{
    // Start is called before the first frame update

    float MaxRange;

    Light lt;

    void Start()
    {
        lt = GetComponent <Light>();
        MaxRange = lt.range;
    }

    // Update is called once per frame
    void Update()
    {
        if (lt.range > 50f)
        {
            lt.range -= .1f;
        }
    }
}
