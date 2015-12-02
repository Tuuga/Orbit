using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreScript : MonoBehaviour {

	float score;
	float highScore;
	float combo;
	float comboTimer;
	public float comboTimerLimit;
	public float scorePerUnitTravelled;
	bool comboTimerOn = false;
	Text scoreText;
	Text comboText;

	void Awake () {
		DontDestroyOnLoad(gameObject);
		comboText = GameObject.Find("ComboText").GetComponent<Text>();
		scoreText = GameObject.Find("ScoreUI").GetComponent<Text>();
		scoreText.text = "Score: " + score + "\nHighScore: " + Mathf.Round(highScore);
	}

	void Update () {
		if (comboTimerOn) {
			comboTimer += Time.deltaTime;
			if (GameObject.Find("ComboText") != null) {
				comboText = GameObject.Find("ComboText").GetComponent<Text>();
				comboText.text = "Combo: " + combo + "\nComboTime: " + Mathf.Round((comboTimerLimit - comboTimer));
			}
			if (comboTimer > comboTimerLimit && GameObject.Find("ComboText") != null) {
				comboTimer = 0;
				combo = 0;
				comboTimerOn = false;
				comboText = GameObject.Find("ComboText").GetComponent<Text>();
				comboText.text = "Combo: " + combo + "\nComboTime: " + Mathf.Round((comboTimerLimit - comboTimer));
			}
		}
	}

	public void Restart () {
		if (Application.loadedLevel == 0) {
			score = 0;
		}
		combo = 0;
		comboTimer = 0;
		comboTimerOn = false;
		if (GameObject.Find("ComboText") != null) {
			comboText = GameObject.Find("ComboText").GetComponent<Text>();
			comboText.text = "Combo: " + combo + "\nComboTime: " + Mathf.Round((comboTimerLimit - comboTimer));
		}
		if (GameObject.Find("ScoreUI") != null) {
			scoreText = GameObject.Find("ScoreUI").GetComponent<Text>();
			scoreText.text = "Score: " + Mathf.Round(score) + "\nHighScore: " + Mathf.Round(highScore);
		}
	}

	public void AddScore (float addition, float dist) {
		combo++;
		comboTimer = 0;
		comboTimerOn = true;

		float toScore = addition * (1 / (dist - 4) + 1) * combo;
		score += toScore;

		if (highScore < score) {
			highScore = score;
		}
		if (GameObject.Find("ComboText") != null) {
			comboText = GameObject.Find("ComboText").GetComponent<Text>();
			comboText.text = "Combo: " + combo + "\nComboTime: " + Mathf.Round((comboTimerLimit - comboTimer));
		}
		if (GameObject.Find("ScoreUI") != null) {
			scoreText = GameObject.Find("ScoreUI").GetComponent<Text>();
			scoreText.text = "Score: " + Mathf.Round(score) + "\nHighScore: " + Mathf.Round(highScore);
		}
	}
	public void AddTravelScore (float deltaMov) {
		float toScore = scorePerUnitTravelled * deltaMov;
		score += toScore;

		if (highScore < score) {
			highScore = score;
		}

		if (GameObject.Find("ScoreUI") != null) {
			scoreText = GameObject.Find("ScoreUI").GetComponent<Text>();
			scoreText.text = "Score: " + Mathf.Round(score) + "\nHighScore: " + Mathf.Round(highScore);
		}
	}
}
