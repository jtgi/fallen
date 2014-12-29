using UnityEngine;
using System.Collections;

public class Destroyer : MonoBehaviour {

	void OnTriggerEnter(Collider other) {
		Debug.Log(other.tag);
		if(other.tag.Equals("RingCollider")) {
//		if(other.gameObject.transform.parent) {
//			Destroy(other.gameObject.transform.parent.gameObject);
//		} else {
			Destroy (other.gameObject.transform.parent.gameObject);
		//}
		}
	}
}
