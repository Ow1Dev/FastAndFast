using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//to have user and score in one object
public class HighScore {

	public HighScore(string _name, float _score) {
		name = _name;
		score = _score;
	}

	public string name = "";
	public float score = 0f;
}
