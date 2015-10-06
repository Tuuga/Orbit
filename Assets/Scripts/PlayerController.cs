using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	//Strength of the forward throttle
	public float maxSpeed;
	public float startSpeed;
	public float turnSpeed;
	public bool pc;
	public bool android;

	Rigidbody rb;

	void Awake () {
		rb = GetComponent<Rigidbody>();
		transform.LookAt(Vector3.up, Vector3.back);
	}

	void Start () {
		rb.AddForce(Vector3.up * startSpeed, ForceMode.Impulse);
	}

	void FixedUpdate () {

		//Right click to stop the ship
		if (Input.GetKey(KeyCode.Mouse1)) {
			rb.isKinematic = true;
		} else {
			rb.isKinematic = false;
		}
		//Moves the ship forward constantly
		rb.AddForce(transform.forward * maxSpeed);
		Debug.Log(rb.velocity.magnitude);
	}

	void Update () {

		//PC inputs
		if (pc == true) {

			//A and D for turning
			if (Input.GetKey(KeyCode.A)) {
				transform.rotation *= Quaternion.Euler(Vector3.down * turnSpeed);
			}
			if (Input.GetKey(KeyCode.D)) {
				transform.rotation *= Quaternion.Euler(Vector3.up * turnSpeed);
			}
			//W and S for throttle
			if (Input.GetKey(KeyCode.W)) {
				maxSpeed += Time.deltaTime * 10;
			}
			if (Input.GetKey(KeyCode.S)) {
				maxSpeed -= Time.deltaTime * 10;
			}
		}

		//Android Inputs
		if (android) {

			if (Input.touchCount > 0) {
				Ray touchRay = Camera.main.ScreenPointToRay(Input.touches[0].position);
				RaycastHit hitPoint;
				int layerMask = 1 << 8;

				//Aim at touch position in world space
				if (Input.touches[0].phase == TouchPhase.Began || Input.touches[0].phase == TouchPhase.Moved) {
					if (Physics.Raycast(touchRay, out hitPoint, Mathf.Infinity, layerMask)) {
						transform.LookAt(hitPoint.point, Vector3.back);
					}
				}
			}
		}
	}
}
