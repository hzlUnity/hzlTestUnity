using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TestOne : MonoBehaviour {
	private Button _Button;
	// Use this for initialization
	void Start () {
		_Button = transform.Find ("Panel/Button").GetComponent<Button> ();
		_Button.onClick.AddListener (OnClickBtn);
	}

	public void OnClickBtn(){
		GameObject go = Instantiate (Resources.Load("Prefabs/TestTwo") as GameObject);
		TestTwo tt = go.GetComponent<TestTwo> ();
		if (tt == null) {

			tt = go.AddComponent<TestTwo> ();
		}
		Close ();
	}
	// Update is called once per frame
	void Update () {

	}
	void Close(){
		Destroy (gameObject);
	}
}
