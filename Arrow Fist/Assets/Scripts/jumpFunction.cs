using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpFunction : MonoBehaviour {

	private float verticalVelocity;
	private float gravity = 14.0f;
	private float jumpForce = 10.0f;
	private CharacterController controller;

	void Start () 
	{
		controller = GetComponent<CharacterController> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (controller.isGrounded) {

			verticalVelocity = - gravity * Time.deltaTime;
			if (Input.GetKey (KeyCode.Space)) {
				verticalVelocity = jumpForce;
				Debug.Log ("hola");
			}
		}
		else
		{
			verticalVelocity -= gravity * Time.deltaTime;
		}
	}	

}
