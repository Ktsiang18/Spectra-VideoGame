using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateLevelUI : MonoBehaviour {

	public Text levelNum;
	public Text instructions;
	public Text countDown; 
	public Text wave; 

	float currCountdownValue;


	private float timerDown;
	private float timerUp;
	private int timeF;
	private RectTransform myRectTransform;

	void Start(){
		timerUp = 0.0f;
		timerDown = 0.0f;
		StartCoroutine(StartCountdown());
		myRectTransform = GetComponent<RectTransform>();
	}
		
	// Update is called once per frame
	void Update () {
		
		//timer up
		timerUp += Time.deltaTime;
		if (timerUp > 0.0 && timerUp < 4.0) {
			levelNum.text = "1";
			instructions.text = "q = blue, w = red, e = blue";
			levelNum.enabled = true;
			instructions.enabled = true;
			countDown.enabled = true;
			wave.enabled = true;
		} else if (timerUp > 20.0 && timerUp < 24.5) {
			levelNum.text = "2";
			instructions.text = "Press g to shoot blue; Press t to shoot yellow ";
			levelNum.enabled = true;
			instructions.enabled = false;
			countDown.enabled = false;
			wave.enabled = true;
		} else if (timerUp > 50.0 && timerUp < 53.5) {
			levelNum.text = "3";
			instructions.text = "Press g to shoot blue; t to shoot yellow; r to shoot red";
			levelNum.enabled = true;
			instructions.enabled = false;
			countDown.enabled = false;
			wave.enabled = true;
		}
		else if (timerUp > 80.0 && timerUp < 53.5) {
				levelNum.text = "4";
				instructions.text = "Survival Mode!";
				levelNum.enabled = true;
				instructions.enabled = true;
				countDown.enabled = false;
				wave.enabled = true;


		} else {
			levelNum.enabled = false;
			instructions.enabled = false;
			countDown.enabled = false;
			wave.enabled = false;
		}
			
		//timer down 


		/* timerDown = timerDown + (Time.deltaTime*(-1)); 
		countDown.text = timerDown.ToString();
		Debug.Log ("updating time");

			if(timerDown == 0.0)
			{
				countDown.text = "Start Shooting";
			}
			else {
				
			}            */                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                          
	
		
}

	public IEnumerator StartCountdown(float countdownValue = 3)
	{
		currCountdownValue = countdownValue;
		while (currCountdownValue >= 0)
		{
			countDown.text = currCountdownValue.ToString();
			Debug.Log("Countdown: " + currCountdownValue);
			yield return new WaitForSeconds(1.0f);
			currCountdownValue--;
		}
	}
}
