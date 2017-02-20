using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utilities : MonoBehaviour {

	public static Utilities instance;
	public Texture2D screenShot;

	public delegate void CaptureScreenShotCallback();
	public CaptureScreenShotCallback captureScreenShotCallback;




	// Use this for initialization
	void Start () 
	{
		instance = this;

		
	}

	void Update () {
		
	}

	public void TakeScreenShot()
	{
		screenShot = new Texture2D (Screen.width, Screen.height,TextureFormat.RGB24,false);

		StartCoroutine ("CaptureScreenShot");
	}

	IEnumerator CaptureScreenShot()
	{
		yield return new WaitForEndOfFrame();
		screenShot.ReadPixels (new Rect (0, 0, Screen.width, Screen.height),0,0,false);
		screenShot.Apply();
		captureScreenShotCallback();
	}
}
