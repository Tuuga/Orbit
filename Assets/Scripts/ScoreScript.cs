using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreScript : MonoBehaviour {

	public float score;
	float highScore;
	Text scoreText;

	void Awake () {
		DontDestroyOnLoad(gameObject);
		scoreText = GameObject.Find("ScoreUI").GetComponent<Text>();
		scoreText.text = "Score: " + score + "\nHighScore: " + highScore;
	}

	public void AddScore (float addition) {
		score += addition;
		if (highScore < score) {
			highScore = score;
		}
		scoreText = GameObject.Find("ScoreUI").GetComponent<Text>();
		scoreText.text = "Score: " + score + "\nHighScore: " + highScore;
	}
}
