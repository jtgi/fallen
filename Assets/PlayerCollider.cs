using UnityEngine;
using System.Collections;

public class PlayerCollider : MonoBehaviour {

	Score s;
	
	void Start() {
		//TODO we could use an eventbus instead here.
		//keeping simple for now. (famous last words)
		s = GameObject.FindGameObjectWithTag("MainScript").GetComponent<Score>();
	}

	void Update() {
	}

	void OnTriggerEnter(Collider other) {
		if(other.tag == "RingCollider") {
			DonutState donut = other.gameObject.GetComponentInParent<DonutState>();
			other.gameObject.collider.GetComponent<MeshCollider>().enabled = false;
			s.IncreasePoints(donut.points);
		}
	}
	

}
