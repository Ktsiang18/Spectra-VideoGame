using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killYellow : MonoBehaviour {

	private Color yellow = new Color (1.0f, 0.9411765f, 0.0f, 1.000f);
	public AudioSource audio;

	void OnTriggerEnter2D(Collider2D col)
	{
		Debug.Log ("BulletR" + col.gameObject.name + ", " + col.gameObject.GetComponent<SpriteRenderer> ().material.color.r + "," + yellow.r);
		Debug.Log ("BulletG" + col.gameObject.name + ", " + col.gameObject.GetComponent<SpriteRenderer> ().material.color.g + "," + yellow.g);
		Debug.Log ("BulletB" + col.gameObject.name + ", " + col.gameObject.GetComponent<SpriteRenderer> ().material.color.b + "," + yellow.b);




		if ((Mathf.Approximately(col.gameObject.GetComponent<SpriteRenderer> ().material.color.r, yellow.r)) && 
			(Mathf.Approximately(col.gameObject.GetComponent<SpriteRenderer> ().material.color.b,yellow.b)) && 
			(Mathf.Approximately(col.gameObject.GetComponent<SpriteRenderer> ().material.color.g,yellow.g))) {
			//Debug.Log ("GOTCHA");

			AudioSource.PlayClipAtPoint (audio.clip,this.transform.position);

			Destroy (gameObject);

		}
			

		}


	}


