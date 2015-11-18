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
	float penaltyAmount;
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

		//WIP
		/*
		if (border) {
		Speed & Acceleration -= 10% * time.fixedDeltaTime;
		}
		*/

		if (force > 0) {
			if (gameObject.name == "RightBorder") {
				rb.AddForce(Vector3.left * force * forceStrength, ForceMode.Acceleration);
				rb.AddForce(Vector3.down * slowStrength, ForceMode.Acceleration);

				penaltyAmount = player.GetComponent<PlayerController>().maxSpeedWithThrust * speedPenalty;
                player.GetComponent<PlayerController>().maxSpeedWithThrust -= penaltyAmount * Time.fixedDeltaTime;

				penaltyAmount = player.GetComponent<PlayerController>().thrustAcceleration * speedPenalty;
                player.GetComponent<PlayerController>().thrustAcceleration -= penaltyAmount * Time.fixedDeltaTime;

			} else if (gameObject.name == "LeftBorder") {
				rb.AddForce(Vector3.right * force * forceStrength, ForceMode.Acceleration);
				rb.AddForce(Vector3.down * slowStrength, ForceMode.Acceleration);

				penaltyAmount = player.GetComponent<PlayerController>().maxSpeedWithThrust * speedPenalty;
				player.GetComponent<PlayerController>().maxSpeedWithThrust -= penaltyAmount * Time.fixedDeltaTime;

				penaltyAmount = player.GetComponent<PlayerController>().thrustAcceleration * speedPenalty;
				player.GetComponent<PlayerController>().thrustAcceleration -= penaltyAmount * Time.fixedDeltaTime;
			}
		}
	}
}
