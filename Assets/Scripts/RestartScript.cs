using UnityEngine;
using System.Collections;

public class RestartScript : MonoBehaviour {

	void Awake () {
		GameObject.Find("ScoreManager").GetComponent<ScoreScript>().Restart();
	}

	public void Restart () {
		Application.LoadLevel(0);
	}
}
