using models;
using UnityEngine;
public class Enemy : MonoBehaviour
{

    public delegate void EnemyEvent(EventArgs args);
    public static event EnemyEvent onEnemyEvent;

    GameObject player;

    public int maxHealth { get; set; }
    public int Id { get; set; }


    public float moveSpeed = 10f;

    // Use this for initialization
    void Start()
    {
        TestManager.onEnemyHit += Damage;
        player = GameObject.Find("Player");
        maxHealth = 10;
        Id = transform.GetInstanceID();
        //Debug.Log(player);
    }


    private void FixedUpdate()
    {
        var playerPosition = player.GetComponent<Transform>().position;
        transform.position = Vector2.MoveTowards(transform.position, playerPosition, moveSpeed * Time.deltaTime);
        //GetComponent<Rigidbody2D>().AddForce(new Vector2(moveSpeed, 0f));
    }


    // Update is called once per frame
    void Damage(Color color, EventArgs eventArgs)
    {

        //Debug.Log("Damage Called");
        transform.GetComponent<Renderer>().material.color = color;
        //Debug.Log(eventArgs.ToString());
        TakeDamage();

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            Debug.Log("MARIO'D");
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
