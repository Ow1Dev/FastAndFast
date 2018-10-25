using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class textGui : MonoBehaviour {
	
	public Text txt;
	public Game gm;
	private float Timer;

	//While game is running add cout up.
	void Update(){
		if(gm.isRunning()) {
			Timer += 1 * Time.deltaTime;
			//set the txt text to the time and cut to only 2 decimal.
			txt.text = Timer.ToString("F2"); 
		} 

	}

	//when reseting sets the timer to nul and set the timer to the new time. 
	public void reset() {
		Timer = 0;
		if(txt.IsActive()) {
			txt.text = Timer.ToString("F2"); 
		}
	}

	//return the time
	public float getTimer() {
		return Timer;
	}

}
