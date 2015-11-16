using UnityEngine;
using System.Collections;

public class BorderScript : MonoBehaviour {

	Rigidbody rb;

	float boxSizeX;
	float distToBorder;
	float force;
	public float forceStrength;
	public float slowStrength;
	public float speedPenalty;
	Vector3 boxPos;
	Vector3 playerPos;
	GameObject player;

	void Awake () {
		player = GameObject.Find("Player");
        rb = player.GetComponent<Rigidbody>();
		boxSizeX = gameObject.GetComponent<BoxCollider>().size.x;
    }

	void OnTriggerStay (Collider c) {
		boxPos = transform.position;
		playerPos = rb.position;

		if (gameObject.name == "RightBorder") {
			distToBorder = (boxPos.x + boxSizeX / 2) - playerPos.x;
		} else if (gameObject.name == "LeftBorder") {
			distToBorder = playerPos.x - (boxPos.x - boxSizeX / 2);
		}
		force = boxSizeX - distToBorder;

		if (force > 0) {
			if (gameObject.name == "RightBorder") {
				rb.AddForce(Vector3.left * force * forceStrength, ForceMode.Acceleration);
				rb.AddForce(Vector3.down * slowStrength, ForceMode.Acceleration);
				player.GetComponent<PlayerController>().maxSpeedWithThrust *= speedPenalty * Time.fixedDeltaTime;
				player.GetComponent<PlayerController>().thrustAcceleration *= speedPenalty * Time.fixedDeltaTime;
			} else if (gameObject.name == "LeftBorder") {
				rb.AddForce(Vector3.right * force * forceStrength, ForceMode.Acceleration);
				rb.AddForce(Vector3.down * slowStrength, ForceMode.Acceleration);
			}
		}
	}
}
