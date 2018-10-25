using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	[SerializeField] Game gameManager;

	//when a object hit this object.
	private void OnCollisionEnter(Collision col) {
		//test if the object is a bullet
		if(col.gameObject.CompareTag("Bullet")) {
			//sending gameover to Game Manager
			gameManager.gameOver();
		}
	}
}
