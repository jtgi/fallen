using UnityEngine;
using System.Collections;

public class DonutGen : MonoBehaviour {

	public GameObject donut;

	public float donutDrawDistance = 1000f;
	public float donutDrawFrequencyDistance = 50f;
	public float maxDonutXPos = 2f;
	public float maxDonutZPos = 2f;

	float points;
	float distUntilNextDonut;
	Vector3 lastPos = Vector3.zero;
	GameObject player;

	void Start () {
		lastPos = gameObject.transform.position;
		distUntilNextDonut = donutDrawFrequencyDistance;
		player = GameObject.FindGameObjectWithTag("Player");
	}
	
	void Update () {
		Vector3 playerPos = player.transform.position;
		distUntilNextDonut -= Mathf.Abs(playerPos.y - lastPos.y);

		if(distUntilNextDonut <= 0) {
			GenerateDonut();
			distUntilNextDonut = donutDrawFrequencyDistance;
		}

		lastPos = playerPos;
	}

	void GenerateDonut() {
		float xPos = gameObject.transform.position.x - Random.Range (-maxDonutXPos, maxDonutXPos);
		float zPos = gameObject.transform.position.z - Random.Range (-maxDonutZPos, maxDonutZPos);
		float yPos = player.transform.position.y - donutDrawDistance;

		Vector3 donutPos = new Vector3(xPos, yPos, zPos);

		Instantiate(donut, donutPos, Quaternion.identity);
	}

	private bool randomBool() {
		return Random.value >= 0.5f;
	}
}
