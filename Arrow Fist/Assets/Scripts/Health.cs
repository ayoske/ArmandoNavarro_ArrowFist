using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour {

	public float healthcount = 50;
	public static Health instance;
	public Image healthBar;


	void Start ()
	{
		instance = this;
	}

	void Update()
	{
		
	}

	public void TakeDamage (int amount) 
	{
		healthcount -= amount;
		healthBar.fillAmount = healthcount / 50;
		if (healthcount <= 0) 
		{
			//Debug.Log ("Muerto");
			//GameState.instance.ChangeState(States.GAME_OVER);
		}
	}
}
