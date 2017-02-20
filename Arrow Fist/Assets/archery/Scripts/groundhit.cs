using UnityEngine;
using System.Collections;

public class groundhit : MonoBehaviour {

	public GameObject ar;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision other) {
		foreach (ContactPoint contact in other.contacts) {
			Debug.DrawRay(contact.point, contact.normal, Color.white);
			Debug.Log(contact.point);
		}
	}

}
