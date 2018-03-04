using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateSpriteViaAltas : MonoBehaviour {
	// Use this for initialization
	void Start () {
		CreateSprite (LoadSprite("Image"));
		CreateSprite (LoadSprite("Image (1)"));
		CreateSprite (LoadSprite("Image (2)"));
	}
	Sprite LoadSprite(string name){
		return Resources.Load<GameObject> ("Prefabs/"+name).GetComponent<Image>().sprite;
	}
	void CreateSprite(Sprite sprite){
		GameObject obj2 = new GameObject (sprite.name);
		obj2.transform.parent = transform;
		obj2.transform.localScale = Vector3.one;
		Image img = obj2.AddComponent<Image> ();
		img.sprite = sprite;
	}
	// Update is called once per frame
	void Update () {
		
	}
}
