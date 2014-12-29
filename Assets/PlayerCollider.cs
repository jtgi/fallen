using UnityEngine;
using System.Collections;

public class PlayerCollider : MonoBehaviour {
	
	public AudioSource donutSuccessSound;
	
	Score s;
	private long consecutiveDonuts = 1;
	
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
			if(!donut.used) {
				s.IncreasePoints(donut.points);
				playSuccessSound();
				donut.used = true;
			}
		} 
	}
	
	void playSuccessSound() {
		consecutiveDonuts++;
		donutSuccessSound.pitch += 0.001f;
		donutSuccessSound.Play();
	}
	
	void OnControllerColliderHit(ControllerColliderHit hit) {
		if(hit.gameObject.tag == "Ring") {
			DonutState donut = hit.gameObject.GetComponentInParent<DonutState>();
			if(!donut.used) {
				s.decreaseLife();
				consecutiveDonuts = 1;
				donutSuccessSound.pitch = 1;
				donut.used = true;
				donut.DisplayMiss();
			}
		}
	}
	
	
}
