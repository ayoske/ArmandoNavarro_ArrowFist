using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchSample : MonoBehaviour {

	private Touch currentTouch;

	void Start () 
	{
			
	}
	

	void Update () 
	{
		if(Input.touchCount > 0){
			
			currentTouch = Input.GetTouch (0);
			Debug.Log(currentTouch.position);
			Debug.Log(currentTouch.phase);

		}
	}
}
