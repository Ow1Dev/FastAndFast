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
		Player = GetComponent<Transform>();
		liment = (Floor.localScale.x / 2) - (Player.localScale.x/2);
	}
	
	// Update is called once per frame
	void Update () {
		input = Input.GetAxisRaw("Horizontal");
		input *= Time.deltaTime;
		input *= speed;
		if(GM.isRunning()) {
	    	transform.position = new Vector3(Mathf.Clamp(transform.position.x + input, -liment, liment), 0, 0);
		}
		
		
	}
}
