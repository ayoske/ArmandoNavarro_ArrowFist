using UnityEngine;
using System.Collections;

// this script is attached to the arrow
//
// we have to distinguish two cases:
// - an arrow is shoot in the menu screeen
// - an arrow is shot in the game


public class arrowScript : MonoBehaviour {

	// an arrow is dependent on various influences
	// the arrow's speed
	public float velo;
	// the directed speed (velocity)
	public Vector3 InitialVelo;
	// wind speed. Since the wind can only blow from the left or right, 
	// we do not need a vector. a float is sufficient
	float windSpeed;

	// is th earrow stuck somewhere
	public bool isStuck;
	// did a collision with another game object occur
	public bool isCollisionOccured;

	// sounds in a game make it more convenient...
	public AudioClip swooshArrow;
	public AudioClip arrowHit;

	// this is the backpack cam 
	// which follows a shot arrow
	Camera arrowCam;
	// Reference to the main cam
	Camera mainCam;
	// reference to the main game object script
	GameObject gameManager;

	// Use this for initialization
	void Start () {
		// when an arrow is shot,
		// definetely no collision has occured yet
		isCollisionOccured = false;
	}



	// 
	// void shootArrow
	//
	// The player steers the bow and thus the direction of the arrow.
	// The shoot script calls this method and delivers the direction via eulerangles
	//

	public void shootArrow(Vector3 eulerangles) {
		// make sound
		GetComponent<AudioSource>().PlayOneShot (swooshArrow);
		// of course, the arrow is not stuck 
		isStuck = false;
		// add a force to the arrow (aka "shooting")
		GetComponent<Rigidbody>().AddForce (Quaternion.Euler (new Vector3 (0f, eulerangles.y-90f, 360f-eulerangles.x))*InitialVelo, ForceMode.VelocityChange);
	}



	//
	// void setCam
	// 
	// This method sets a reference to the backpack cam
	//

	public void setCam(Camera cam, bool active) {
		arrowCam = cam;
		arrowCam.enabled = active;
	}



	//
	// void setMainCam
	// 
	// This method sets a reference to the main cam
	//

	public void setMainCam(Camera cam) {
		mainCam = cam;
	}



	//
	// void setGameManager
	// 
	// This method sets a reference to the main game object script
	//

	public void setGameManager(GameObject gm) {
		gameManager = gm;
	}



	//
	// void setWindSpeed
	// 
	// This method sets the windspeed randomly calculated
	// at shoot.cs script for the current shot
	//

	public void setWindSpeed(float wind) {
		windSpeed = wind;
	}



	// Update is called once per frame
	// since we are doing physics calculations, i decided to use the 
	// FixedUpdate method
	//

	void FixedUpdate () {

		// if an arrow is stuck (in cart, terrain or the target itself)
		// disable the rigidbody by setting it to "isKinematic"
		if (isStuck) {
			if (!GetComponent<Rigidbody>().isKinematic)
				GetComponent<Rigidbody>().isKinematic = true;
			// leave the method immediately
			// (what sould be determined? the arrow is stuck anyway)
			return;
		}

		// the arrow - once released - flies an parabolic shape
		// unity's physics does a lot, but it does not adjust the projectile's direction
		// so this piece of code uses some math to match the projectile's angle
		if (GetComponent<Rigidbody>().velocity != Vector3.zero) {
			Vector3 vel = GetComponent<Rigidbody>().velocity;
			float angleZ = Mathf.Atan2(vel.y,vel.x)*Mathf.Rad2Deg;
			float angleY = Mathf.Atan2(vel.z,vel.x)*Mathf.Rad2Deg;
			transform.eulerAngles = new Vector3(0,-angleY,angleZ);
		}

		// add some wind speed to the arrow
		// in this simulstion, the wind only blows from the left and the right
		if (!isStuck)
			GetComponent<Rigidbody>().AddForce (new Vector3 (0, 0, windSpeed));

		// if we have an arrow backpack cam, adjust its position and rotation
		if (arrowCam != null) {
			arrowCam.transform.rotation = transform.rotation * Quaternion.Euler(new Vector3(10,90f,0));
			arrowCam.transform.position = transform.position + new Vector3(-2.5f, 1.3f,0f);
		}
	}


