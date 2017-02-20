using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum States{START,GAME_OVER,PAUSE,PLAY}


public class GameState : MonoBehaviour {
	
	public static GameState instance;
	public FPS_Level fpsLevel;
	public States currentState = States.START ;
	public delegate void GameOverEvent();
	public GameOverEvent gameOver;

	//Canvas
	public GameObject canvasGameOver;
	public GameObject canvasPause;
	public GameObject dante;
	Vector3 playerPosition;
	GameObject danteCargado;


	void Start () 
	{
		
		instance = this;	
		gameOver += GameOver;
		fpsLevel.runnerCamera.SetActive (false);
//		dante = GameObject.FindGameObjectWithTag("Player");
//		Debug.Log (dante);
	}

	void Update()
	{
		
	}
	
	public void ChangeState(States newState)
	{
		currentState = newState;
		switch (currentState) 
		{
		case States.GAME_OVER:
			GameOver();
			break;

		case States.PAUSE:
			Pause ();
			break;
		}
	}

	public void GameOver()
	{		
		Debug.Log ("chale");
		canvasGameOver.SetActive(true); 	
	}

	public void Pause()
	{
		Time.timeScale = 0;
		canvasPause.SetActive(true);
	}

	public void Reiniciar()
	{
		SceneManager.LoadScene(1);
		Time.timeScale = 1;


	}

	public void MenuInicio()
	{
		SceneManager.LoadScene (0);
	}

	public void GuardarPartida()
	{
		//SaveEnemys ();
		SavePlayer ();
	}

	public void CargarPartida()
	{
		LoadPlayer ();
	}

	public void SaveEnemys()
	{
		GameObject[] balls = GameObject.FindGameObjectsWithTag ("Enemy");
		if (balls.Length > 0) 
		{
			string data = string.Empty;
			Vector3 actualBallPosition;

			foreach (GameObject ball in balls) 
			{
				actualBallPosition = ball.transform.position;
				data += actualBallPosition.x + "," + actualBallPosition.y + "," + actualBallPosition.z;
				data += "|";
			}

			PlayerPrefs.SetString ("BALLS", data);
			PlayerPrefs.Save ();
		}
	}

	public void SavePlayer()
	{
		GameObject player = GameObject.FindWithTag ("Player");
		if (player != null) 
		{
			string data = string.Empty;
			Vector3 actualPosition; 

			actualPosition = player.transform.position;
			data += actualPosition.x + "," + actualPosition.y + "," + actualPosition.z;
			Debug.Log ("posicion guardada es " + data);

			PlayerPrefs.SetString ("PLAYER", data);
			PlayerPrefs.Save ();
		}


	}

	public void LoadEnemys()
	{
		string data = PlayerPrefs.GetString ("BALLS", string.Empty);
		string bar = "|";
		string coma = ",";

		string[] ballsPos = data.Split (bar.ToCharArray ());
		string[] xyz;
		Vector3 pos = Vector3.zero;

		foreach (string posString in ballsPos) 
		{
			if (posString != string.Empty) 
			{
				xyz = posString.Split (coma.ToCharArray());

				pos.x = float.Parse (xyz[0]);
				pos.y = float.Parse (xyz[1]);
				pos.z = float.Parse (xyz[2]);

				Instantiate (this,pos,Quaternion.identity);
			}
		}
	}

	public void LoadPlayer()
	{
		string data = PlayerPrefs.GetString ("PLAYER", string.Empty);
		string coma = ",";
		dante = GameObject.FindGameObjectWithTag("Player");
		Debug.Log (dante);

		string[] xyz;
		Vector3 pos = Vector3.zero;

		xyz = data.Split (coma.ToCharArray());

		pos.x = float.Parse (xyz[0]);
		pos.y = float.Parse (xyz[1]);
		pos.z = float.Parse (xyz[2]);

		Time.timeScale = 0;
		playerPosition = pos;
		Debug.Log (playerPosition);
		dante.transform.position = playerPosition;
		Debug.Log ("posicion cargada " + pos.x + "," + pos.y + "," + pos.z);
		SavePlayer ();
		SceneManager.LoadScene(1);
		Time.timeScale = 1;
		Recarga ();


		//GameState.instance.ChangeState (States.PAUSE);

		//GameObject player = GameObject.FindGameObjectWithTag("Player");
		//Vector3 posPlayer = new Vector3 (pos.x,pos.y,pos.z);
	}

	public void Recarga()
	{
		Vector3 loadPlayerPosition = playerPosition;
		Debug.Log (loadPlayerPosition + "load posision player" );
		danteCargado = GameObject.FindGameObjectWithTag("Tronco");
		danteCargado.transform.position = loadPlayerPosition;
		Debug.Log (danteCargado.transform.position + "posision dante");
	}
}
