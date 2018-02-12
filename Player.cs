using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;
using UnityStandardAssets._2D;
using UnityStandardAssets.CrossPlatformInput;


public class Player : MonoBehaviour
{

    public Vector3 position;
    public float topSpeed = 10f;
    private Rigidbody2D rb2d;
    public float jumpForce = 100f;
    public float gravity = 20f;
    public List<int> jumpList = new List<int>();
    public int jumpLimit = 2;
    bool jumping = false;
    int lastJump;
    // Use this for initialization


    void Awake()
    {

    }
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {


    }

    void FixedUpdate()
    {

        

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = 0f;
        if (Input.GetKey(KeyCode.Space)) moveVertical = jump();
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        rb2d.AddForce(movement * topSpeed);
    }


    float jump()
    {

        if (Time.frameCount - lastJump <= 40) return 0;
        lastJump = Time.frameCount;
        jumping = false;

        return jumpForce;



        //if under jump limit return 0
        //if (jumping)
        //{
        //    jumping = false;
        //    if (jumpList.Count >= 1)
        //    {
        //        var lastJump = jumpList[0];
        //        if (Time.frameCount - lastJump <= 100)
        //        {
        //            return 0;
        //        }
        //    }
        //    if (jumpList.Count == jumpLimit && Time.frameCount - jumpList[jumpLimit - 1] > 200) jumpList = new List<int>();
        //    jumpList.Add(Time.frameCount);
        //    return jumpForce;

        //}

        //return 0;
    }



    void throttleLogs()
    {
               
        if(Time.frameCount % 17 == 0)
        {
        }
    }

}
