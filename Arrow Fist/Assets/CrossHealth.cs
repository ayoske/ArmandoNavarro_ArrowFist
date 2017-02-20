using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossHealth : MonoBehaviour {

	 int girarY = 2;



	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.Rotate (0,girarY,0);
	}

	void OnTriggerStay(Collider info)
	{

		if(info.gameObject.CompareTag("Player"))
		{			
			if (Health.instance.healthcount <= 40) 
			{
				Health.instance.TakeDamage (-10);
			}

			if (Health.instance.healthcount > 0) {
				Destroy (this.gameObject);
			}
		}
	}
}
