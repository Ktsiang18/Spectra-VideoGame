using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUpdate : MonoBehaviour {

	public Text ScoreText;
	private float timer;

	void Start(){
		timer = 0.0f;
	}

	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime; 
		ScoreText.text = timer.ToString();
		Debug.Log ("updating time");
	}
}
