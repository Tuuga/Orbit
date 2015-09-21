using UnityEngine;
using System.Collections;

public class Attraction : MonoBehaviour {

	public float mass;
	public float strength;
	public float angle;

	Vector3 velocity;
	Vector3 gravity;
	Rigidbody rb;
	
	void Gravity(GameObject g) {

		rb = g.GetComponent<Rigidbody> ();

		strength = Mathf.Sqrt (mass) / Vector2.Distance (g.transform.position, transform.position);

		Vector3 direction = transform.position - g.transform.position;
		rb.AddForce(strength * direction);

		Debug.DrawLine (g.transform.position, rb.velocity, Color.red);
		Debug.DrawLine (g.transform.position, direction, Color.green);
		Debug.DrawLine (g.transform.position, rb.velocity + direction * strength);

		gravity = direction;
		velocity = rb.velocity;

		Debug.DrawRay (g.transform.position, gravity, Color.yellow);
		Debug.DrawRay (g.transform.position, velocity, Color.blue);

		angle = Vector3.Angle (velocity, gravity);

	}

	void OnTriggerStay (Collider c) {

		if (c.GetComponent<Rigidbody>() != null) {
			Gravity (c.gameObject);
		}
	}
}
