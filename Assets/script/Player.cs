using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	[SerializeField] Game gameManager;

	private void OnCollisionEnter(Collision col) {
		if(col.gameObject.CompareTag("Bullet")) {
			gameManager.gameOver();
		}
	}
}
