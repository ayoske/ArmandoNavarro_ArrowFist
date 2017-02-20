using UnityEngine;
using System.Collections;

// this script is attached to the startup scene "soundObject"
// and loads the background sound object

public class soundOptions : MonoBehaviour {

	// state variable for muting sound
	bool isMuted;
	
	// Use this for initialization
	void Start () {
		// this object survives scene transition
		DontDestroyOnLoad (this);
		// play sound
		isMuted = false;
		// immediately load Menu
		// sound is played in the background
		Application.LoadLevel ("menu");
	}
	
	// Update is called once per frame
	void Update () {
		// since this object survives scene transition
		// it is possible to (un)mute sound everywhere in the game
		if (Input.GetKeyUp (KeyCode.M)) {
			isMuted = !isMuted;
		}
		// mute or unmute dependent on state
		if (isMuted)
			GetComponent<AudioSource>().volume = 0;
		else
			GetComponent<AudioSource>().volume = 0.25f;
	}
}
