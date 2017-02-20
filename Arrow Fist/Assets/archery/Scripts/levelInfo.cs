using UnityEngine;
using System.Collections;
using UnityEngine.UI;

// This script is attached to the level cam

public class levelInfo : MonoBehaviour {

	public GameObject crossHair;

	// display HUD 
	public GameObject levelInf;
	// single elements of HUD
	public Text Level;
	public Text LevelDesc;
	public Text Wind;
	public Text WindChange;
	public Text WindDisplay;
	public Text crossH;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		// only show the hud is player is choosing level
		if (this.transform.GetComponent<Camera>().enabled == true) {
					// to determine direction player is aiming to, build a vector
					// from camera to crosshair
					Vector3 direction = crossHair.transform.position - transform.position;
					RaycastHit hit;
					// if player aims, "shoot" a ray to determine player selection
					if (Physics.Raycast (transform.position, direction, out hit, 40f)) {
							// if player aims at a sign, set the information on the hud
							if (hit.transform.name == "Cube1" ||
									hit.transform.name == "Cube2" ||
									hit.transform.name == "Cube3" ||
									hit.transform.name == "Cube4" ||
									hit.transform.name == "Cube5" ||
									hit.transform.name == "Cube6") {
									// show the level innfo
									levelInf.SetActive (true);

									// now - let's see what we are aiming at
									if (hit.transform.name == "Cube1") {
											Level.text = "Skill level 1:";
											LevelDesc.text = "Sheriff of Nottingham";
											Wind.text = "Wind: No wind";
											WindChange.text = "Wind changes: no changes during the game";
											WindDisplay.text = "Wind display: strength & direction";
											crossH.text = "Crosshair: visible";
									}
									if (hit.transform.name == "Cube2") {
											Level.text = "Skill level 2:";
											LevelDesc.text = "Pawn";
											Wind.text = "Wind: light wind";
											WindChange.text = "Wind changes: may change every distance";
											WindDisplay.text = "Wind display: strength & direction";
											crossH.text = "Crosshair: visible";
									}
									if (hit.transform.name == "Cube3") {
											Level.text = "Skill level 3:";
											LevelDesc.text = "Hobby Archer";
											Wind.text = "Wind: light wind";
											WindChange.text = "Wind changes: may change every arrow";
											WindDisplay.text = "Wind display: strength & direction";
											crossH.text = "Crosshair: visible";
									}
									if (hit.transform.name == "Cube4") {
											Level.text = "Skill level 4:";
											LevelDesc.text = "Huntsman";
											Wind.text = "Wind: light wind";
											WindChange.text = "Wind changes: may change every arrow";
											WindDisplay.text = "Wind display: strength & direction";
											crossH.text = "Crosshair: visible";
									}
									if (hit.transform.name == "Cube5") {
											Level.text = "Skill level 5:";
											LevelDesc.text = "Merry Green Man";
											Wind.text = "Wind: strong wind";
											WindChange.text = "Wind changes: may change every arrow";
											WindDisplay.text = "Wind display: strength & direction";
											crossH.text = "Crosshair: visible";
									}
									if (hit.transform.name == "Cube6") {
											Level.text = "Skill level 6:";
											LevelDesc.text = "Robin Hood";
											Wind.text = "Wind: strong wind";
											WindChange.text = "Wind changes: may change every arrow";
											WindDisplay.text = "Wind display: strength & direction";
											crossH.text = "Crosshair: not visible";
									}
							} 
							// we're not aiming at a sign at all
							else {
									levelInf.SetActive (false);
							}
					}
				} 
		else {
			// we're not aiming at a sign at all
			levelInf.SetActive(false);	
		}
	}
}
