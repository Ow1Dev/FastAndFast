using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NameFilter : MonoBehaviour {

	public string[] filter;

	public void onValueChange() {
		string Currenttext = GetComponent<InputField>().text;
		
		string newText = Currenttext;

		for (int i = 0; i < filter.Length; i++)
		{
			if(filter[i] != "" && filter[i] != null) {
				newText = Currenttext.Replace(filter[i] , "_").ToString();
			}
		}

		GetComponent<InputField>().text = newText;

	}
}
