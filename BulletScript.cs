﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {


    public GameObject player;
    public Transform spawnPoint;
    Vector2 inputPosition;
    


	// Use this for initialization
	void Start ()
    {
        player = GameObject.Find("Player");
        inputPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        inputPosition.x = inputPosition.x * 2;
        gameObject.tag = "bullet";
        Debug.Log(inputPosition);

	}
	
	// Update is called once per frame
	void Update ()
    {
    }

    void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, inputPosition, Time.deltaTime * 10);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (!(collision.gameObject.name == "Player")) Destroy(gameObject);
    }
        
}
