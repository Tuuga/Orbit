using UnityEngine;
using System.Collections;

public class MapBorders : MonoBehaviour {

	GameObject player;
	
	void Awake () {
		player = GameObject.Find ("Player");
	}

	void OnTriggerExit (Collider c) {
		if (c.name == "Player") {
			player.GetComponent<PlayerScript>().GameOver();
		}
	}
}
