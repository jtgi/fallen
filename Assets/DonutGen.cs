using UnityEngine;
using System.Collections;

public class DonutGen : MonoBehaviour {

	public GameObject donut;
	public float donutDrawDistance = 100f;
	public float maxDonutXPos = 2f;
	public float maxDonutZPos = 2f;

	float distUntilNextDonut;
	Vector3 lastPos = Vector3.zero;

	void Start () {
		lastPos = gameObject.transform.position;
		distUntilNextDonut = donutDrawDistance;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 currentPos = gameObject.transform.position;
		distUntilNextDonut -= Mathf.Abs(currentPos.y - lastPos.y);

		if(distUntilNextDonut <= 0) {
			GenerateDonut();
			distUntilNextDonut = donutDrawDistance;
		}

		lastPos = currentPos;
	}

	void GenerateDonut() {
		Transform currentTrans = gameObject.transform;

		float xPos = currentTrans.position.x - Random.Range (-maxDonutXPos, maxDonutXPos);
		float zPos = currentTrans.position.z - Random.Range (-maxDonutZPos, maxDonutZPos);
		float yPos = currentTrans.position.y - donutDrawDistance;

		Vector3 donutPos = new Vector3(xPos, yPos, zPos);

		Instantiate(donut, donutPos, Quaternion.identity);
	}

	private bool randomBool() {
		return Random.value >= 0.5f;
	}
}
