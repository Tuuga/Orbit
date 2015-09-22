using UnityEngine;
using System.Collections;

public class TimeScale : MonoBehaviour {

	public float scale = 1;
	public bool drawDebugRays;

	void Update () {
	
		Time.timeScale = scale;

	}
}
