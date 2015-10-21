using UnityEngine;
using System.Collections;

public class Attraction : MonoBehaviour {

	public float mass1;
	public float mass2;
	public float force;
	public float angle;
	public Vector3 direction;
	public bool oneSideGravity;

	Rigidbody rb;
	GameObject gs;
	public bool drawDebugLines;

	void Awake () {

		//Sets visual gravity radius if GravitySources parent is a star

		if (gameObject.transform.parent.tag == "Star") {
			GameObject gravitySemiCircle = transform.FindChild("PlaceholderGravityRadiusHalf").gameObject;
			GameObject gravityCircle = transform.FindChild("PlaceholderGravityRadius").gameObject;

			float radius = gameObject.GetComponent<SphereCollider>().radius;
			gravityCircle.transform.localScale = new Vector3(radius, radius, 1);
			gravitySemiCircle.transform.localScale = new Vector3(radius, radius, 1);

			if (oneSideGravity) {
				gravityCircle.SetActive (false);
			} else {
				gravitySemiCircle.SetActive(false);
			}
		}
	}

    void Gravity(GameObject g) {

        rb = g.GetComponent<Rigidbody>();

        if (g.transform.FindChild("GravitySource") != null) {
            gs = g.transform.FindChild("GravitySource").gameObject;
            mass2 = gs.GetComponent<Attraction>().mass1;
        }

        if (gs != null) {
            float dist = Vector2.Distance(g.transform.position, transform.position);
            force = (mass1 * mass2) /  (dist * dist);
        }

        direction = (transform.position - g.transform.position).normalized * force;

		if (oneSideGravity) {
			Vector3 gToThis = g.transform.position - transform.position;
			if (gToThis.y < 0) {
				rb.AddForce(direction);
			}
		}

		if (!oneSideGravity) {
			rb.AddForce(direction);
		}

		//Debug lines and Angle
		if (drawDebugLines) {
			Debug.DrawLine (g.transform.position, rb.velocity, Color.red);
			Debug.DrawLine (g.transform.position, force * direction.normalized, Color.black);
		}

		angle = Vector3.Angle (rb.velocity, direction);
	}

	void OnTriggerStay (Collider c) {
		if (c.GetComponent<Rigidbody>() != null) {
			Gravity (c.gameObject);
		}
	}
}
