using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emitter : MonoBehaviour {

	[SerializeField] 
	public GameObject prefab;
	public GameObject myParent;
	
	public float max = 4.5f;
	public float min = -4.5f;
	

	public void SpawnObject() {
		//Spawn a object between max and min value
		Instantiate(prefab, new Vector3(Random.Range(min, max), transform.position.y, transform.position.z), Quaternion.identity, myParent.transform );
	}

	//go to every object and destroys it
	public void DestoyAllBullet() {
		for (int ChildenIndex = 0; ChildenIndex < myParent.transform.childCount; ChildenIndex++)
		{
			Destroy(myParent.transform.GetChild(ChildenIndex).gameObject);
		}
	}
}
