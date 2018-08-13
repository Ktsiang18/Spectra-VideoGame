using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ChangeFromFinish : MonoBehaviour {

	// Use this for initialization
	public void loadTitle(){
		SceneManager.LoadScene("Title Scene");
	}
	public void loadhighScoresScene(){
		SceneManager.LoadScene ("highScores");
	}
}
