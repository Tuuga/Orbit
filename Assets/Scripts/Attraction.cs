﻿using UnityEngine;
using System.Collections;

public class Attraction : MonoBehaviour {

	public float mass1;
	public float mass2;
	public float force;
	public float angle;
	public Vector3 direction;

	Rigidbody rb;
	GameObject gs;
	public bool drawDebugLines;

	void Awake () {
	
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
        } else {
            //force = mass1 / Mathf.Sqrt (Vector2.Distance (g.transform.position, transform.position));
        }

        direction = (transform.position - g.transform.position).normalized * force;

        rb.AddForce(direction);

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
