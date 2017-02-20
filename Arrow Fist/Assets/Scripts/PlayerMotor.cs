using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour {
	
	public static PlayerMotor instance;

	public FPS_Level fpsLevel;

	// Variables Componentes 

	private CharacterController controller;
	public Touch currentTouch;
	private Vector3 moveVector;

	//variable velocidad
	public float speed = 5.0f;

	//variables jump()
	private float verticalVelocity;
	public float jumpForce = 10.0f;
	public float gravity = 14.0f;
	AudioClip jumpFX;

	//variables Animacion
	public Animator anim;
	int jumpHash = Animator.StringToHash("jump");
	int runHash = Animator.StringToHash("run");
	int deadHash = Animator.StringToHash("dead");
	AnimatorStateInfo currentState;

	void Start () 
	{
		
		controller = GetComponent<CharacterController> ();
		anim = GetComponent<Animator>();  
		fpsLevel.fpsCamera.SetActive (false);

	}
	

	void Update () 
	{
		
		moveVector = Vector3.zero;

		playerLive();

		playerDied();

		controller.Move (moveVector * Time.deltaTime);

		btnPausa ();

	}

	void playerLive()
	{

		if (Health.instance.healthcount > 0) 
		{
			//Eje x Izquierda Derecha
			//moveTouch();
			moveKey();

			//Eje z Adelante - Atras
			moveVector.z = speed;

			//Eje y
			Jump ();
		}
	}

	void Jump()
	{		
		if (controller.isGrounded) 
		{
			
			moveVector.y = -gravity * Time.deltaTime;
			Debug.Log ("hola suelo");

			//if (Input.touchCount == 2) {
			if(Input.GetKey(KeyCode.Space))	{
				verticalVelocity = jumpForce;
				anim.SetTrigger (jumpHash);
				transform.GetComponent<AudioSource> ().PlayOneShot (jumpFX);
			} 
			else 
			{
				anim.ResetTrigger(jumpHash);
				anim.SetTrigger (runHash);
			}
		}
		else
		{
			verticalVelocity -= gravity * Time.deltaTime;
			Debug.Log ("adios suelo");
		}
		moveVector.y =  verticalVelocity;
		controller.Move (moveVector * Time.deltaTime);
	}

	void moveTouch()
	{
		if (Input.touchCount == 1) {

			currentTouch = Input.GetTouch (0);
			if (currentTouch.position.x < Screen.width * 0.5f) {

				transform.Translate (Vector3.left * 1.0f);
			}
			else
			{
				transform.Translate (Vector3.right * 1.0f);
			}
		}
	}

	void moveKey()
	{		
		if (Input.GetKey(KeyCode.A)) 
		{
			transform.Translate (Vector3.left * .5f);
			//controller.Move(moveVector.x * .5f);
		}
		if(Input.GetKey(KeyCode.D))
		{
			transform.Translate (Vector3.right * .5f);
		}
	}

	void playerDied()
	{
		if (Health.instance.healthcount <= 0) 
		{
			speed = 0.0f;
			anim.SetTrigger(deadHash);
			jumpForce = 0.0f;
			//GameState.instance.gameOver += DiedEvent;
		}
	}

	public void btnPausa()
	{
		if(Input.GetKeyDown(KeyCode.Escape))
		{
			GameState.instance.ChangeState (States.PAUSE);		
		}
	}
}
