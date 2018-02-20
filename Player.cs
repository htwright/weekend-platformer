using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;
using UnityStandardAssets._2D;
using UnityStandardAssets.CrossPlatformInput;
using models;

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



    int regenFrequency = 90;
    public float resistance = 1f;

    public Health health;
    public Mana mana;
    

    

    void Awake()
    {

    }
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        initialPosition = rb2d.position;
        rb2d.freezeRotation = true;
        mana = new Mana();
        health = new Health()
        {
            Resistance = resistance
        };
    }

    void Update()
    {
        if (health.Dead) die();
        if(Input.GetKeyDown(KeyCode.Space))
        {
            jump();
        }
        mana.regen();
        health.regen();

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
            takeDamage(10f);
        }

        if (collision.gameObject.tag == "bullet")
        {
            takeDamage(BulletScript.FindObjectOfType<BulletScript>().damage);
        }

    }

    void takeDamage(float amount = 1f)
    {
        gameObject.GetComponent<Renderer>().material.color = Color.red;
        var alive = health.spend(amount);
        if (!alive)
        {
            //die
        }

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
            if (mana.spend(10f))
            {
                doubleJump = true;
                GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce / 2));

            }
        }

    }

    void throttleLogs()
    {
               
        if(Time.frameCount % 17 == 0)
        {
        }
    }

    void die()
    {
        transform.position = initialPosition;
        health.respawn();
    }

}
