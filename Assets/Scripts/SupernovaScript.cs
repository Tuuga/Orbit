using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SupernovaScript : MonoBehaviour {

	public float maxSpeed;
	public float snAcceleration;
	public float minDist = 100f; //If player is maxDist units away from supernova, the indicator is transparent
	public Color snIndicator;
	float snToPlayerDist;
	GameObject player;
	Image supernovaDist;
	Rigidbody rb;

	void Awake () {
		player = GameObject.Find("Player");
		rb = gameObject.GetComponent<Rigidbody>();
		supernovaDist = GameObject.Find("SupernovaDistance").GetComponent<Image>();
	}
	void Update () {
		snToPlayerDist = Vector3.Distance(transform.position, player.transform.position);
		snToPlayerDist = Mathf.Clamp(snToPlayerDist, 0, minDist);
		supernovaDist.color = new Color(snIndicator.r, snIndicator.g, snIndicator.b, 1 - (snToPlayerDist / 100));
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
