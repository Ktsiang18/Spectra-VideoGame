using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this script is placed on a bullet object
//the bullets may be red, blue or yellow
public class ChangeColorCollision : MonoBehaviour {
	
	//defines an array of colors the bullet may be changed to
	public Material[] material;
	Renderer rend;
	public Collider2D colliderRed;
	public Collider2D colliderYellow;
	public Collider2D colliderBlue;

	//the bullet will change color when shot through a collider
	//initializes colliders
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
		//when the collider is blue, bullet changes to material[1]
		//example: if bullet is red, its color would change to purple
		if (col.gameObject.tag == "blue")
		{
			rend.sharedMaterial = material [1];
			Debug.Log (rend.sharedMaterial);

		}
		//when the collider is yellow, bullet changes to material[2]
		//example: if bullet is red, its color would change to orange
		else if (col.gameObject.tag == "yellow")
		{
			rend.sharedMaterial = material [2];
			Debug.Log ("yellow has been hit");
		}
		//when the collider is red, bullet changes to material[3]
		//example: if bullet is red, its color would not change
		else if  (col.gameObject.tag == "red")
		{
			rend.sharedMaterial = material [3];
			Debug.Log ("red has been hit");
		}
	}
	// Update is called once per frame
	//Checks if bullet is colliding with any of the three colliders
	void Update(){
		OnTriggerEnter2D (colliderRed);
		OnTriggerEnter2D (colliderYellow);
		OnTriggerEnter2D (colliderBlue);
	}
}
