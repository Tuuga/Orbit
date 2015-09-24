using UnityEngine;
using System.Collections;

public class PlanetProperties : MonoBehaviour {
	
	public bool orbiting;
	public GameObject orbitingAround;
	public float divider;
	public float startForce;

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

            float mass = orbitingAround.GetComponent<Attraction>().mass1;
            Vector3 dir = (orbitingAround.transform.position - transform.position).normalized;

            startDist = Vector2.Distance(transform.position, orbitingAround.transform.position);
			minDist = startDist;

            Vector3 newDir = Quaternion.AngleAxis (90, Vector3.forward) * dir * Mathf.Sqrt(mass / startDist);
            Debug.Log(newDir);
            rb.velocity = newDir;

        }
	}

	void FixedUpdate () {

		if (orbiting) {

            Vector3 dir = orbitingAround.GetComponent<Attraction>().direction;
            float force = orbitingAround.GetComponent<Attraction>().force;

            Vector3 newDir = Quaternion.AngleAxis(90, Vector3.forward) * dir;
            newDir = newDir.normalized * dir.magnitude;

            //rb.velocity = newDir;

            Debug.DrawRay(transform.position, newDir, Color.blue);
            

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

    void OnTriggerStay(Collider c) {
        //Workaround for OnTriggerStay not working on child objects
    }
}
