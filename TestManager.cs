using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using models;
public class TestManager : MonoBehaviour
{
    #region 
    private static TestManager _instance;
    public static TestManager Instance
    {
        get
        {

            if (_instance == null)
            {

                GameObject go = new GameObject("TestManager");
                go.AddComponent<TestManager>();

            }

            return _instance;
        }

    }
    #endregion



    public delegate void ChangeEnemyColor(Color color, EventArgs eventArgs);
    public static event ChangeEnemyColor onEnemyHit;
    public float count;
    Player player;
    Text scoreText;
    Text healthText;
    Text manaText;
    bool bullet;

    void Awake()
    {
        _instance = this;
        scoreText = GameObject.Find("Score").GetComponent<Text>();
        healthText = GameObject.Find("Health").GetComponent<Text>();
        manaText = GameObject.Find("Mana").GetComponent<Text>();
    }


    // Use this for initialization
    void Start()
    {
        count = 0;  
        setScore();
        Enemy.onEnemyEvent += updateDamage;
    }

    // Update is called once per frame
    void Update()
    {
        player = FindObjectOfType<Player>();
        healthText.text = string.Format("Health: {0}", player.health.Count.ToString());
        manaText.text = string.Format("Mana: {0}", player.mana.Count.ToString());
    }

    EventArgs makeArgs()
    {
        return new EventArgs()
        {
            Damage = 10,
            Id = transform.GetInstanceID()
        };
    }

    void changeColor()
    {

        onEnemyHit(Color.red, makeArgs());
        incrementScore();
        setScore();

    }

    void setScore()
    {
        scoreText.text = "Score: " + count.ToString();
    }
    void incrementScore()
    {
        count++;
    }

    void updateDamage(EventArgs args)
    {
        count += args.PointValue;
        setScore();
    }

    public bool spawnBullet()
    {
        if (!bullet)
        {
            bullet = true;
            return true;
        }
        return false;
    }

    public void destroyBullet()
    {
        bullet = false;
    }
}