	//
	// void OnCollisionEnter(Collision otherObject)
	//
	// This method is called, if the arrow hits another gameObject
	// we check two cases: 
	// - are we in menu mode? So - has a sign been hit
	// - are we in game mode= so - which relevant gameObject has been hit
	//

	void OnCollisionEnter(Collision otherObject) {
		// did we already take note of the collision?
		// then leave the method. We don't have to waste CPU time
		if (isCollisionOccured)
			return;

		// check which game state we are in
		switch (gameManager.GetComponent<shooot> ().gameState) {
			// if we are in menu state?
			// so check for the objects Cube1 - Cube6 (the level signs)
			case  shooot.GameStates.menu:
			if (otherObject.transform.name == "Cube1") {
				// play the arrow sound
				GetComponent<AudioSource>().PlayOneShot(arrowHit);
				// set velocity to zero
				GetComponent<Rigidbody>().velocity = Vector3.zero;
				// disable the rigidbody
				GetComponent<Rigidbody>().isKinematic = true;
				transform.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;
				// the arrow is stuck
				isStuck = true;
				// and a collision occured
				isCollisionOccured = true;
				// start level 1
				StartCoroutine(setLevel(1));
			}
			else if (otherObject.transform.name == "Cube2") {
				GetComponent<AudioSource>().PlayOneShot(arrowHit);
				GetComponent<Rigidbody>().velocity = Vector3.zero;
				GetComponent<Rigidbody>().isKinematic = true;
				transform.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;
				isStuck = true;
				isCollisionOccured = true;
				StartCoroutine(setLevel(2));
			}
			else if (otherObject.transform.name == "Cube3") {
				GetComponent<AudioSource>().PlayOneShot(arrowHit);
				GetComponent<Rigidbody>().velocity = Vector3.zero;
				GetComponent<Rigidbody>().isKinematic = true;
				transform.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;
				isStuck = true;
				isCollisionOccured = true;
				StartCoroutine(setLevel(3));
			}
			else if (otherObject.transform.name == "Cube4") {
				GetComponent<AudioSource>().PlayOneShot(arrowHit);
				GetComponent<Rigidbody>().velocity = Vector3.zero;
				GetComponent<Rigidbody>().isKinematic = true;
				transform.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;
				isStuck = true;
				isCollisionOccured = true;
				StartCoroutine(setLevel(4));
			}
			else if (otherObject.transform.name == "Cube5") {
				GetComponent<AudioSource>().PlayOneShot(arrowHit);
				GetComponent<Rigidbody>().velocity = Vector3.zero;
				GetComponent<Rigidbody>().isKinematic = true;
				transform.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;
				isStuck = true;
				isCollisionOccured = true;
				StartCoroutine(setLevel(5));
			}
			else if (otherObject.transform.name == "Cube6") {
				GetComponent<AudioSource>().PlayOneShot(arrowHit);
				GetComponent<Rigidbody>().velocity = Vector3.zero;
				GetComponent<Rigidbody>().isKinematic = true;
				transform.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;
				isStuck = true;
				isCollisionOccured = true;
				StartCoroutine(setLevel(6));
			}
			// for every other object in the scene - give the player another chance to choose a level
			// since no other object has a collider, the arrow will hit the terrain or the levelCollider in any case
			else if (otherObject.transform.name == "Terrain" ||
			         otherObject.transform.name == "levelCollider"){
				GetComponent<Rigidbody>().velocity = Vector3.zero;
				GetComponent<Rigidbody>().isKinematic = true;
				transform.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;
				isStuck = true;
				isCollisionOccured = true;
				StartCoroutine("chooseAgain");
			}
			break;

			// so, the other game state is the game itself
			case shooot.GameStates.game:
				// the player hit the target
				if (otherObject.transform.name == "Target") {
					GetComponent<AudioSource>().PlayOneShot(arrowHit);
					GetComponent<Rigidbody>().velocity = Vector3.zero;
					GetComponent<Rigidbody>().isKinematic = true;
					transform.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;
					isStuck = true;
					isCollisionOccured = true;
					// wait three seconds and go ahead
					// the score evalutation takes place in the script "targetHit.cs"
					StartCoroutine("waitThree");
				}
				
				// the terrein shoukd always be checked
				if (otherObject.transform.name == "Terrain") {
					GetComponent<Rigidbody>().velocity = Vector3.zero;
					GetComponent<Rigidbody>().isKinematic = true;
					transform.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;
					isStuck = true;
					GameObject rt = (GameObject)Instantiate(gameManager.GetComponent<shooot>().risingText, arrowCam.transform.position+new Vector3(5,-3,3),arrowCam.transform.rotation);
					// show the player he missed the target
					rt.transform.name = "rt";
					rt.GetComponent<TextMesh>().text="Missed. 0 Points";
					isCollisionOccured = true;
					// wait three seconds and go ahead
					StartCoroutine("waitThree");
				}
				
				// I thought, to check the cart would be funny
				if (otherObject.transform.name == "cart") {
					GetComponent<AudioSource>().PlayOneShot(arrowHit);
					GetComponent<Rigidbody>().velocity = Vector3.zero;
					transform.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;
					isStuck = true;
					GameObject rt = (GameObject)Instantiate(gameManager.GetComponent<shooot>().risingText, arrowCam.transform.position+new Vector3(0,-3,3),arrowCam.transform.rotation);
					rt.transform.name = "rt";
					// show the player he missed the target
					rt.GetComponent<TextMesh>().text="Missed. 0 Points";
					isCollisionOccured = true;
					// wait three seconds an go ahead
					StartCoroutine("waitThree");
				}
			break;
		}

	}



