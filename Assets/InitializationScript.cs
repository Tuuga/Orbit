using UnityEngine;
using System.Collections;

public class InitializationScript : MonoBehaviour {

	public GameObject scoreManager;

	void Awake () {
		if (GameObject.Find("ScoreManager") == null) {
			GameObject scoreIns = (GameObject)Instantiate(scoreManager, Vector3.zero, Quaternion.Euler(0, 0, 0));
			scoreIns.name = "ScoreManager";
		}
		float score = scoreManager.GetComponent<ScoreScript>().score;
		scoreManager.GetComponent<ScoreScript>().AddScore(-score);
	}
}
