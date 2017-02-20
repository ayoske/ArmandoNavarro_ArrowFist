using UnityEngine;
using System.Collections;

public class ChangeColor : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        InvokeRepeating("SetColor",0f,2.3f);
	}


    void SetColor()
    {
        GetComponent<MeshRenderer>().material.color = new Color(Random.Range(0f,1f),
                                                                Random.Range(0f, 1f),
                                                                Random.Range(0f, 1f));
    }

    void Update()
    {
        transform.Rotate(0,5f,0f);
    }
}
