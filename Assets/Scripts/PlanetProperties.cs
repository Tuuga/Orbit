using UnityEngine;
using System.Collections;

public class PlanetProperties : MonoBehaviour {
	
	public bool orbiting;
	public GameObject orbitingAround;
	public float startForce;
	public float divider;

	//public for debug
	public float startDist;
	public float currentDist;
	public float maxDist;
	public float minDist;
	public float avarageDist;

	Rigidbody rb;


	void Awake () {

		rb = GetComponent<Rigidbody>();

		if (orbiting) {

			startDist = Vector2.Distance(transform.position, orbitingAround.transform.position);
			minDist = startDist;
			transform.LookAt (orbitingAround.transform, Vector3.back);
			startForce = startDist / divider;
			rb.AddForce (transform.right * startForce, ForceMode.Impulse);

		}
	}

	void Update () {
		if (orbiting) {
			currentDist = Vector2.Distance(transform.position, orbitingAround.transform.position);
			if (maxDist < currentDist) {
				maxDist = currentDist;
			}
			if (currentDist < minDist) {
				minDist = currentDist;
			}
			avarageDist = (minDist + maxDist) / 2;
		}
	}
}
