using UnityEngine;
using System.Collections;

public class TimeScale : MonoBehaviour {

	public float scale = 1;

	void Update () {
	
		Time.timeScale = scale;

	}
}
