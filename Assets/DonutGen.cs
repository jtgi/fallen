using UnityEngine;
using System.Collections;

public class DonutGen : MonoBehaviour {

	public GameObject donut;

	public float donutDrawDistance = 1000f;
	public float donutDrawFrequencyDistance = 100f;
	public int startSpace = 3;
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

	public void initDonuts() {
		for(float depth = donutDrawFrequencyDistance * startSpace; 
		    depth < donutDrawDistance; 
		    depth += donutDrawFrequencyDistance) {
			
			GenerateDonutAtDepth(-depth);
		}
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
		float depth = player.transform.position.y - donutDrawDistance;
		GenerateDonutAtDepth(depth);
	}

	void GenerateDonutAtDepth(float depth) {
		float xPos = gameObject.transform.position.x - Random.Range (-maxDonutXPos, maxDonutXPos);
		float zPos = gameObject.transform.position.z - Random.Range (-maxDonutZPos, maxDonutZPos);
		float yPos = depth;
		
		Vector3 donutPos = new Vector3(xPos, yPos, zPos);
		
		Instantiate(donut, donutPos, Quaternion.identity);
	}

	private bool randomBool() {
		return Random.value >= 0.5f;
	}
}
