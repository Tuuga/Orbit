using UnityEngine;
using System.Collections;

public class GameState : MonoBehaviour {

	public GameObject playingCanvas;
	public GameObject pauseCanvas;

	void Start () {
		GameObject.Find("ScoreManager").GetComponent<ScoreScript>().Restart();
	}

	public void Restart () {
		Application.LoadLevel(0);
		Time.timeScale = 1;
	}
	public void Pause () {
		playingCanvas.SetActive(false);
		pauseCanvas.SetActive(true);
		Time.timeScale = 0;
	}
	public void Resume () {
		playingCanvas.SetActive(true);
		pauseCanvas.SetActive(false);
		Time.timeScale = 1;
	}
	public void Quit () {
		Application.Quit();
	}
}
