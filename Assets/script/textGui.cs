using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class textGui : MonoBehaviour {
	
	public Text txt;
	public Game gm;
	private float Timer;

	void Update(){
		if(gm.isRunning()) {
			Timer += 1 * Time.deltaTime;
			txt.text = Timer.ToString("F2"); 
		} 

	}

	public void reset() {
		Timer = 0;
		if(txt.IsActive()) {
			txt.text = Timer.ToString("F2"); 
		}
	}

	public float getTimer() {
		return Timer;
	}

}
