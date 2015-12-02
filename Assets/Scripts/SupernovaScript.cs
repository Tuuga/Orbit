using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SupernovaScript : MonoBehaviour {

	public float maxSpeed;
	public float snAcceleration;
	public float minDist;
	float snToPlayerDist;
	GameObject player;
	Color snIndicator;
	Image supernovaDist;
	Rigidbody rb;

	void Awake () {
		player = GameObject.Find("Player");
		rb = gameObject.GetComponent<Rigidbody>();
		if (GameObject.Find("SupernovaDistance") != null) {
			supernovaDist = GameObject.Find("SupernovaDistance").GetComponent<Image>();
			snIndicator = supernovaDist.color;
		}
	}
	void Update () {
		snToPlayerDist = Vector3.Distance(transform.position, player.transform.position);
		snToPlayerDist = Mathf.Clamp(snToPlayerDist, 0, minDist);
		if (supernovaDist != null) {
			supernovaDist.color = new Color(snIndicator.r, snIndicator.g, snIndicator.b, 1 - (snToPlayerDist / 100));
		}
		rb.drag = snAcceleration / maxSpeed;
	}

	void FixedUpdate () {
		rb.AddForce(Vector3.up * snAcceleration, ForceMode.Acceleration);
		//transform.position += Vector3.up * speed * Time.fixedDeltaTime;
	}

	void OnTriggerEnter(Collider c) {
		if (c.tag == "Player") {
			Debug.Log("Supernova hit player");
		}
	}
}
