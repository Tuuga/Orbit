using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {

	public int highScore;
	int score;

	bool first = true;

	GameObject player;

	void Awake () {
		Debug.Log ("GM Spawn");
		DontDestroyOnLoad(gameObject);
	}

	void Update () {

	}

	public void HighScoreUpdate () {

		player = GameObject.Find ("Player");
		score = player.GetComponent<PlayerScript>().score;

		if (first) {
			highScore = score;
			first = false;
		}
		if (score < highScore) {
			highScore = score;
			Debug.Log ("New High Score!");
		}
	}
}
