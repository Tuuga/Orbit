using UnityEngine;
using System.Collections;

public class InitializationScript : MonoBehaviour {

	public GameObject scoreManager;

	void Awake () {
		if (GameObject.Find("ScoreManager") == null) {
			GameObject scoreIns = (GameObject)Instantiate(scoreManager, Vector3.zero, Quaternion.Euler(0, 0, 0));
			scoreIns.name = "ScoreManager";
		}
		scoreManager = GameObject.Find("ScoreManager");
		scoreManager.GetComponent<ScoreScript>().score = 0f;
	}
}
