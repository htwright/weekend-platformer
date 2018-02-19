using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {


    public GameObject enemy;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        bool spawn = Time.frameCount % 17 == 0;

        if (spawn)
        {
            //Instantiate(enemy, transform.position, transform.rotation);

        }

    }
}
