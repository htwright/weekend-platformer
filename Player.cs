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
    bool doubleJump = false;
    Vector2 initialPosition;

    bool grounded = false;
    public Transform groundCheck;
    float groundRadius = 1.2f;
    public LayerMask whatIsGround;

    public int health = 20;
    public int maxHealth = 20;
    public float maxMana = 20f;
    public float mana;
    int regenFrequency = 90;
    
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
        if(Input.GetKeyDown(KeyCode.Space))
        {
            jump();
        }
        if(Time.frameCount % regenFrequency == 0)
        {
            if (mana < maxMana)
            {
                mana += 1.5f;
            }
            else
            {
                mana = maxMana;
            }
            if(health < maxHealth)
            {
                health += 1;
            }
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

    void jump()
    {
        if (grounded)
        {
            doubleJump = false;
            grounded = false;
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce));

        } else if (!doubleJump)
        {
            //jumpforce at higher levels makes earlier double jumps crazy, but lower levels make later double jumps ineffective.
            doubleJump = true;
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce/2));
            mana -= 10f;
        }

    }

    void throttleLogs()
    {
               
        if(Time.frameCount % 17 == 0)
        {
        }
    }

}
