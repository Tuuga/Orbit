using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreScript : MonoBehaviour {

	float score;
	float highScore;
	float combo;
	float comboTimer;
	public float comboTimerLimit;
	bool comboTimerOn = false;
	Text scoreText;
	Text comboText;

	void Awake () {
		DontDestroyOnLoad(gameObject);
		comboText = GameObject.Find("ComboText").GetComponent<Text>();
		scoreText = GameObject.Find("ScoreUI").GetComponent<Text>();
		scoreText.text = "Score: " + score + "\nHighScore: " + highScore;
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
			scoreText.text = "Score: " + score + "\nHighScore: " + highScore;
		}
	}

	public void AddScore (float addition, float dist) {
		combo++;
		comboTimer = 0;
		comboTimerOn = true;

		float toScore = Mathf.Round(addition * ((1 / (dist - 5) * 2) + 1) * combo);
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
			scoreText.text = "Score: " + score + "\nHighScore: " + highScore;
		}
	}
}
