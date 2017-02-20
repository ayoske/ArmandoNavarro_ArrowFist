using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPS_Level : MonoBehaviour {

	public PlayerMotor playerMotor;
	public static FPS_Level instance;

	public Animator anim;
	int jumpHash = Animator.StringToHash("jump");
	int runHash = Animator.StringToHash("run");
	int deadHash = Animator.StringToHash("dead");
	int idleHash = Animator.StringToHash("idle");
	// Use this for initialization

	public GameObject runnerCamera;
	public GameObject fpsCamera;
	public GameObject archeryModel;
	public GameObject gunModel;

	void Start()
	{
		playerMotor = GameObject.FindWithTag ("Player").GetComponent<PlayerMotor>();
		anim = GameObject.FindWithTag("Player").GetComponent<Animator>();
		fpsCamera = GameObject.FindWithTag("FPSCamera");
		runnerCamera = GameObject.FindWithTag("RunnerCamera");
		archeryModel = GameObject.FindWithTag ("ModelArchery");
		gunModel = GameObject.FindWithTag ("GunModel");
		gunModel.SetActive(false);
		fpsCamera.SetActive (false);
	}

	void Update()
	{
		playerMotor.btnPausa ();
	}



	void OnTriggerStay(Collider info){		

		if (info.gameObject.CompareTag ("RunnerCamera")) {	
			

			Debug.Log ("entro");

			fpsCamera.SetActive (true);
			playerMotor.enabled = false;
			anim.SetTrigger (idleHash);
			archeryModel.SetActive (false);
			gunModel.SetActive (true);
			runnerCamera.SetActive (false);
			//PlayerMotor.instance.anim = 0.0f;
			//PlayerMotor.instance.jumpForce = 0;				
		} 


	}
}
