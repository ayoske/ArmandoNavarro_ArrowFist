using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceController : MonoBehaviour {

	public Camera currentCamera;
	public float force;
	RaycastHit hit;
	Ray mouseRay;


	void Start () {



	}
	
	// Update is called once per frame
	void Update () 
	{

		if(Input.GetMouseButtonDown(0))
		{ 

			mouseRay = currentCamera.ScreenPointToRay(Input.mousePosition);
			if(Physics.Raycast(mouseRay, out hit))
			{

				hit.rigidbody.AddForce(Vector3.forward * force, ForceMode.Impulse);

			}

		}

	}
}
