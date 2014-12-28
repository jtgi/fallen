using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Score : MonoBehaviour {


	public Text lifeDisplay;
	public Text pointDisplay;
	public Text statsDisplay;
	public Text gameOverDisplay;
	public Button playAgain;

	public int lives = 5;

	private int donutsSurvived;
	private float points;
	private bool gameOver = false;

	private string pointDisplayPrefixText = "SCORE";
	private string lifeDisplayPrefixText = "LIVES";
	private string newHighScoreText = "NEW HIGH SCORE!";
	private string gameOverText = "GAME OVER";

	private GameObject gameOverGui;
	private GameObject inGameGui;
	private GameObject centerEyeAnchor;
	private OVRPlayerController playerController;

	void Start () {
		points = 0;
		donutsSurvived = 0;
		playerController = GameObject.FindWithTag("Player").GetComponent<OVRPlayerController>();
		initGUI();
	}

	void Update() {
		if(gameOver) {
			if(OVRGamepadController.GPC_GetButton(OVRGamepadController.Button.A) || Input.GetKeyDown(KeyCode.Space)) {
				Respawn();
			}
		}
	}

	void initGUI() {
		lifeDisplay.text = lifeDisplayPrefixText + " "  + lives;
		pointDisplay.text = pointDisplayPrefixText + " " + points;

		gameOverGui = GameObject.Find ("GameOverGUI");
		inGameGui = GameObject.Find ("InGameGUI");
		centerEyeAnchor = GameObject.Find ("CenterEyeAnchor");

		gameOverGui.SetActive(false);
		inGameGui.SetActive(true);
		gameOver = false;
		playerController.SetHaltUpdateMovement(false);

		playAgain.onClick.AddListener(() => { Respawn(); });
	}

	public void IncreasePoints(float p) {
		donutsSurvived++; //TODO: move this

		points += p;
		pointDisplay.text = pointDisplayPrefixText + " " + points;
		Debug.Log ("Points increased by " + p + ". Total: " + points);
	}

	public void decreaseLife() {
		Debug.Log ("Decrease Life");
		lives--;

		lifeDisplay.text = lifeDisplayPrefixText + " " + lives;

		if(lives <= 0) {
			GameOver();
		}
	}

	public void GameOver() {
		Debug.Log("Game Over. Points: " + points + ", Donuts Survived: " + donutsSurvived);
		float highScore = PlayerPrefs.GetFloat("highScore");
		bool newHighScore = highScore < points;

		if(newHighScore) {
			PlayerPrefs.SetFloat("highScore", points);
			PlayerPrefs.Save();
			gameOverText = "NEW HIGH SCORE!";
		} else {
			gameOverText = "GAME OVER";
		}

		statsDisplay.text = string.Format ("HIGH SCORE {0}", PlayerPrefs.GetFloat("highScore"));
		
		playerController.SetHaltUpdateMovement(true);
		gameOverGui.SetActive(true);
		gameOver = true;
	}
	
	void Respawn() {
		Debug.Log("Respawn clicked");	
	}
}
