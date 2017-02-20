using UnityEngine;
using System.Collections;

// This script is attached to the target itself
// It calculates the score is case the target is been hit

public class targetHit : MonoBehaviour {

	// Reference to the rising text which is displayed is arrow hits target
	public GameObject risingText;
	// Reference to main Game Object to manage score
	public GameObject gameManager;


	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}



	//
	// void OnCollisionEnter
	//
	// this method is called if "something" hits the target
	// this can only be an arrow
	//

	void OnCollisionEnter(Collision other) {
		// needed to calculate the score
		float wurzel = 0;
		if (other.gameObject.name == "Arrow") {
			// we do not only need the fact an arrow hit the target - 
			// we have to determine, where the collision took place
			// unity offers the concept of contact points which help to determine the collision coordinates
			foreach (ContactPoint contact in other.contacts) {
				// now calculate the distance to the target's center via pythagoras' theorem
				// (the center of the target is at y=1.3537f above the ground, so we have to take this fact into account)
				wurzel = Mathf.Sqrt((contact.point.y-1.3537f)*(contact.point.y-1.3537f)+contact.point.z*contact.point.z); 
			}
			// Instantiate the rising text for scoring display
			GameObject rt = (GameObject)Instantiate(risingText, new Vector3(0,0,0),Quaternion.identity);
			rt.transform.name = "rt";
			// each target's "ring" is 0.07f wide
			// so it's relatively simple to calculate the ring hit (thus the score)
			rt.GetComponent<TextMesh>().text=(10-(int)(wurzel/0.07f)) + " Points";
			// set the score in the main Game Script
			gameManager.GetComponent<shooot>().setPoints((10-(int)(wurzel/0.07f)));
		}
	}

}
