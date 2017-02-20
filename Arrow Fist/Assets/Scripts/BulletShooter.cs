using UnityEngine;
using System.Collections;

public class BulletShooter : MonoBehaviour {

	public GameObject bulletPrefab;
	private GameObject tmpBullet;
	public float bulletForce;
	//AudioClip shootFX;

	public GameObject bulletModel;

	void Update () 
	{
		bulletModel = GameObject.FindWithTag ("BulletModel");

		if(Input.GetMouseButtonUp(0))
		{
			tmpBullet = (GameObject)Instantiate(bulletPrefab,transform.position,bulletModel.transform.rotation);
			tmpBullet.GetComponent<Rigidbody>().AddForce(transform.forward * bulletForce,ForceMode.Impulse);

		}

		if(Input.GetMouseButtonDown(0))
		{
			Debug.Log ("sale flecha sonido");
			//transform.GetComponent<AudioSource> ().PlayOneShot (shootFX);
		}
	}
}
