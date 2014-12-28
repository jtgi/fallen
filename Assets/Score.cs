using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Score : MonoBehaviour {


	public Text pointDisplay;
	private float points;
	private string pointDisplayPrefixText = "Score";

	void Start () {
		points = 0;
	}

	public void IncreasePoints(float p) {
		points += p;
		pointDisplay.text = pointDisplayPrefixText + " " + points;
		Debug.Log ("Points increased by " + p + ". Total: " + points);
	}

}
