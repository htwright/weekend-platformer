using models;
using UnityEngine;
public class Enemy : MonoBehaviour
{

    public delegate void EnemyEvent(EventArgs args);
    public static event EnemyEvent onEnemyEvent;

    GameObject player;

    public int maxHealth = 10;
    public int Id { get; set; }
    public int aggroRange = 10;
    bool aggroed = false;
    public float moveSpeed = 0.5f;
    int health = 10;
    int regenFrequency = 180;

    // Use this for initialization
    void Start()
    {
        gameObject.tag = "enemy";
        TestManager.onEnemyHit += Damage;
        Id = transform.GetInstanceID();
    }


    private void FixedUpdate()
    {
        player = GameObject.Find("Player");
        var playerPosition = player.transform.position;
        var delta = System.Math.Abs((playerPosition - transform.position).x);
        if (delta < aggroRange || aggroed)
        {
            aggroed = true;
            transform.position = Vector2.MoveTowards(transform.position, playerPosition, moveSpeed * Time.deltaTime);
        }
    }

    private void Update()
    {
        if(Time.frameCount % regenFrequency == 0)
        {
            health += 1;
        }
    }


    // Update is called once per frame
    void Damage(Color color, EventArgs eventArgs)
    {

        transform.GetComponent<Renderer>().material.color = color;
        TakeDamage(10);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            //Debug.Log("MARIO'D");
            TakeDamage(10);
            Destroy(gameObject);
        }
        if(collision.gameObject.tag == "bullet")
        {
            TakeDamage(BulletScript.FindObjectOfType<BulletScript>().damage);
        }
    }

    void TakeDamage(int damage)
    {
        var args = new EventArgs()
        {
            Damage = maxHealth,
            Id = Id
        };
        health -= damage;
        if (health == 0) Destroy(gameObject);
        onEnemyEvent(args);
    }

}
