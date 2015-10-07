using UnityEngine;
using System.Collections;

public class GameArea : MonoBehaviour {

	void OnTriggerStay (Collider c) {

	}

	void OnTriggerExit (Collider c) {
		if (c.name == "Player") {
			Debug.Log("Out of Borders!");
		}
	}
}
