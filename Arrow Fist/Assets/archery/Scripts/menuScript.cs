using UnityEngine;
using System.Collections;

// this script is attached to the main menu screen game object

public class menuScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	// we only have one menu button at the moment
	// so all we can do is start the game :-)
	public void loadGame() {
		Application.LoadLevel ("archery");
	}
}
