using UnityEngine;
using System.Collections;

public class ScoreScript : MonoBehaviour {

	public float score;

	void Awake () {
		DontDestroyOnLoad(gameObject);
	}

	public void AddScore (float addition) {
		score += addition;
	}
}
