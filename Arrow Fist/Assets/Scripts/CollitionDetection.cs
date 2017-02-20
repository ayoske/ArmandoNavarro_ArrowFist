using UnityEngine;
using System.Collections;


public class CollitionDetection : MonoBehaviour 
{

	void OnCollisionEnter(Collision objectCollision)
		{
			if(objectCollision.transform.tag == "Cube")
			{
			GetComponent<MeshRenderer>().material.color = Color.red;
			}
		}

	void OnCollisionStay(Collision objectCollision)
	{
		if(objectCollision.transform.tag == "Cube")
		{
			GetComponent<MeshRenderer>().material.color = Color.green;
		}
	}

	void OnCollisionExit(Collision objectCollision)
	{
		if(objectCollision.transform.tag == "Cube")
		{
			GetComponent<MeshRenderer>().material.color = Color.black;
		}
	}

	void OnTriggerStay(Collider objectCollider)
	{

		if(objectCollider.transform.tag == "Cube")
		{
			GetComponent<MeshRenderer> ().material.color = Color.yellow;
		}

	}

}
