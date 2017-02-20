using UnityEngine;
using System.Collections;

public class Transformer : MonoBehaviour {


	void Start () 
	{
		
	}
	

	void Update () 
	{	
		//transform.Translate (Vector3.up*.2f);
		//transform.Translate (0f, .2f, 0f); lo mismo que la linea anterior

		//transform.Rotate (0f, 5f, 0f);//
		//transform.Rotate (Vector3.up * 5f); lo mismo q la linea anterior
		//transform.RotateAround (Vector3.up, 5f); //Rotacion con eje global como pibote

		transform.localScale = Vector3.one * 2f; // one es aumentar en uno en los 3 ejes
	}
}
