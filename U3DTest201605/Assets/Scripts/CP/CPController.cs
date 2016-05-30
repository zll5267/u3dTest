using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class CPController : MonoBehaviour {

	private bool paused = false;
	private bool ended = false;

	private int score = 0;

	private float timeSpan = 30.0f;
	private float stopTime = 0;
	private float timeLeft = 0;

	private int numOfCoins = 0;
	private int numOfCoinsCollected = 0;

	private int numOfHitByCannonBall = 0;

	public Canvas endGameCanvas; 
	public Text endGameInfo;

	// Use this for initialization
	void Start () {
		this.score = 0;
		this.timeSpan = PlayerPrefs.GetInt ("TimeSpan", 30);
		this.stopTime = Time.time + this.timeSpan;
		this.numOfCoins = GameObject.FindGameObjectsWithTag("coin").Length;
		this.numOfCoinsCollected = 0;
		if (this.endGameCanvas != null) {
			this.endGameCanvas.gameObject.SetActive (false);
		}

		this.paused = false;
		this.ended = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (!paused) {
			this.timeLeft = this.stopTime - Time.time;
			int coinsLeft = this.numOfCoins - this.numOfCoinsCollected;
			if (coinsLeft <= 0) {
				EndGame (true);
			} else if (this.timeLeft <= 0) {
				EndGame (false);
			}
		}
	}
	private void EndGame(bool collectedAllCoins) {
		GameObject obj = GameObject.Find ("CP");
		if ( obj != null) {
			obj.GetComponent<CPMove>().enabled = false;
		}
		if (collectedAllCoins) {
			this.endGameInfo.text = "Succeed";
		} else {
			this.endGameInfo.text = "Failed";
		}
		if (this.endGameCanvas != null) {
			this.endGameCanvas.gameObject.SetActive (true);
		}
		this.paused = true;
		this.ended = true;
	}

	private void PauseGame(bool pause) {
		if ( !this.paused && pause) {
			GameObject obj = GameObject.Find ("CP");
			if (obj != null) {
				obj.GetComponent<CPMove> ().enabled = false;
			}
			this.endGameInfo.text = "Paused";
			if (this.endGameCanvas != null) {
				this.endGameCanvas.gameObject.SetActive (true);
			}
			this.timeLeft = this.stopTime - Time.time;
			this.paused = true;
		}

		if ( this.paused && !pause) {
			GameObject obj = GameObject.Find ("CP");
			if (obj != null) {
				obj.GetComponent<CPMove> ().enabled = true;
			}

			if (this.endGameCanvas != null) {
				this.endGameCanvas.gameObject.SetActive (false);
			}
			this.stopTime = Time.time + this.timeLeft;
			this.paused = false;
		}
	}

	void OnTriggerEnter(Collider c) {
		if (c.tag.Equals("coin")) {
			Coin coin = c.GetComponent<Coin> ();
			this.score += coin.VALUE;

			Destroy (c.gameObject);
			numOfCoinsCollected += 1;
		}

		if (c.tag.Equals("cannonball")) {
			numOfHitByCannonBall++;
			Debug.Log ("hit by cannon ball " + numOfHitByCannonBall.ToString() + "times!");

			Destroy (c.gameObject);
		}
	}

	void OnGUI()
	{
		//Debug.Log ("screen.with: " + Screen.width);
		GUIStyle labelStyle = new GUIStyle();
		labelStyle.normal.background = null;
		labelStyle.normal.textColor = new Color(1, 0, 0);
		labelStyle.fontSize = 30;
		GUI.Label(new Rect(10, 0, 150, 30), string.Format("total score : {0:F2}", this.score), labelStyle);
		GUI.Label(new Rect(10, 30, 150, 30), string.Format("left coins : {0:D}", this.numOfCoins - this.numOfCoinsCollected), labelStyle);

		if (this.timeLeft < 0) {
			this.timeLeft = 0.0f;
		}
		GUI.Label(new Rect(Screen.width - 230, 0, 150, 30), string.Format("time left : {0:F2}", this.timeLeft), labelStyle);
	
		GUI.Box (new Rect (Screen.width - 110, Screen.height - 130, 100, 120), "Restart menu");
		if (GUI.Button(new Rect(Screen.width - 100, Screen.height - 100, 80, 20), "Restart")) {
			GameRestart ();
		}

		if (GUI.Button(new Rect(Screen.width - 100, Screen.height - 70, 80, 20), "Pause")) {
			PauseGame (true);
		}

		if (GUI.Button(new Rect(Screen.width - 100, Screen.height - 40, 80, 20), "menu")) {
			SceneManager.LoadScene ("menu");
		}
	}

	public void GameRestart() {
		if (this.ended || !this.paused) {
			GameObject[] coins = GameObject.FindGameObjectsWithTag ("coin");
			foreach (GameObject coin in coins) {
				Destroy (coin);
			}
			SceneManager.LoadScene ("part6");
		} else {
			PauseGame (false);
		}
	}
}
