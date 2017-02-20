using UnityEngine;
using System.Collections;
using UnityEngine.UI;

// This script is attached to the main game GameObject (gameManager)

public class shoot : MonoBehaviour {

	// Reference to the arrow object
	public GameObject arrow;
	// Reference to the cam objects
	public Camera aimCam;
	public Camera arrowCam;
	public Camera levelCam;
	public Camera targetCam;
	// the visual score object
	public GameObject risingText;
	// Reference to the crosshair
	public GameObject crossHair;
	// Refernce to the particle Systems
	public GameObject particleLeft;
	public GameObject particleRight;

	GameObject arrowGO;

	// are we shooting or drawing the bow
	bool isShooting;
	bool isDrawingBow;

	// Reference to the audio clips
	public AudioClip drawBow;
	public AudioClip releaseBow;
	public AudioClip fanfare;

	// needed for the aiming animation
	float fovMax = 60;
	float fovMin = 50;
	float fovAkt;
	// this var stores the wind speed
	float windSpeed;

	// References to HUD GUI objects
	public Text distanceText;
	public Text windText;
	public Text levelText;

	public Text round1, round2, round3, round4;

	// count the shot arrows
	int arrowCount = 0;
	// which level are we in
	int level = 0;
	// which distance are currently at
	int distance = 0;
	// array of distances to set
	//int[] distances = new int[]{-10,-30,-50,-70};
	int[] distances = new int[]{-5,-5,-5,-5};

	// scores for round 1 to 4
	int r1, r2, r3, r4;

	// References to HUD GUI
	public GameObject gameOverGO;
	public Text bestScore;
	public Text yourScore;
	public Text skillLevel;

	// game states
	public enum GameStates {
		menu,
		game,
		gameOver,
	};

	// set starting game state
	public GameStates gameState = GameStates.menu;



	//
	// public void loadMainMenu()
	//
	// This method is called if player clicks
	// on "Main Menu" button on game over screen
	//
	public void loadMainMenu() {
		Application.LoadLevel ("menu");
	}



	//
	// public void playAgain()
	//
	// This method is called if player clicks
	// on "play again" button on game over screen
	//

	public void playAgain() {
		Application.LoadLevel ("archery");
	}



	//
	// public void Shooting(bool Shooting)
	//
	// This method is called from arrow.cs script
	// to show that shooting is allowed 
	//

	public void Shooting(bool Shooting) {
		isShooting = Shooting;
	} 



	//
	// public void nextArrow()
	//
	// This method is called from arrow.cs script
	// to indicate that next arrow can be shot
	//

	public void nextArrow() {
		// wind may change every arrow
		if (level >= 3)
			makeWind ();
		arrowCount ++;
		// every third arrow change distance
		if (arrowCount % 3 == 0)
			nextDistance ();
		// set the HUD text
		distanceText.text = "Distance: " + Mathf.Abs(aimCam.transform.position.x) + "m";
	}



	//
	// public void checkHighScore()
	//
	// This method is called if the game is over
	// it calculates the score and sets the HUD text
	//

	public void checkHighScore() {
		int ibestScore = PlayerPrefs.GetInt ("Level" + level);
		int iyourScore = r1 + r2 + r3 + r4;
		skillLevel.text = "Skill level: " + level;
		bestScore.text = "Best score: " + ibestScore;
		yourScore.text = "Your Score: " + iyourScore;
		if (iyourScore > ibestScore)
			PlayerPrefs.SetInt ("Level" + level, iyourScore);
	}



	// 
	// public void nextDistance()
	//
	// This method is called to change the distance
	// This happens every third arrow
	//

	public void nextDistance() {
		distance ++;
		// ok - game is over after 70 m
		if (distance == 4) {
			checkHighScore();
			gameState = GameStates.gameOver;
		}
		// change the camera's position
		// (thus the bow, the arrow and all other child objects)
		else {
			Vector3 position = aimCam.transform.position;
			position.x = distances [distance];
			aimCam.transform.position = position;
		}
	}



