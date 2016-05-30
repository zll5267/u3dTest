using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Menu : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void HardMode() {
		PlayerPrefs.SetInt ("TimeSpan", 40);
	}

	public void EasyMode() {
		PlayerPrefs.SetInt ("TimeSpan", 80);
	}

	public void StartGame() {
		SceneManager.LoadScene ("part6");
	}

	public void ExitGame() {
		Application.Quit ();
	}
}
