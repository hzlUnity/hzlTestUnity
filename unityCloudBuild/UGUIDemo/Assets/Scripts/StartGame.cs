using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Test ();
	}
	void Test(){
		GameObject go = Instantiate (Resources.Load("Prefabs/TestOne") as GameObject);
		TestOne tt = go.GetComponent<TestOne> ();
		if (tt == null) {

			tt = go.AddComponent<TestOne> ();
		}
	}
	// Update is called once per frame
	void Update () {
		
	}
}
