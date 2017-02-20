using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveObject : MonoBehaviour {

	// Use this for initialization

	GameObject dante;
	Vector3 position;


	void Start () 
	{
		dante = GameObject.Find ("Dante");	
		position.x = 2;
		position.y = 2;
		position.z = 2;
	}
	
	// Update is called once per frame
	void Update () 
	{
		dante.transform.position = position;
	}
}
