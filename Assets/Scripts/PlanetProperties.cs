using UnityEngine;
using System.Collections;

public class PlanetProperties : MonoBehaviour {
	
	public bool orbiting;
	public GameObject orbitingAround;
	public float startForce;

	//public for debug
	public float startDist;
	public float currentDist;
	Rigidbody rb;


	void Awake () {

		rb = GetComponent<Rigidbody>();

		if (orbiting) {



			startDist = Vector2.Distance(transform.position, orbitingAround.transform.position);
			transform.LookAt (orbitingAround.transform, Vector3.back);

			rb.AddForce (transform.right * startForce, ForceMode.Impulse);

		}
	}

	void Update () {
		if (orbiting) {
			currentDist = Vector2.Distance(transform.position, orbitingAround.transform.position);
		}
	}
}
