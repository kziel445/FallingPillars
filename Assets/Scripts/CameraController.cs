﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;
    public bool useOffSetValues = true;
    void Start()
    {
        
    }

    void Update()
    {   
        if(Input.GetKeyDown("c")) useOffSetValues = !useOffSetValues;

        if (useOffSetValues) offset = new Vector3(5, -5, 5);
        else offset = player.position - transform.position;
        transform.position = player.position - offset;
        transform.LookAt(player.transform);
    }
}
