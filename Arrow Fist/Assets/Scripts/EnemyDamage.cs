using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour 
{
	void OnTriggerStay(Collider info)
	{

		if(info.gameObject.CompareTag("Player"))
		{			
			Health.instance.TakeDamage (20);

			if (Health.instance.healthcount > 0) {
				Destroy (this.gameObject);
			}
		}
	}
}
