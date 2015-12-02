﻿using UnityEngine;
using System.Collections;

public class GameState : MonoBehaviour {

	public GameObject playingCanvas;
	public GameObject pauseCanvas;
	public GameObject deathCanvas;

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
		deathCanvas.SetActive(false);
		Time.timeScale = 0;
	}
	public void Resume () {
		playingCanvas.SetActive(true);
		pauseCanvas.SetActive(false);
		deathCanvas.SetActive(false);
		Time.timeScale = 1;
	}
	public void Quit () {
		Application.Quit();
	}
	public void Death () {
		playingCanvas.SetActive(false);
		pauseCanvas.SetActive(false);
		deathCanvas.SetActive(true);
		Time.timeScale = 0;
	}
}
