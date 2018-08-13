using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class StartButton : MonoBehaviour {
	public void loadMainScene(){
		SceneManager.LoadScene("ColorLayeringTest");
	}

	public void loadSettingsScene(){
		SceneManager.LoadScene ("Settings");
	}

	public void loadChooseLevels(){
		SceneManager.LoadScene ("ChooseLevelScene");
	}
}
 