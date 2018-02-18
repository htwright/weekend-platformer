using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Spawn : MonoBehaviour
{


    public GameObject bullet;
    public Transform spawnPoint;



    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        bool shoot = Input.GetButtonDown("Fire1");

        if (shoot)
        {
            var x = Instantiate(bullet, spawnPoint.position, spawnPoint.rotation);

        }
    }
}
