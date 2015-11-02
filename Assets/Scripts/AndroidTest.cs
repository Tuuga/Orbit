using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;

public class AndroidTest : MonoBehaviour {

	public GameObject player;
	public Text text;
	string debugText;

	void Update () {

		if (Input.touchCount > 0) {
			//touch positions
			for (int i = 0; i < Input.touchCount; i++) {
				if (i == 0) {
					debugText = ("");
				}
				debugText += ("\n Pos " + i + ":" + Input.touches[i].position + "	Touch Phase: " + Input.touches[i].phase);
			}
			text.text = debugText;
		}
	}

	public void Reset () {
		int currentScene = Application.loadedLevel;
		Application.LoadLevel(currentScene);
	}
}
