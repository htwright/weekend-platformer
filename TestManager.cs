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
    public Text scoreText;
    public int count;


    void Awake()
    {
        _instance = this;
        scoreText = GameObject.Find("Score").GetComponent<Text>();

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
        //if (Input.GetKeyDown(KeyCode.Space) && onEnemyHit != null)
        //{
        //    changeColor();
        //}
        //if (Input.GetKeyDown(KeyCode.G)) Debug.Log("g pressed");

        //if (Input.anyKey) Debug.Log("pressed");

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
        scoreText.text = "Count: " + count.ToString();
    }
    void incrementScore()
    {
        count++;
    }

    void updateDamage(EventArgs args)
    {
        //Debug.Log(args.ToString());

        count += args.Damage;
        setScore();
    }

}

