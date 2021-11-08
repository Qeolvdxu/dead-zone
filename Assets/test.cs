using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    [Header("Inspector - Set Values")]
    public GameObject mover;
    public float linearInterpolant;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position;
        position = Vector3.Lerp(this.transform.position, mover.transform.position, linearInterpolant);
        this.transform.position = position;
    }
}
