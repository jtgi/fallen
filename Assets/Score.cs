using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Score : MonoBehaviour {


	public Text lifeDisplay;
	public Text pointDisplay;
	public int lives = 5;

	private int donutsSurvived;
	private float points;
	private string pointDisplayPrefixText = "SCORE";
	private string lifeDisplayPrefixText = "LIVES";

	void Start () {
		points = 0;
		donutsSurvived = 0;
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
		//TODO: Show GUI here.
	}
}
