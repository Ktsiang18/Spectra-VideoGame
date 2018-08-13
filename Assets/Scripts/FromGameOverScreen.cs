using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FromGameOverScreen : MonoBehaviour {

	public void loadTitle(){
		SceneManager.LoadScene("TitleScene");
		Debug.Log ("called scene change");
	}

	public void loadhighScoresScene(){
		SceneManager.LoadScene ("highScores");
	}
}
