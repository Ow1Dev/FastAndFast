using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour {

	[SerializeField]
	Emitter Emitter;
	public textGui TG;
	public MenuScreen Menu;
	public GameObject MenuGM;
	public Transform Player;
	private HighScore[] progress;
	public float startWait = .5f;
	public float StartspawnWait = 1f;
	private float spawnWait;
	[Range(0.01f, 1f)]public float Waitdecrece = 0.2f;
	[Space]
	public float BulletStartSpeed = 60;
	private float bulletSpeed;

	public float score = 0f;
	private bool running = false;
	private short Counter = 0;
	private float lastTime;

	// Use this for initialization
	void Start () {
		//loads  the highscore and saves it on progress
		progress = SaveAndLoad.Load();
		
		//sends the higscore to the Menu
		Menu.StartMenu(progress);

		//sets the bulletSpeed to the default value
		bulletSpeed = BulletStartSpeed;

		//sets the spawnWait to the default value.
		spawnWait = StartspawnWait;
	}

	//when the game reset.
	public void restart() {
		//sets the plyer position to zero
		Player.position = new Vector3(0, 0 ,0);
		//hids the menu and sets the Menu to false
		Menu.hide();
		MenuGM.SetActive(false);

		//sets the running to tru and reset the timer.
		running = true;
		TG.reset();

		//sets some value to reset and start a coroutine
		spawnWait = StartspawnWait;
		lastTime = TG.getTimer();
		StartCoroutine(SpawnWaves());
		Counter = 0;
	}

	public void Exit() {
		Application.Quit();
	}

	void Update() {
		//When the game is running 
		if(running) {
			//bulletSpeed = BulletStartSpeed;

			//if the time have passed 10 secound 
			if(TG.getTimer() - lastTime > 10) {
				lastTime = TG.getTimer();
				Counter++;
				//sets the spawnWait to go faster.
				spawnWait = spawnWait - (Waitdecrece / Counter);
				
			}
		}

		//resets all the highscore
		if(Input.GetKey(KeyCode.LeftControl) && Input.GetKey(KeyCode.LeftAlt) && Input.GetKey(KeyCode.R)) {
			//progress.HighScore = 0;
			if(!running) {
				SaveAndLoad.reset();
				score = 0;
				Menu.ResethighScore("none", "0.00");
			}
		}
	}
	
	IEnumerator SpawnWaves() {
		//waits before to spawn a new
		yield return new WaitForSeconds(startWait);

		//while running spawn a bullet.
		while(running) {
			Emitter.SpawnObject();
			yield return new WaitForSeconds(spawnWait);
		}

	}


	public void gameOver() {
		if(running) {
			running = false;
			score = TG.getTimer();
			//sets the menu to true and shows the menu
			MenuGM.SetActive(true);
			Menu.show();

			Emitter.DestoyAllBullet();

			//puts the score on highscore and return the new highscore
			HighScore[] saveScore = Menu.CheckAndUpdateHighScore(score);

			//saves the score in the application
			SaveAndLoad.Save(saveScore); 		
			Debug.Log("Game Over");
		}
		
	}

	//To get values
	public float getScore {
		get { return score; }
	}

	public float GetSpeed() {
		return bulletSpeed;
	}

	public bool isRunning() {
		return running;
	}


}
