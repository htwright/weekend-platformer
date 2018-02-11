using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CallbackSystem : MonoBehaviour {

  public delegate void OnMessageRecieved();
	// Use this for initialization
	void Start () {
		OnMessageRecieved test = WriteMessage;
    test();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

  void WriteMessage(){
    Debug.Log("Writemessage called");
  }
}
