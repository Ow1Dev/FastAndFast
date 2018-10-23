using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorEffect : MonoBehaviour {

	public Camera camera;
	private bool reverse = false;
	private float c = 0.1f;

	void Update () {
		if(reverse) {
				c -= .01f * Time.deltaTime;
			}else {
				c += .01f * Time.deltaTime;
			}
			
			if(c <= 0.1f) {
				reverse = !reverse;
			} else if(c >= 0.9f) {
				reverse = !reverse;
			}

			camera.backgroundColor = Color.HSVToRGB(c, 1, 1);
	}
}
