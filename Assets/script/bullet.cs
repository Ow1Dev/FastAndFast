using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour {

	public Game GM;

	// Use this for initialization
	void Start () {
		GM = GameObject.FindGameObjectWithTag("GameController").GetComponent<Game>();
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += new Vector3(0, 0, -(Time.deltaTime * GM.GetSpeed()));
		if(transform.position.z <= -10) {
			Destroy(gameObject);
		}
	}
}
