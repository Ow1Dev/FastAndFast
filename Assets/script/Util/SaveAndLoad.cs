using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveAndLoad : MonoBehaviour{
	
	static int numberofscore = 4;


	public static void Save(HighScore[] High) {
		//take the highscore and saves it in the application

		for (int i = 0; i < numberofscore; i++)
		{
			PlayerPrefs.SetString("name" + i , High[i].name);
			PlayerPrefs.SetFloat("score" + i , High[i].score);
		}
	}

	public static void reset() {
		//reset all the highscore
		for (int i = 0; i < numberofscore; i++)
		{
			PlayerPrefs.SetString("name" + i , "name");
			PlayerPrefs.SetFloat("score" + i , 0);
		}
	}

	//return all the highscore store in the application
	public static HighScore[] Load() {

		//creating a list for at have a dynamic score
		List<HighScore> h = new List<HighScore>();


		//runs four times
		for (int i = 0; i < numberofscore; i++)
		{
				try
				{
					//get the higscore and name.
					string name = PlayerPrefs.GetString("name" + i);
					float score = PlayerPrefs.GetFloat("score" + i);
					//create a new object and puts name and score in
					HighScore hi = new HighScore(name, score);

					//add it to the list
					h.Add(hi);	
					
				}
				catch (System.Exception)
				{	
					Debug.LogError("can't load");
				}
			// }
		}
		
		//returns the list as a array
		return h.ToArray();
	}
}
