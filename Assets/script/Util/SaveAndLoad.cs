using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveAndLoad : MonoBehaviour{
	
	static int numberofscore = 4;


	public static void Save(HighScore[] High) {
		for (int i = 0; i < numberofscore; i++)
		{
			PlayerPrefs.SetString("name" + i , High[i].name);
			PlayerPrefs.SetFloat("score" + i , High[i].score);
		}
	}

	public static void reset() {
		for (int i = 0; i < numberofscore; i++)
		{
			PlayerPrefs.SetString("name" + i , "name");
			PlayerPrefs.SetFloat("score" + i , 0);
		}
	}

	public static HighScore[] Load() {
		List<HighScore> h = new List<HighScore>();


		for (int i = 0; i < numberofscore; i++)
		{
			// if(PlayerPrefs.HasKey("name" + i)) {
				try
				{
					string name = PlayerPrefs.GetString("name" + i);
					float score = PlayerPrefs.GetFloat("score" + i);

					HighScore hi = new HighScore(name, score);

					//Debug.Log("name: " + name + " score: " + score);

					h.Add(hi);	
					
				}
				catch (System.Exception)
				{	
					Debug.LogError("can't load");
				}
			// }
		}
		
		return h.ToArray();
	}
}
