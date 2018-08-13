using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selfDestruct : MonoBehaviour {
	public int secondsToDestroy = 6;

	void Awake(){

		Debug.Log ("YO");

		if (gameObject.name == "BulletBlue(Clone)") {
			Destroy (gameObject, secondsToDestroy);
		}


		if (gameObject.name == "BulletYellow(Clone)") {
			Destroy (gameObject, secondsToDestroy);
		}


		if (gameObject.name == "BulletRed(Clone)") {
			Destroy (gameObject, secondsToDestroy);
		}

		if (gameObject.name == "Bullet(Clone)") {
			Destroy (gameObject, secondsToDestroy);
		}
	}
}
