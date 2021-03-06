﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {


    public GameObject player;
    public Transform target;
    private Vector3 offset;
    public float smoothSpeed = 0.125f;

    private void Start()
    {
        //player = GameObject.Find("Square");
        offset = transform.position - player.transform.position;
    }

    private void FixedUpdate()
    {
        Vector3 desiredPosition = player.transform.position;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = player.transform.position + offset;
    }
}
