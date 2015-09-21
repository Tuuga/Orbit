using UnityEngine;
using System.Collections;

public class ArrowScript : MonoBehaviour {

	public GameObject winPlanet;


	void Update () {

		transform.LookAt (winPlanet.transform.position);
		transform.position = GameObject.Find("Player").transform.position;
	}
}
