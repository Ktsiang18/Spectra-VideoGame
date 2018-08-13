using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColorCollision : MonoBehaviour {
	public Material[] material;
	Renderer rend;
	public Collider2D colliderRed;
	public Collider2D colliderYellow;
	public Collider2D colliderBlue;



	// Use this for initialization
void Start () {
		colliderRed = GetComponent<Collider2D> ();
		colliderYellow = GetComponent<Collider2D> ();
		colliderBlue = GetComponent<Collider2D> ();
		rend = GetComponent<SpriteRenderer> ();
		rend.enabled = true;
		rend.sharedMaterial = material [0];
	}
	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "blue")
		{
			rend.sharedMaterial = material [1];
			Debug.Log (rend.sharedMaterial);

		}
		else if (col.gameObject.tag == "yellow")
		{
			rend.sharedMaterial = material [2];
			Debug.Log ("yellow has been hit");
		}
		else if  (col.gameObject.tag == "red")
		{
			rend.sharedMaterial = material [3];
			Debug.Log ("red has been hit");
		}
	}
	// Update is called once per frame
	void Update(){
		OnTriggerEnter2D (colliderRed);
		OnTriggerEnter2D (colliderYellow);
		OnTriggerEnter2D (colliderBlue);
	}
}
