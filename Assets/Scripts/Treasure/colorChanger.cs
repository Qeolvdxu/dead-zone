﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colorChanger : MonoBehaviour
{
    public Component[] cubeRenderers;
    // Start is called before the first frame update
    void Start()
    {
        //grab all the parts of the treasure prefab
        cubeRenderers = GetComponentsInChildren<Renderer>();

        //select a random color and set all the pieces to be that color
        int select = (int)Mathf.Floor(Random.Range(1f, 5f));
        foreach (Renderer cubeRenderer in cubeRenderers)
        {
            if (select == 1)
            {
                cubeRenderer.material.SetColor("_Color", Color.red);
            }
            else if (select == 2)
            {
                cubeRenderer.material.SetColor("_Color", Color.blue);
            }
            else if (select == 3)
            {
                cubeRenderer.material.SetColor("_Color", Color.green);
            }
            else
            {
                cubeRenderer.material.SetColor("_Color", Color.white);
            }
        }
       
        //cubeRenderer.EnableKeyword("_EMISSION");
       
        //cubeRenderer.SetColor("_EmmisionColor", Color.red);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
