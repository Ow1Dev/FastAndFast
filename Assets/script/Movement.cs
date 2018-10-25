using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
	public int speed = 10;
	public Transform Floor;
	private Transform Player;
	
	public Game GM;


	//private
	float input;
	float liment;

	// Use this for initialization
	void Start () {
		//gets the transform component.
		Player = GetComponent<Transform>();
		//gets where the limit by testing the width of the floor. 
		liment = (Floor.localScale.x / 2) - (Player.localScale.x/2);
	}
	
	// Update is called once per frame
	void Update () {
		//gets the input of Horizontal and apply speed on it
		input = Input.GetAxisRaw("Horizontal");
		input *= Time.deltaTime;
		input *= speed;
		//if the game is running do movement
		if(GM.isRunning()) {
	    	transform.position = new Vector3(Mathf.Clamp(transform.position.x + input, -liment, liment), 0, 0);
		}
		
		
	}
}
