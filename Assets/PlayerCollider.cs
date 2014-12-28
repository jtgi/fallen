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

	/*
	 * These functions should live in donut.
	 * Originally moved here to survive a work around
	 * for fast moving objects and collision detection.
	 */
	void OnTriggerEnter(Collider other) {
		if(other.tag == "RingCollider") {
			DonutState donut = other.gameObject.GetComponentInParent<DonutState>();
			other.gameObject.collider.GetComponent<MeshCollider>().enabled = false;
			s.IncreasePoints(donut.points);
		} 
	}

	void OnControllerColliderHit(ControllerColliderHit hit) {
		if(hit.gameObject.tag == "Ring") {
			DonutState donut = hit.gameObject.GetComponentInParent<DonutState>();
			if(!donut.decreaseLifeUsed) {
				s.decreaseLife();
				donut.decreaseLifeUsed = true;
				donut.DisplayMiss();
			}
		}
	}
	

}
