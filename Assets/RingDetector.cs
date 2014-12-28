using UnityEngine;
using System.Collections;

public class RingDetector : MonoBehaviour {
	public LayerMask layerMask; //make sure we aren't in this layer 
	public float skinWidth = 0.1f; //probably doesn't need to be changed 
	
	private float minimumExtent; 
	private float partialExtent; 
	private float sqrMinimumExtent; 
	private Vector3 previousPosition; 
	private GameObject myGameObj; 
	
	
	//initialize values 
	void Awake() { 
		myGameObj = gameObject; 
		previousPosition = myGameObj.transform.position; 
		minimumExtent = Mathf.Min(Mathf.Min(collider.bounds.extents.x, collider.bounds.extents.y), collider.bounds.extents.z); 
		partialExtent = minimumExtent * (1.0f - skinWidth); 
		sqrMinimumExtent = minimumExtent * minimumExtent; 
	} 
	
	void FixedUpdate() 
	{ 
		//have we moved more than our minimum extent? 
		Vector3 movementThisStep = myGameObj.transform.position - previousPosition; 
		float movementSqrMagnitude = movementThisStep.sqrMagnitude;
		
		if (movementSqrMagnitude > sqrMinimumExtent) 
		{ 
			float movementMagnitude = Mathf.Sqrt(movementSqrMagnitude);
			RaycastHit hitInfo; 
			//check for obstructions we might have missed 
			if (Physics.Raycast(previousPosition, movementThisStep, out hitInfo, movementMagnitude, layerMask.value)) {
				myGameObj.transform.position = hitInfo.point - (movementThisStep/movementMagnitude)*partialExtent; 
			}

			Debug.Log(hitInfo);

		} 
		
		previousPosition = myGameObj.transform.position; 
	}
}
