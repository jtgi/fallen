using UnityEngine;
using System.Collections;

public class DonutGen : MonoBehaviour {

	public GameObject donut;
	public float minDistanceUntilGenDonut = 50f;
	public float maxDistanceUntilGenDonut = 75f;
	public float donutCreateOffset = 100f;

	float distUntilNextDonut;
	Vector3 lastPos = Vector3.zero;

	void Start () {
		lastPos = gameObject.transform.position;
		distUntilNextDonut = Random.Range (minDistanceUntilGenDonut, maxDistanceUntilGenDonut);
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 currentPos = gameObject.transform.position;
		distUntilNextDonut -= Mathf.Abs(currentPos.y - lastPos.y);

		if(distUntilNextDonut <= 0) {
			GenerateDonut();
			distUntilNextDonut = Random.Range(minDistanceUntilGenDonut, maxDistanceUntilGenDonut);
		}

		lastPos = currentPos;
	}

	void GenerateDonut() {
		Transform currentTrans = gameObject.transform;
		Vector3 donutPos = new Vector3(currentTrans.position.x, currentTrans.position.y + donutCreateOffset, currentTrans.position.z);
		Instantiate(donut, donutPos, Quaternion.identity);
	}
}
