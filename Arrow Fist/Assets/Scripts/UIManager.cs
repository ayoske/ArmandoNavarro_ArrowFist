using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

	public GameObject pausePanel;
	public Image screeShotImage;

	void Start () 
	{
		pausePanel.SetActive(false);	
	}

	void Update () 
	{
		if(Input.GetKeyDown(KeyCode.Escape))
		{
			
			Utilities.instance.captureScreenShotCallback += ScreenShotTaken;
			Utilities.instance.TakeScreenShot();

		}		
	}

	public void ScreenShotTaken()
	{
		Utilities.instance.captureScreenShotCallback -= ScreenShotTaken;

		screeShotImage.sprite = Sprite.Create(
										Utilities.instance.screenShot,
										new Rect(0,0,
										Utilities.instance.screenShot.width,
										Utilities.instance.screenShot.height),
										new Vector2(0.5f,0.5f));
		pausePanel.SetActive(true);	

	}
}
