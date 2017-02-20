using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour {

	public GameObject decal;
	private Vector3 impact;
	public Quaternion angularInpact;
	AudioClip bulletFX;

	void OnCollisionEnter(Collision objectCollision)
	{
		//Debug.Log(objectCollision.contacts[0].point);
		//impact = objectCollision.contacts [0].point;
		//angularInpact = ;
		//Debug.Log(impact);
		//Instantiate(decal,impact,angularInpact);
		//Destroy(this.gameObject);

		ContactPoint contact = objectCollision.contacts[0];
		//angularInpact = Quaternion.FromToRotation(Vector3.left,contact.normal);
		angularInpact = Quaternion.FromToRotation(Vector3.forward,objectCollision.contacts[0].normal);
		Debug.Log("angularImpact "+angularInpact);
		transform.GetComponent<AudioSource> ().PlayOneShot (bulletFX);
		Debug.Log ("sale flecha");
		impact = contact.point;
		Instantiate(decal, impact, angularInpact);	

	}

}
 