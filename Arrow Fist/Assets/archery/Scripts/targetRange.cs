using UnityEngine;
using System.Collections;

// Target Range is a Sphere Trigger around the target
// This script is attached to the targetRange Game Object
//
// When an arrow crosses it, the main camera switches to target cam
//

public class targetRange : MonoBehaviour {

	// Reference to the main cam
	public Camera mainCam;
	// Reference to the arrow backpack cam
	public Camera arrowCam;
	// Reference to the targeting cam
	public Camera targetCam;
	// Reference to the game Manager main object
	public GameObject gameManager;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}



	//
	// void OnTriggerEnter
	//
	// the collider of object targetRange is set to Trigger,
	// so OnTriggerEnter instead of OnCollisionEnter is called
	//

	void OnTriggerEnter(Collider other) {
		// if an arrow crosses the Trigger sphere...
		if (other.transform.name == "Arrow") {
			// the cameras are switched, so the targeting cam is active
			mainCam.enabled = false;
			arrowCam.enabled = false;
			targetCam.enabled = true;
			// after some seconds, the camera must be switched back to main cam
			// this is done via a Coroutine
			StartCoroutine("switchCamera");
		}
	}



	//
	// IENumerator switchCamera
	//
	// This method resets the camera view to main cam after three seconds
	// and tells the gameManager that the next arrow is ready
	//

	IEnumerator switchCamera() {
		// wait for three seconds
		yield return new WaitForSeconds(3);
		// reset main cam properties
		mainCam.fieldOfView = 60;
		mainCam.transform.localEulerAngles = new Vector3 (0, 90, 0);
		mainCam.enabled = true;
		// set other cameras to false
		arrowCam.enabled = false;
		targetCam.enabled = false;
		// call game Manager an tell the ext arrow can be shot
		gameManager.GetComponent<shooot> ().Shooting (false);
		// to stop this method from being called periodically,
		// stop the Couroutine
		StopCoroutine("switchCamera");
	}

}
