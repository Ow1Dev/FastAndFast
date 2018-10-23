using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScore {

	public HighScore(string _name, float _score) {
		name = _name;
		score = _score;
	}

	public string name = "";
	public float score = 0f;
}
