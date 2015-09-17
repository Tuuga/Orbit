using UnityEngine;
using System.Collections;

public class Attraction : MonoBehaviour {

	GameObject player;
	GameObject[] planets;

	public float mass = 5.0f;
	float strength;

	void Start () {

		player = GameObject.Find ("Player");
		planets = GameObject.FindGameObjectsWithTag("Planet");
		strength = mass;
	}

	void Gravity(GameObject g) {

		mass = strength / Vector2.Distance (g.transform.position, transform.position);

		Vector3 direction = transform.position - g.transform.position;
		g.GetComponent<Rigidbody>().AddForce(mass * direction);
	}
	
	void FixedUpdate () {

		Gravity (player);

		for (int i = 0; i < planets.Length; i++) {
			Gravity (planets[i]);
		}
	}
}
