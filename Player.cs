using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
   
  private static Player _instance;
   public static Player Instance
   {
      get 
      {
         if (_instance == null)
         {
            GameObject go = new GameObject("Player");
            go.AddComponent<Player>();
         }
         return _instance;
      }    
   }



	// Use this for initialization

  void Awake (){
    _instance = this;
  }
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		// Debug.Log("update");
    // if(Input.GetKeyDown(KeyCode.Space) && onEnemyHit != null){
		// Debug.Log("keycodespace and enemyhit");

    //   onEnemyHit(Color.red);
    // }
	}

  void changeColor() {

  }



}
