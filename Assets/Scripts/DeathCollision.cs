using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathCollision : MonoBehaviour {

	public Text scoreNum;
	public Text finScore;
	public Text scoreActive;


	public GameObject during;
	public GameObject end;



	void OnTriggerEnter2D(Collider2D col)
	{
		//Debug.Log("end is now" + col.gameObject.name + ", " + col.gameObject.tag);


		if (col.gameObject.CompareTag("Enemy")) {

			//scoreActive.enabled = false;


			Debug.Log("inside end is now");
			end.SetActive (true);
			Instantiate (end);

			Destroy (this);

			finScore.text = scoreNum.text;
			


			//Destroy (GameObject.FindWithTag ("Play"));

			//during.SetActive (false);
			//during.gameObject.SetActive (false);
			//Destroy (during);
			//scoreActive.enabled = false;
			
		}

	
	}
}
