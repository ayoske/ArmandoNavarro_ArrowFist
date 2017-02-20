using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogDamage : MonoBehaviour {

	void OnTriggerStay(Collider info)
	{

		if(info.gameObject.CompareTag("Player"))
		{			
			Health.instance.TakeDamage (10);

			if (Health.instance.healthcount > 0) {
				Destroy (this.gameObject);
			}
		}
	}
}
