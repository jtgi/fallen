using UnityEngine;
using System.Collections;

public class DonutState : MonoBehaviour {

	public float points = 10f;
	public bool decreaseLifeUsed = false;

	public void DisplayMiss() {
		gameObject.GetComponentInChildren<ParticleSystem>().enableEmission = false;
	}
}
