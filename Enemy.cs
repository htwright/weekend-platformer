using models;
using UnityEngine;
public class Enemy : MonoBehaviour
{

    public delegate void EnemyEvent(EventArgs args);
    public static event EnemyEvent onEnemyEvent;

    GameObject player;

    public int maxHealth { get; set; }
    public int Id { get; set; }
    public int aggroRange = 10;
    bool aggroed = false;
    public float moveSpeed = 0.5f;

    // Use this for initialization
    void Start()
    {
        gameObject.tag = "enemy";
        TestManager.onEnemyHit += Damage;
        maxHealth = 10;
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


    // Update is called once per frame
    void Damage(Color color, EventArgs eventArgs)
    {

        transform.GetComponent<Renderer>().material.color = color;
        TakeDamage();

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Player" || collision.gameObject.tag == "bullet")
        {
            //Debug.Log("MARIO'D");
            TakeDamage();
            Destroy(gameObject);
        }
    }

    void TakeDamage()
    {
        var args = new EventArgs()
        {
            Damage = maxHealth,
            Id = Id
        };
        onEnemyEvent(args);
    }

}
