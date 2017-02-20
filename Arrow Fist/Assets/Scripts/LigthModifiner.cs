using UnityEngine;
using System.Collections;

public class LigthModifiner : MonoBehaviour {


	Color ligthColor;
	Light myLigth;

	void Start () 
	{
		myLigth = GetComponent<Light>(); 
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKeyDown(KeyCode.Space)){

			myLigth.color = new Color (Random.Range(0f,1f),
										Random.Range(0f,1f),
										Random.Range(0f,1f));

		}
	}
}
