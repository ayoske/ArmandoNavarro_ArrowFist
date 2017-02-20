using UnityEngine;
using System.Collections;

public class move : MonoBehaviour {

	float velocidad;
	public Touch currentTouch;

	void Start () {
	
	}
	

	void Update () {
	
		//if(Input.GetKey(KeyCode.W)){
			//transform.Translate (Vector3.forward * .5f);
		//}

		//if(Input.GetKey(KeyCode.S)){
		//	transform.Translate (Vector3.back * .5f);
		//}
		if (Input.touchCount == 1) {

			currentTouch = Input.GetTouch (0);
			if (currentTouch.position.x < Screen.width * 0.5f) {
				
				transform.Translate (Vector3.left * .5f);
			}
			else
			{
				transform.Translate (Vector3.right * .5f);
			}
		}

		if(Input.touchCount == 2)
		{
			transform.Translate (Vector3.up * .5f);
		}


	}
}
