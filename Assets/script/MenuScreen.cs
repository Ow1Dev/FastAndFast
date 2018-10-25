using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuScreen : MonoBehaviour {
	

	public Game GM;
	public RectTransform Menu;
	public Text Scoretxt;
	public GameObject[] hs;
	public InputField nameinput;
	public GameObject[] DisableWhenRunning;
	public GameObject DisableWhenNotRunning;
	private Animation anim;
	private Animator animtor;

	// Use this for initialization
	public void StartMenu(HighScore[] Highscore) {
		//gets the componets it need
		Menu = GetComponent<RectTransform>();
		anim = GetComponent<Animation>();
		animtor = GetComponent<Animator>();

		// puts the score in to the higscore
		for (int i = 0; i < Highscore.Length; i++)
		{
			//Debug.Log(Highscore[i].name);

			hs[i].transform.GetChild(1).GetComponent<Text>().text = Highscore[i].name;
			hs[i].transform.GetChild(2).GetComponent<Text>().text = Highscore[i].score.ToString("F2") + " sec";
		}


	}
	
	// hidde the menu and play the animation
	public void hide () {
		Menu.localPosition = new Vector3(0, Screen.height * 5, 0);
		DisableWhenNotRunning.SetActive(true);
		foreach (GameObject dis in DisableWhenRunning)
		{
			dis.SetActive(false);
		}
		animtor.SetBool("ifHiding", true);
	}

	//shows the menu and play the animation
	public void show() {
		DisableWhenNotRunning.SetActive(false);
		foreach (GameObject dis in DisableWhenRunning)
		{
			dis.SetActive(true);
		}
		Scoretxt.text = "Your Score is: " + GM.getScore.ToString("F2");
		animtor.SetBool("ifHiding", false);
	}

	//check where the score is					//TODO: remove the parmenter CurrentHighScore 
	public HighScore[] CheckAndUpdateHighScore(float score) {	
		//create a array and initializing it.
		HighScore[] h = new HighScore[4];
		for (int i = 0; i < h.Length; i++)
		{
			h[i] = new HighScore("name", 0);
		}

		bool hasFound = false;
		string[] CurName = new string[4];
		string[] CurScore = new string[4];

		//test where the score can be place 
		for(int i = 0; i < 4; i++) {
			float v;
			//gets the time of the currenthighscore
			string ph = hs[i].transform.GetChild(2).GetComponent<Text>().text.Replace(" sec", "").ToString();

			//Converte it to a float
			if(float.TryParse(ph, out v)) {
				//test if the score is lager then last score
				if(score > v) {
					//test if player has type in a name				
					if(nameinput.text != "") {
							//if it have not found a position already
							if(!hasFound) {
								
								Debug.Log("Found");

								CurName[i] = hs[i].transform.GetChild(1).GetComponent<Text>().text;
								CurScore[i] = hs[i].transform.GetChild(2).GetComponent<Text>().text;

								hs[i].transform.GetChild(1).GetComponent<Text>().text = nameinput.text;
					 			hs[i].transform.GetChild(2).GetComponent<Text>().text = score.ToString("F2") + " sec";

								// Debug.Log("hasFound: " + hasFound);
								Debug.Log("Index: " + i + ": " + CurName[i]);

								hasFound = true;

								//saves the last score
					 			h[i].score = score;
					 			h[i].name = nameinput.text;

							} 
							//replace it with the top one
							else 
							{
								
								CurName[i] = hs[i].transform.GetChild(1).GetComponent<Text>().text;
								CurScore[i] = hs[i].transform.GetChild(2).GetComponent<Text>().text;

								float fScore = 0f;

								if(float.TryParse(CurScore[i-1].Replace(" sec", "").ToString(), out fScore)) {
									h[i].score = fScore;
					 				h[i].name = CurName[i-1];

									Debug.Log("dsa: " + h[i].name + ": " + h[i].score);
								}

						
								hs[i].transform.GetChild(1).GetComponent<Text>().text = CurName[i - 1];
								hs[i].transform.GetChild(2).GetComponent<Text>().text = CurScore[i - 1];
								Debug.Log("Index: " + i + ": " + CurName[i]);
							}
					}			
				} else {
					h[i].name = hs[i].transform.GetChild(1).GetComponent<Text>().text;

					float fScore;
					if(float.TryParse(hs[i].transform.GetChild(2).GetComponent<Text>().text.Replace(" sec", "").ToString(), out fScore)) {
						h[i].score = fScore;			
					}
				}
			}
		}
		return h;
	}

	//resets the text in the highscore
	public void ResethighScore(string name, string score) {
		for (int i = 0; i < hs.Length; i++)
		{
			hs[i].transform.GetChild(1).GetComponent<Text>().text = name;
			hs[i].transform.GetChild(2).GetComponent<Text>().text = score + " sec";
		}
	}

	//tests if the player has type in a name
	public void PlayGame() {
		if(nameinput.text != "") {
			GM.restart();
		} else {
			Debug.Log("You have not type in a name");
			anim.Play("NoName");
		}
		
	}
}
