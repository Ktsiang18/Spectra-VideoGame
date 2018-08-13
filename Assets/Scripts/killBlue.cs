using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killBlue : MonoBehaviour {

	private Color blue = new Color (0.0f, 0.000f, 1.000f, 1.000f);
	public AudioSource audio;


	void OnTriggerEnter2D(Collider2D col)
	{
		Debug.Log ("BulletR" + col.gameObject.name + ", " + col.gameObject.GetComponent<SpriteRenderer> ().material.color.r + "," + blue.r);
		Debug.Log ("BulletG" + col.gameObject.name + ", " + col.gameObject.GetComponent<SpriteRenderer> ().material.color.g + "," + blue.g);
		Debug.Log ("BulletB" + col.gameObject.name + ", " + col.gameObject.GetComponent<SpriteRenderer> ().material.color.b + "," + blue.b);




		if ((Mathf.Approximately(col.gameObject.GetComponent<SpriteRenderer> ().material.color.r, blue.r)) && 
			(Mathf.Approximately(col.gameObject.GetComponent<SpriteRenderer> ().material.color.b,blue.b)) && 
			(Mathf.Approximately(col.gameObject.GetComponent<SpriteRenderer> ().material.color.g,blue.g))) {
			//Debug.Log ("GOTCHA");



			AudioSource.PlayClipAtPoint (audio.clip,this.transform.position);

			Destroy (gameObject);


		}
			

		}


	}


