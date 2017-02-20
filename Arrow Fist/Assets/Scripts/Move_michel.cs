//using UnityEngine;
//using System.Collections;
//using System;
//
//public class Move_michel : MonoBehaviour {
//
//	public float speed;
//	public float speedJump;
//	public float downSpeed;
//
//	CharacterController characterController;
//	bool firstJump;
//	Vector3 movementVector; 
//
//	// Use this for initialization
//	void Start () {
//	
//		characterController = GetComponent<CharacterController> ();
//
//	}
//	
//	// Update is called once per frame
//	void Update () {
//	
//		movementVector = Vector3.zero;
//
//		calculaTraslacion();
//
//		ApplyGravity();
//
//		if (Input.GetKeyDown (KeyCode.Space)) 
//		{
//			Jump ();
//		}
//				
//
//		characterController.Move (transform.TransformDirection (movementVector));
//	}
//
//		public void calculaTraslacion(){
//			
//		movementVector.z = Input.GetAxis ("Vertical") * speed;
//		movementVector.x = Input.GetAxis ("Horizontal") * speed;
//
//		}
//
//	void Jump()
//	{
//		if (characterController.isGrounded) 
//		{
//			if (!firstJump) {
//				firstJump = true;
//				movementVector.y += speedJump;
//			}
//		} else 
//		{
//			if (firstJump) 
//			{
//				firstJump = false;
//				movementVector.y = +speedJump;
//
//			}
//		}
//	}
//
//	void ApplyGravity()
//	{
//		if (character.isGrounded)
//			firstJump = false;
//		movimiento += Physics.gravity * downSpeed;
//	}
//
//}

using UnityEngine;
using System.Collections;

public class Move_michel : MonoBehaviour {

	public float velocidad;
	CharacterController character;
	Vector3 movimiento;

	public float speedJump;
	public float speed;
	public float downSpeed;
	bool firstJump;
	public float yRotation;
	public float xRotation;
	public float speedRotation;







	// Use this for initialization
	void Start () {
		firstJump = false;
		character = GetComponent<CharacterController>();

		yRotation = transform.localEulerAngles.x;

	}






	// Update is called once per frame
	void Update() {


		movimiento = Vector3.zero;

		calculaTraslacion();
		ApplyGravity();

		if (Input.GetKeyDown (KeyCode.Space)) {
			Jump ();
		}

		character.Move(transform.TransformDirection(movimiento));

		yRotation += speedRotation * Time.deltaTime * Input.GetAxis("Mouse X");

		transform.localEulerAngles = new Vector3(xRotation, yRotation, 0);

		transform.parent.localEulerAngles = new Vector3(0, yRotation, 0);


	}


	public void calculaTraslacion()
	{
		movimiento.z = Input.GetAxis("Vertical") * velocidad;
		movimiento.x = Input.GetAxis("Horizontal") * velocidad;
	}

	void ApplyGravity()
	{
		if (character.isGrounded)
			firstJump = false;
		movimiento += Physics.gravity * downSpeed;
	}

	void Jump()
	{
		if (character.isGrounded)
		{
			if (!firstJump)
			{
				firstJump = true;
				movimiento.y += speedJump;
			}
		}
		else
		{
			if (firstJump)
			{
				firstJump = false;
				movimiento.y = +speedJump;
			}
		}
	}
}