	// Use this for initialization
	void Start () {
		// disable the Game Over screen
		gameOverGO.SetActive (false);
		// reset the points
		r1 = 0;
		r2 = 0;
		r3 = 0;
		r4 = 0;
		// reset the HUD text
		round1.text = "Round 1: " + r1 + "P";
		round2.text = "Round 2: " + r2 + "P";
		round3.text = "Round 3: " + r3 + "P";
		round4.text = "Round 4: " + r4 + "P";
		// can we shoot?
		isShooting = false;
		// can we draw the bow
		isDrawingBow = false;
		// set camera properties
		fovAkt = fovMax;
		// disable all camera which are not used
		arrowCam.enabled = false;
		aimCam.enabled = false;
		targetCam.enabled = false;
		// set HUD distance text
		distanceText.text = "Distance: " + Mathf.Abs(aimCam.transform.position.x) + "m";
		// initialize the score table
		initScores ();
	}



	//
	// public void initScores()
	//
	// The player score is stored via Playerprefs
	// to make sure they can be stored,
	// they have to be initialized at first
	//

	public void initScores() {
		if (!PlayerPrefs.HasKey ("Level1"))
			PlayerPrefs.SetInt ("Level1", 0);
		if (!PlayerPrefs.HasKey ("Level2"))
			PlayerPrefs.SetInt ("Level2", 0);
		if (!PlayerPrefs.HasKey ("Level3"))
			PlayerPrefs.SetInt ("Level3", 0);
		if (!PlayerPrefs.HasKey ("Level4"))
			PlayerPrefs.SetInt ("Level4", 0);
		if (!PlayerPrefs.HasKey ("Level5"))
			PlayerPrefs.SetInt ("Level5", 0);
		if (!PlayerPrefs.HasKey ("Level6"))
			PlayerPrefs.SetInt ("Level6", 0);
	}


	// 
	// public void makeWind()
	//
	// This method generates the wind
	//

	public void makeWind() {
		float maxWindSpeed;
		// Level 1: no wind
		if (level == 1)
			maxWindSpeed = 0;
		// Level 2 & 3: light wind
		else if (level == 2 || level == 3)
			maxWindSpeed = 3;
		else
			// max wind
			maxWindSpeed = 10;

		// generate a random wind speed
		windSpeed = Random.Range (-maxWindSpeed, maxWindSpeed);
		// actualize the HUD text
		windText.text = "Wind: " + Mathf.Abs(windSpeed) + "m/s";
		// set more info
		// and give visual hint via activating the proper particle system
		if (windSpeed > 0) {
			windText.text += " from the right";
			particleRight.GetComponent<ParticleSystem>().enableEmission = true;
			particleLeft.GetComponent<ParticleSystem>().enableEmission = false;
		}
		if (windSpeed < 0) {
			windText.text += " from the left";
			particleRight.GetComponent<ParticleSystem>().enableEmission = false;
			particleLeft.GetComponent<ParticleSystem>().enableEmission = true;
		}
	}



	//
	// public void setPoints(int points)
	//
	// This method add the points for the current round
	//

	public void setPoints(int points){
		if (distance == 0) {
			r1 += points;
		}
		if (distance == 1) {
			r2 += points;
		}
		if (distance == 2) {
			r3 += points;
		}
		if (distance == 3) {
			r4 += points;
		}
		// after calculating the points,
		// set the HUD text
		round1.text = "Round 1: " + r1 + "P";
		round2.text = "Round 2: " + r2 + "P";
		round3.text = "Round 3: " + r3 + "P";
		round4.text = "Round 4: " + r4 + "P";
	}



	//
	// public void setLevel()
	//
	// This method sets the Level information
	// in the HUD
	//

