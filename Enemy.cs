using models;
using UnityEngine;
public class Enemy : MonoBehaviour
{

    public delegate void EnemyEvent(EventArgs args);
    public static event EnemyEvent onEnemyEvent;

    GameObject player;

    public int pointValue = 10;
    public int Id { get; set; }
    public int aggroRange = 10;
    bool aggroed = false;
    public float moveSpeed = 0.5f;

    int regenFrequency = 180;
    float regenAmount = 1f;
    public float maxHealth = 10;
    public float resistance = 0;

    Health health; 
    // Use this for initialization
    void Start()
    {
        gameObject.tag = "enemy";
        TestManager.onEnemyHit += Damage;
        Id = transform.GetInstanceID();
        health = new Health(maxHealth, resistance, regenAmount, regenFrequency);
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
        if (health.Dead) die();
        health.regen();
        Debug.Log(health.Count);
    }


    // Update is called once per frame
    void Damage(Color color, EventArgs eventArgs)
    {

        transform.GetComponent<Renderer>().material.color = color;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            //Debug.Log("MARIO'D");
            TakeDamage(health.Max);
        }
        if(collision.gameObject.tag == "bullet")
        {
            TakeDamage(BulletScript.FindObjectOfType<BulletScript>().damage);
        }
    }

    void TakeDamage(float damage)
    {
        var args = new EventArgs()
        {
            Damage = damage,
            Id = Id,
            PointValue = pointValue
        };
        onEnemyEvent(args);
 
        health.spend(damage);

    }

    void die()
    {
        Destroy(gameObject);
    }

}
