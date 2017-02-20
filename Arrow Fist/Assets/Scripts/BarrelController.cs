using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelController : MonoBehaviour {

	public SpriteRenderer barrelSprite;
	public float barrelSpeed;
	public Color startTouchColor;
	public Color stayTouchColor;
	public Color endTouchColor;
	public Touch currentTouch;
	private Vector3 curretAccel;


	void Start () {
		 
	}
	

	void Update () 
	{

		//---------------Giroscopio-------------------------

//		curretAccel = Input.acceleration;
//
//		if (curretAccel.x > 0) {
//			transform.Translate (-barrelSpeed * Time.deltaTime, 0f, 0f);
//			barrelSprite.flipX = true;
//		}
//		else 
//		{
//			transform.Translate (-barrelSpeed * Time.deltaTime, 0f, 0f);
//			barrelSprite.flipX = false;
//		}

		//------------------------------Touch-----------------------
		if (Input.touchCount > 0) 
		{
			currentTouch = Input.GetTouch (0);
			if (currentTouch.position.x < Screen.width * 0.5f) {
				transform.Translate (-barrelSpeed * Time.deltaTime, 0f, 0f);
				barrelSprite.flipX = true;
			}
			else 
			{
				transform.Translate(barrelSpeed * Time.deltaTime, 0f, 0f);
				barrelSprite.flipX = false;
			}
			switch (currentTouch.phase) 
			{
			case TouchPhase.Began:
				barrelSprite.color = startTouchColor;
				break;
			case TouchPhase.Ended:
				barrelSprite.color = endTouchColor;
				break;
			case TouchPhase.Moved:
				barrelSprite.color = stayTouchColor;
				break;				
			}
		}
		else
		{
			barrelSprite.color = Color.white;
		}
	}
}
