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
    private float jumpForce = 500f;
    public float gravity = 20f;
    public List<int> jumpList = new List<int>();
    public int jumpLimit = 2;
    bool jumping = false;
    int lastJump;
    Vector2 initialPosition;

    bool grounded = false;
    public Transform groundCheck;
    float groundRadius = 1.2f;
    public LayerMask whatIsGround;

    // Use this for initialization


    void Awake()
    {

    }
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        initialPosition = rb2d.position;
        //groundCheck = GetComponent<Transform>("GroundCheck");
    }

    void Update()
    {
        if(grounded && Input.GetKeyDown(KeyCode.Space))
        {
            //Debug.Log("shouldjump");
            grounded = false;
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce));
        }

    }

    void FixedUpdate()
    {

        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);

        if (Input.GetKey(KeyCode.X)) rb2d.position = initialPosition;

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = 0f;
        //Debug.Log(moveHorizontal);

        //if (Input.GetKey(KeyCode.Space)) moveVertical = jump();
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb2d.AddForce(movement * topSpeed);
    }


    //float jump()
    //{

        //if (Time.frameCount - lastJump <= 60) return 0;
        //lastJump = Time.frameCount;
        //return jumpForce * 4;



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
    //}



    void throttleLogs()
    {
               
        if(Time.frameCount % 17 == 0)
        {
        }
    }

}
