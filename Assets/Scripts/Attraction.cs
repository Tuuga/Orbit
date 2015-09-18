using UnityEngine;
using System.Collections;

public class Attraction : MonoBehaviour {

	GameObject player;
	GameObject[] planets;

	bool canAttract;

	public float mass = 5.0f;
	float strength;

	void Start () {

		player = GameObject.Find ("Player");
		planets = GameObject.FindGameObjectsWithTag("Planet");
	}

	void Gravity(GameObject g) {

		strength = mass / Vector2.Distance (g.transform.position, transform.position);

		Vector3 direction = transform.position - g.transform.position;
		g.GetComponent<Rigidbody>().AddForce(strength * direction);
	}
	
	void FixedUpdate () {

		if (canAttract) {
			Gravity (player);
		}

		for (int i = 0; i < planets.Length; i++) {
			Gravity (planets[i]);
		}
	}

	void OnTriggerEnter (Collider c) {
		canAttract = true;
	}

	void OnTriggerExit (Collider c) {
		canAttract = false;
	}
}
