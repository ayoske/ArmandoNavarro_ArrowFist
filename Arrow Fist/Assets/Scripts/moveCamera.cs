using UnityEngine;
using System.Collections;

public class moveCamera : MonoBehaviour {


	float yRotation;
	public float xRotation;
	public float speedRotation;
	public float minX;
	public float maxX;

	// Use this for initialization

	void Start () {

		//yRotation = transform.localEulerAngles.x;
		xRotation = transform.localEulerAngles.y;
			}



	// Update is called once per frame

	void Update () {




		//yRotation += speedRotation * Time.deltaTime * Input.GetAxis("Mouse X");

		xRotation -= speedRotation * Time.deltaTime * Input.GetAxis("Mouse Y");

		//xRotation = Mathf.Clamp(xRotation, minX, maxX);


		transform.localEulerAngles = new Vector3(xRotation, yRotation, 0);
//
//		transform.parent.localEulerAngles = new Vector3(0, yRotation, 0);

	}

}


