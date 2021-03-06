﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Score : MonoBehaviour {


	public Text lifeDisplay;
	public Text pointDisplay;
	public Text statsDisplay;
	public Text gameOverDisplay;
	public Button playAgain;

	public int defaultLives = 5;

	private int donutsSurvived;
	private float points;
	private bool gameOver = false;

	private string pointDisplayPrefixText = "SCORE";
	private string lifeDisplayPrefixText = "LIVES";
	private string newHighScoreText = "HIGH SCORE!";
	private string gameOverTextDefault = "GAME OVER";
	private string gameOverText = "GAME OVER";

	private GameObject gameOverGui;
	private GameObject inGameGui;
	private GameObject respawnPosition;

	private DonutGen donutGen;
	private OVRPlayerController playerController;
	private int lives;
	private float gravitySetting;


	void Start () {
		points = 0;
		donutsSurvived = 0;

		playerController = GameObject.FindWithTag("Player").GetComponent<OVRPlayerController>();
		respawnPosition = GameObject.Find("Respawn");
		donutGen = GameObject.FindGameObjectWithTag("MainScript").GetComponent<DonutGen>();
		gravitySetting = playerController.GravityModifier;

		initGame();
	}

	void Update() {
		if(gameOver) {
			if(OVRGamepadController.GPC_GetButton(OVRGamepadController.Button.A) || Input.GetKeyDown(KeyCode.Space)) {
				Respawn();
			}
		}
	}

	void initGame() {
		lives = defaultLives;
		points = 0;

		lifeDisplay.text = lifeDisplayPrefixText + " "  + lives;
		pointDisplay.text = pointDisplayPrefixText + " " + points;

		gameOverGui = GameObject.Find ("GameOverGUI");
		inGameGui = GameObject.Find ("InGameGUI");

		gameOverGui.SetActive(false);
		inGameGui.SetActive(true);

		gameOver = false;

		playerController.SetHaltUpdateMovement(false);
		playerController.GravityModifier = gravitySetting;

		donutGen.initDonuts();
	}

	public void IncreasePoints(float p) {
		if(gameOver) return;

		donutsSurvived++;

		points += p;
		pointDisplay.text = pointDisplayPrefixText + " " + points;
	}

	public void decreaseLife() {
		if(gameOver) return;

		lives--;

		lifeDisplay.text = lifeDisplayPrefixText + " " + lives;

		if(lives <= 0) {
			GameOver();
		}
	}

	public void GameOver() {
		float highScore = PlayerPrefs.GetFloat("highScore");
		bool newHighScore = highScore < points;

		if(newHighScore) {
			PlayerPrefs.SetFloat("highScore", points);
			PlayerPrefs.Save();
			gameOverText = newHighScoreText;
		} else {
			gameOverText = gameOverTextDefault;
		}

		statsDisplay.text = string.Format ("HIGH SCORE {0}", PlayerPrefs.GetFloat("highScore"));
		gameOverDisplay.text = gameOverText;
		
		playerController.SetHaltUpdateMovement(true);
		playerController.GravityModifier = 0;
		gameOverGui.SetActive(true);
		gameOver = true;
	}
	
	void Respawn() {
		GameObject[] rings = GameObject.FindGameObjectsWithTag("RingWrap");
		foreach(GameObject ring in rings) {
			Destroy(ring);
		}

		playerController.transform.position = respawnPosition.transform.position;
		initGame();
	}
}
