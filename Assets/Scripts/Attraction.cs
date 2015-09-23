using UnityEngine;
using System.Collections;

public class Attraction : MonoBehaviour {

	public float mass1;
	public float mass2;
	public float force;
	public float angle;
	public Vector3 direction;

	Vector3 velocity;
	Rigidbody rb;
	GameObject gs;
	public bool drawDebugLines;

	void Awake () {
	
	}

	void Gravity(GameObject g) {

		rb = g.GetComponent<Rigidbody> ();
		
		if (g.transform.FindChild ("GravitySource") != null) {
			gs = g.transform.FindChild("GravitySource").gameObject;
			mass2 = gs.GetComponent<Attraction>().mass1;
		}
        
		if (gs != null) {
			force = (mass1 * mass2) / Mathf.Sqrt (Vector2.Distance (g.transform.position, transform.position));
		} else {
			//force = mass1 / Mathf.Sqrt (Vector2.Distance (g.transform.position, transform.position));
		}

		direction = transform.position - g.transform.position;
		rb.AddForce(force * direction.normalized);

		//Debug lines and Angle
		if (drawDebugLines) {
			Debug.DrawLine (g.transform.position, rb.velocity, Color.red);
			Debug.DrawLine (g.transform.position, direction, Color.black);
		}
//		Debug.DrawLine (g.transform.position, rb.velocity + direction * force);

		velocity = rb.velocity;

//		Debug.DrawRay (g.transform.position, direction, Color.yellow);
//		Debug.DrawRay (g.transform.position, velocity, Color.blue);
		angle = Vector3.Angle (velocity, direction);

	}

	void OnTriggerStay (Collider c) {
        Debug.Log(c.name + ": trigger");
		if (c.GetComponent<Rigidbody>() != null) {
			Gravity (c.gameObject);
		}
	}
}
