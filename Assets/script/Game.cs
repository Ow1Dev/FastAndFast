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
		//SaveAndLoad.reset();

		progress = SaveAndLoad.Load();

		//Debug.Log(progress[1].name);

		Menu.StartMenu(progress);
		bulletSpeed = BulletStartSpeed;
		spawnWait = StartspawnWait;
	}

	public void restart() {
		Player.position = new Vector3(0, 0 ,0);
		Menu.hide();
		MenuGM.SetActive(false);
		running = true;
		TG.reset();
		spawnWait = StartspawnWait;
		lastTime = TG.getTimer();
		StartCoroutine(SpawnWaves());
		Counter = 0;
	}

	public void Exit() {
		Application.Quit();
	}

	void Update() {
		if(running) {
			bulletSpeed = BulletStartSpeed;
			if(TG.getTimer() - lastTime > 10) {
				lastTime = TG.getTimer();
				Counter++;
				spawnWait = spawnWait - (Waitdecrece / Counter);
				
			}
		} else {

		}

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
		yield return new WaitForSeconds(startWait);

		while(running) {
			Emitter.SpawnObject();
			yield return new WaitForSeconds(spawnWait);
		}

	}


	public void gameOver() {
		if(running) {
			running = false;
			score = TG.getTimer();
			MenuGM.SetActive(true);
			Menu.show();

			Emitter.DestoyAllBullet();

			HighScore[] saveScore = Menu.CheckAndUpdateHighScore(score, progress);

			SaveAndLoad.Save(saveScore); 		
			Debug.Log("Game Over");
		}
		
	}

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
