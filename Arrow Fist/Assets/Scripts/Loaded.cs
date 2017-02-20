using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Loaded : MonoBehaviour {

	// Use this for initialization

	void Awake()
	{
		DontDestroyOnLoad(this.gameObject);
		Debug.Log ("Evento Awake" + Time.time);
	}

	void Start () 
	{
		Debug.Log ("Evento Start" + Time.time);
	}
	
	// Update is called once per frame
	void Update () 
	{	
		if(Input.GetKeyDown(KeyCode.Space)){
			SceneManager.LoadScene (Random.Range(1,5),LoadSceneMode.Single);
			SceneManager.LoadScene (Random.Range (1, 5), LoadSceneMode.Additive);
		}
	}
}
