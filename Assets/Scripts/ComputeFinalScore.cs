using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComputeFinalScore : MonoBehaviour {
	public float finScore;
	public Text FinScoreText; 

public void computeScore(float score){
		FinScoreText.text = "Final Score: " + score.ToString();
	}

	void Start(){
		computeScore (finScore);
	}
}
