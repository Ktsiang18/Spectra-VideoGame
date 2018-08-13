using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeFrmGame : MonoBehaviour {

	// Use this for initialization
	public void loadTitle(){
		SceneManager.LoadScene("TitleScene");
		Debug.Log ("CLICKED");
	}
}
