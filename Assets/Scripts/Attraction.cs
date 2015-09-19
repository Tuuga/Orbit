using UnityEngine;
using System.Collections;

public class Attraction : MonoBehaviour {

	public float mass;
	float strength;
	
	public void Gravity(GameObject g) {

		strength = mass / Vector2.Distance (g.transform.position, transform.position);

		Vector3 direction = transform.position - g.transform.position;
		g.GetComponent<Rigidbody>().AddForce(strength * direction);
	}

	void OnTriggerStay (Collider c) {

		if (c.GetComponent<Rigidbody>() != null) {
			Gravity (c.gameObject);
		}
	}
}