	public void setLevel(int _level) {
		switch (_level) {
		case 1: levelText.text = "Level 1: Sheriff of Nottingham";
			break;
		case 2: levelText.text = "Level 2: Pawn";
			break;
		case 3: levelText.text = "Level 3: Hobby Archer";
			break;
		case 4: levelText.text = "Level 4: Huntsman";
			break;
		case 5: levelText.text = "Level 5: Merry Green Man";
			break;
		case 6: levelText.text = "Level 6: Robin Hood";
			crossHair.gameObject.SetActive(false);
			break;
		}
		// after setting the level play a fanfare sound
		GetComponent<AudioSource>().PlayOneShot (fanfare);
		// set the level
		level = _level;
		// change the actual gameState
		gameState = GameStates.game;
		// activate the correct camera
		levelCam.enabled = false;
		aimCam.enabled = true;
		// set the wind
		makeWind ();
	}




	// Update is called once per frame
	void Update () {
		// check which state we are in
		switch (gameState) {
				case GameStates.menu:
					// the player released the mouse button
					if ((Input.GetButtonUp ("Fire1")) && !isShooting) {
						GetComponent<AudioSource>().PlayOneShot (releaseBow);
						arrowGO = Instantiate (arrow, levelCam.transform.position, Quaternion.Euler (new Vector3 (0, levelCam.transform.localEulerAngles.y - 90f, 360f - aimCam.transform.localEulerAngles.x))) as GameObject;
						arrowGO.name = "Arrow";
						arrowGO.GetComponent<arrowScript> ().shootArrow (levelCam.transform.localEulerAngles);
						// no backpack cam
						arrowGO.GetComponent<arrowScript> ().setCam (arrowCam, false);
						// main cam is the level cam
						arrowGO.GetComponent<arrowScript> ().setMainCam (levelCam);
						// wind speed is always 0
						arrowGO.GetComponent<arrowScript> ().setWindSpeed (windSpeed);
						// reference to the main game object (this)
						arrowGO.GetComponent<arrowScript> ().setGameManager (gameObject);
						isShooting = true;
						isDrawingBow = false;
						fovAkt = fovMax;
						levelCam.fieldOfView = fovAkt;
					}
					
					if ((Input.GetButtonDown ("Fire1")) && !isDrawingBow && !isShooting) {
						GetComponent<AudioSource>().PlayOneShot (drawBow);
						isDrawingBow = true;
					}
					
					if (Input.GetButton ("Fire1")) {
						fovAkt = fovAkt -= 0.5f;
						fovAkt = Mathf.Clamp (fovAkt, fovMin, fovMax);
						levelCam.fieldOfView = fovAkt;
					}
					break;

				// same for the game state
				case GameStates.game:
						if ((Input.GetButtonUp ("Fire1")) && !isShooting) {
								GetComponent<AudioSource>().PlayOneShot (releaseBow);
								arrowGO = Instantiate (arrow, aimCam.transform.position, Quaternion.Euler (new Vector3 (0, aimCam.transform.localEulerAngles.y - 90f, 360f - aimCam.transform.localEulerAngles.x))) as GameObject;
								arrowGO.name = "Arrow";
								arrowGO.GetComponent<arrowScript> ().shootArrow (aimCam.transform.localEulerAngles);
								// this time: backpack cam
								arrowGO.GetComponent<arrowScript> ().setCam (arrowCam, true);
								// main cam is the aim cam
								arrowGO.GetComponent<arrowScript> ().setMainCam (aimCam);
								arrowGO.GetComponent<arrowScript> ().setWindSpeed (windSpeed);
								arrowGO.GetComponent<arrowScript> ().setGameManager (gameObject);
								isShooting = true;
								isDrawingBow = false;
								fovAkt = fovMax;
								aimCam.fieldOfView = fovAkt;
						}

						if ((Input.GetButtonDown ("Fire1")) && !isDrawingBow && !isShooting) {
								GetComponent<AudioSource>().PlayOneShot (drawBow);
								isDrawingBow = true;
						}

						if (Input.GetButton ("Fire1")) {
								fovAkt = fovAkt -= 0.5f;
								fovAkt = Mathf.Clamp (fovAkt, fovMin, fovMax);
								aimCam.fieldOfView = fovAkt;
						}
						break;

				case GameStates.gameOver:
					gameOverGO.SetActive(true);
					break;
				}
				
	}
}
