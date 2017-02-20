using UnityEngine;
using System.Collections;

public class Practica : MonoBehaviour {

	public float duration;
	public Vector3 endPosition;
	public Vector3	endRotation;

	Quaternion startRotation;
	Vector3 startPosition;
	Vector3 posicionx;
	float startTime;

	void Start () 
	{
		startPosition = transform.localPosition;
		startRotation = transform.rotation;
		startTime = Time.time;
	}
	

	void Update () 
	{
		
		transform.localPosition = Vector3.Lerp (startPosition,
											   endPosition,
				 							   (Time.time - startTime)/duration);
		

		if (Time.time-startTime >= duration ) {
			startTime = Time.time;
			posicionx = endPosition;
			endPosition = startPosition;
			startPosition = posicionx;

		}


	}
}


//		transform.rotation = Quaternion.Lerp (startRotation,
//			Quaternion.Euler(endRotation),
//			(Time.time - startTime)/duration);