	//
	// IEnumerator setLevel
	//
	// this method is called if the player hits one of the level signs
	//

	IEnumerator setLevel(int level) {
		// wait for one second
		yield return new WaitForSeconds(1);
		// reset the main camera properties
		mainCam.fieldOfView = 60;
		mainCam.transform.localEulerAngles = new Vector3 (0, 90, 0);
		mainCam.enabled = true;
		arrowCam.enabled = false;
		// call the main game script
		// shooting is allowed
		// and set level has to be set
		gameManager.GetComponent<shooot> ().Shooting (false);
		gameManager.GetComponent<shooot> ().setLevel (level);
		// stop the coroutine, we do not need it anymore
		StopCoroutine("setLevel");
	}



	//
	// IEnumerator chooseAgain
	//
	// do nothing, the player has to shoot again
	//

	IEnumerator chooseAgain() {
		yield return new WaitForSeconds(3);
		gameManager.GetComponent<shooot> ().Shooting (false);
		// stop the coroutine, we do not need it anymore
		StopCoroutine("chooseAgain");
	}



	//
	// IEnumerator waitThree
	//
	// This method is called if the player hit something
	//

	IEnumerator waitThree() {
		// wait for three seconds
		yield return new WaitForSeconds(3);
		mainCam.fieldOfView = 60;
		mainCam.transform.localEulerAngles = new Vector3 (0, 90, 0);
		mainCam.enabled = true;
		arrowCam.enabled = false;
		// call the main script
		// The player may shoot again
		// and the next arrow is set up
		gameManager.GetComponent<shooot> ().Shooting (false);
		gameManager.GetComponent<shooot> ().nextArrow ();
		// stop the coroutine, we do not need it anymore
		StopCoroutine("waitThree");
	}
}
