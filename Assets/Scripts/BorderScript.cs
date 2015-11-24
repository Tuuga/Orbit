using UnityEngine;
using System.Collections;

public class BorderScript : MonoBehaviour {

	Rigidbody rb;

	float boxSizeX;
	float distToBorder;
	float force;
	float thrustPenalty;
	float accPenalty;
	public float speedPenalty;
	Vector3 boxPos;
	Vector3 playerPos;
	float enterVelocity;
	GameObject player;

	void Awake () {
		player = GameObject.Find("Player");
        rb = player.GetComponent<Rigidbody>();
		boxSizeX = gameObject.GetComponent<BoxCollider>().size.x;
    }

	void OnTriggerEnter (Collider c) {
		enterVelocity = rb.velocity.magnitude;
	}

	void OnTriggerStay (Collider c) {
		boxPos = transform.position;
		playerPos = rb.position;

		if (gameObject.name == "RightBorder") {
			distToBorder = (boxPos.x + boxSizeX / 2) - playerPos.x;
		} else if (gameObject.name == "LeftBorder") {
			distToBorder = playerPos.x - (boxPos.x - boxSizeX / 2);
		}
		force = Mathf.Clamp (1f - (boxSizeX - distToBorder) / boxSizeX, 0, 1);

		thrustPenalty = player.GetComponent<PlayerController>().maxSpeedWithThrust * speedPenalty;
		accPenalty = player.GetComponent<PlayerController>().thrustAcceleration * speedPenalty;
		InBorder();
	}
	void InBorder () {
		player.GetComponent<PlayerController>().maxSpeedWithThrust -= thrustPenalty * Time.fixedDeltaTime;
		player.GetComponent<PlayerController>().thrustAcceleration -= accPenalty * Time.fixedDeltaTime;
		Vector3 playerVel = (rb.velocity.normalized * enterVelocity) * force;
		rb.velocity = playerVel - rb.velocity.normalized;
	}
}
