using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killGreen : MonoBehaviour {

	private Color color = new Color (0.0f, 1.0f, 0.0f, 0.000f);
	public AudioSource audio;

	void OnTriggerEnter2D(Collider2D col)
	{
		//Debug.Log ("BulletR" + col.gameObject.name + ", " + col.gameObject.GetComponent<SpriteRenderer> ().material.color.r + "," + color.r);
		//Debug.Log ("BulletG" + col.gameObject.name + ", " + col.gameObject.GetComponent<SpriteRenderer> ().material.color.g + "," + color.g);
		//Debug.Log ("BulletB" + col.gameObject.name + ", " + col.gameObject.GetComponent<SpriteRenderer> ().material.color.b + "," + color.b);




		if ((Mathf.Approximately(col.gameObject.GetComponent<SpriteRenderer> ().material.color.r, color.r)) && 
			(Mathf.Approximately(col.gameObject.GetComponent<SpriteRenderer> ().material.color.b,color.b)) && 
			(Mathf.Approximately(col.gameObject.GetComponent<SpriteRenderer> ().material.color.g,color.g))) {
			Debug.Log ("GOTCHA");
			AudioSource.PlayClipAtPoint (audio.clip,this.transform.position);;
			Destroy (gameObject);


		}
			

		}


	}


