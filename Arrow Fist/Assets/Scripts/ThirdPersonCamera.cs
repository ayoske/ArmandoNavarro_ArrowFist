using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour {

	public Transform target;
	public float smooth = 0.3f;
	public float distance = 5.0f;
	public float height = 2.0f;

	private float yVelocity = 0f;

	void Update () 
	{

		float yAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y, 
											 target.eulerAngles.y,
											 ref yVelocity,
											 smooth);

		Vector3 position = target.position;
		position += Quaternion.Euler(0,yAngle,0) * new Vector3(0f,height,-distance);
		transform.position = position;
		transform.LookAt(target);
		
	}
}
