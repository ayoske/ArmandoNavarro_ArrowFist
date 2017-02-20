using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

	public Transform objectToGrab;
	CapsuleCollider capsuleCollider;
	Animator playerAnimator;
	AnimatorStateInfo currentState;
	bool grabObject;
	 
	void Start () 
	{

		playerAnimator = GetComponent<Animator>();
		capsuleCollider = GetComponent<CapsuleCollider>(); 
		grabObject = false;
	}
	

	void Update ()
	{

		currentState = playerAnimator.GetCurrentAnimatorStateInfo (0);

		playerAnimator.SetFloat ("speed", Input.GetAxis ("Vertical"));
		playerAnimator.SetFloat ("direction", Input.GetAxis ("Horizontal"));

		if (Input.GetKeyDown (KeyCode.Space) && currentState.IsName ("Runs"))
			playerAnimator.SetTrigger ("jump");

		if (currentState.IsName ("Jump"))
			capsuleCollider.height = playerAnimator.GetFloat ("CapsuleHeigth");
		else {
			capsuleCollider.height = 2f;
		}

		if (Input.GetKey (KeyCode.KeypadEnter))
			playerAnimator.SetTrigger ("wave");

		if (Input.GetKey (KeyCode.Q)) 
		{
			
			playerAnimator.SetTrigger("grab");

		}

		if (currentState.IsName ("Grab"))
		{
			grabObject = true;
		}
		else 
		{
			grabObject = false;
		
		}

		if (grabObject) {
			playerAnimator.SetLookAtPosition (objectToGrab.position);
			playerAnimator.SetLookAtWeight (1f, 1f, 1f, 1f, 1f);
		} else 
		{

			playerAnimator.SetLookAtWeight(0f);

		}	

		Debug.Log (GameState.instance.currentState);

		if (GameState.instance.currentState == States.GAME_OVER) 
		{
			
			playerAnimator.SetTrigger("dying");

		}


	}

	void OnAnimatorIK(int layerIndex)
	{
		if (grabObject) {
			playerAnimator.SetIKPositionWeight (AvatarIKGoal.RightHand, 1f);
			playerAnimator.SetIKPosition (AvatarIKGoal.RightHand, objectToGrab.position);
		} else {
			playerAnimator.SetIKPositionWeight (AvatarIKGoal.RightHand, 0f);
		}
	}
}
