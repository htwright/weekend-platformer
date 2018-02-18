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

    public int health = 20;


    // Use this for initialization


    void Awake()
    {

    }
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        initialPosition = rb2d.position;
    }

    void Update()
    {
        if(grounded && Input.GetKeyDown(KeyCode.Space))
        {
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
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb2d.AddForce(movement * topSpeed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "enemy")
        {
            takeDamage();
        }
    }

    void takeDamage()
    {
        gameObject.GetComponent<Renderer>().material.color = Color.red;
        health--;

    }

    void throttleLogs()
    {
               
        if(Time.frameCount % 17 == 0)
        {
        }
    }

}
