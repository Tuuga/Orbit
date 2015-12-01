using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;

public class ForTesting : MonoBehaviour {

	public float time_Scale = 1f;
	public GameObject player;
	public Text text;
	string debugText;

	void Update () {
		//Time.timeScale = time_Scale;
		/*
		if (Input.touchCount > 0) {
			//touch positions
			for (int i = 0; i < Input.touchCount; i++) {
				if (i == 0) {
					debugText = ("");
				}
				debugText += ("\n Pos " + i + ":" + Input.touches[i].position + "	Touch Phase: " + Input.touches[i].phase);
			}
			text.text = debugText;
		} */
	}
}
