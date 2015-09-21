using UnityEngine;
using System.Collections;

public class Attraction : MonoBehaviour {

	public float mass;
	public float strength;
	
	void Gravity(GameObject g) {

		strength = Mathf.Sqrt (mass) / Vector2.Distance (g.transform.position, transform.position);

		Vector3 direction = transform.position - g.transform.position;
		g.GetComponent<Rigidbody>().AddForce(strength * direction);

//		Debug.DrawLine (transform.position, g.transform.position, Color.red);
//		Debug.DrawLine (transform.position, direction * strength, Color );
	}

	void OnTriggerStay (Collider c) {

		if (c.GetComponent<Rigidbody>() != null) {
			Gravity (c.gameObject);
		}
	}
}
