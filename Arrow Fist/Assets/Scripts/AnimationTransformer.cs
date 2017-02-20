using UnityEngine;
using System.Collections;

public class AnimationTransformer : MonoBehaviour {

	public float duration;
	public Vector3 endPosition;
	public Vector3	endRotation;

	Quaternion startRotation;
	Vector3 startPosition;
	float startTime;

	void Start()
	{
		startPosition = transform.position;
		startRotation = transform.rotation;
		startTime = Time.time;

	}

	void Update()
	{
		//transform.position = Vector3.Lerp (startPosition,
		//								   endPosition,
		//	 							   (Time.time - startTime)/duration);

		transform.rotation = Quaternion.Lerp (startRotation,
											   Quaternion.Euler(endRotation),
											  (Time.time - startTime)/duration);
	}


}
