using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using models;
public class Enemy : MonoBehaviour
{

    public delegate void EnemyEvent(EventArgs args);
    public static event EnemyEvent onEnemyEvent;

    public int maxHealth { get; set; }
    public int Id { get; set; }


    // Use this for initialization
    void Start()
    {
        TestManager.onEnemyHit += Damage;

        maxHealth = 10;
        Id = transform.GetInstanceID();
    }



    // Update is called once per frame
    void Damage(Color color, EventArgs eventArgs)
    {

        Debug.Log("Damage Called");
        transform.GetComponent<Renderer>().material.color = color;
        Debug.Log(eventArgs.ToString());
        TakeDamage();

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
