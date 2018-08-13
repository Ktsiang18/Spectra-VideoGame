using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killRed : MonoBehaviour {

	private Color red = new Color (1.0f, 0.000f, 0.0f, 1.000f);
	public AudioSource audio;

	void OnTriggerEnter2D(Collider2D col)
	{
		//Debug.Log ("BulletR" + col.gameObject.name + ", " + col.gameObject.GetComponent<SpriteRenderer> ().color.r + "," + red.r);
		//Debug.Log ("BulletG" + col.gameObject.name + ", " + col.gameObject.GetComponent<SpriteRenderer> ().color.g + "," + red.g);
		//Debug.Log ("BulletB" + col.gameObject.name + ", " + col.gameObject.GetComponent<SpriteRenderer> ().color.b + "," + red.b);




		if ((Mathf.Approximately(col.gameObject.GetComponent<SpriteRenderer> ().material.color.r, red.r)) && 
			(Mathf.Approximately(col.gameObject.GetComponent<SpriteRenderer> ().material.color.b,red.b)) && 
			(Mathf.Approximately(col.gameObject.GetComponent<SpriteRenderer> ().material.color.g,red.g))) {
			//Debug.Log ("GOTCHA");

			AudioSource.PlayClipAtPoint (audio.clip,this.transform.position);

			Destroy (gameObject);

		}
			

		}


	}


