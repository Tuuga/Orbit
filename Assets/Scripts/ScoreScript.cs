using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreScript : MonoBehaviour {

	public float score;
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
			comboText = GameObject.Find("ComboText").GetComponent<Text>();
			comboText.text = "Combo: " + combo + "\nComboTime: " + Mathf.Round((comboTimerLimit - comboTimer));
			if (comboTimer > comboTimerLimit) {
				comboTimer = 0;
				combo = 0;
				comboTimerOn = false;
				comboText = GameObject.Find("ComboText").GetComponent<Text>();
				comboText.text = "Combo: " + combo + "\nComboTime: " + Mathf.Round((comboTimerLimit - comboTimer));
			}
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
		comboText = GameObject.Find("ComboText").GetComponent<Text>();
		comboText.text = "Combo: " + combo + "\nComboTime: " + Mathf.Round((comboTimerLimit - comboTimer));
		scoreText = GameObject.Find("ScoreUI").GetComponent<Text>();
		scoreText.text = "Score: " + score + "\nHighScore: " + highScore;
	}
}
