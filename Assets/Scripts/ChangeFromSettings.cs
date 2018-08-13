using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeFromSettings : MonoBehaviour {

	public void loadTitle(){
		SceneManager.LoadScene("TitleScene");
	}
	public void loadhighScoresScene(){
		SceneManager.LoadScene ("highScores");
	}
}
