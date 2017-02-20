using UnityEngine;
using System.Collections;

public class Selector : MonoBehaviour {

	public Camera currentCamera;
	public float force;
	Ray mouseRay;
	RaycastHit mouseRayHit;
	GameObject tmpSphere;
	public float shotForce = 100;
	public GameObject crossHead;


	void Update () 
	{
	
		if (Input.GetMouseButtonDown (0)) 
		{

			mouseRay = currentCamera.ScreenPointToRay(Input.mousePosition); //creacion del rayo a partir de la posicion del mouse
			if(Physics.Raycast(mouseRay,out mouseRayHit)) // nos va a mandar la informacion si hizo contacto con un objeto
			{
				Vector3 force = currentCamera.transform.forward * shotForce; 
				mouseRayHit.transform.GetComponent<Rigidbody>().AddForce(force);
			}

		}



			mouseRay = currentCamera.ScreenPointToRay(Input.mousePosition); //creacion del rayo a partir de la posicion del mouse
			if(Physics.Raycast(mouseRay,out mouseRayHit)) // nos va a mandar la informacion si hizo contacto con un objeto
			{
			var angularPoint = Quaternion.FromToRotation (Vector3.left, mouseRayHit.normal );
				if(mouseRayHit.transform.tag == "Sphere")
				{
				var hitRotation = Quaternion.FromToRotation (Vector3.forward, mouseRayHit.normal); 
					crossHead.transform.position = mouseRayHit.point;
				crossHead.transform.rotation = hitRotation;
								
				}

			}
	}
}