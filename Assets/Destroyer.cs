using UnityEngine;
using System.Collections;

public class Destroyer : MonoBehaviour {

	void OnTriggerEnter(Collider other) {
		if(other.gameObject.transform.parent) {
			Debug.Log ("Destroying " + other.gameObject.transform.parent.gameObject.name);
			Destroy(other.gameObject.transform.parent.gameObject);
		} else {
			Debug.Log ("Destroying " + other.gameObject.transform.parent.gameObject.name);
			Destroy (other.gameObject);
		}
	}
}
