using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	//Strength of the forward throttle
	public float maxSpeedWithThrust;
	public float thrustAcceleration;
	public float starMaxSpeedBoostRate;
	public float startSpeed;
	public float turnSpeed;
	public bool pc;
	public bool mouseAim;
	public bool android;

	Vector3 lastPos;
	Vector3 playerDelta;
	float currentSpeed;
	GameObject rayPlane;
	Rigidbody rb;

	void Awake () {
		rayPlane = GameObject.Find("RayPlane");
		rb = GetComponent<Rigidbody>();
		transform.LookAt(Vector3.up * 10f, Vector3.back);
		lastPos = new Vector3(0, 0, 0);
		rb.drag = thrustAcceleration / maxSpeedWithThrust;
	}

	void Start () {
		rb.velocity = Vector3.up * startSpeed;
	}

	void FixedUpdate () {

		//Right click to stop the ship
		if (Input.GetKey(KeyCode.Mouse1)) {
			rb.isKinematic = true;
		} else {
			rb.isKinematic = false;
		}
		//Moves the ship forward constantly
		rb.AddForce(transform.forward * thrustAcceleration, ForceMode.Acceleration);
		//Debug.Log(rb.velocity.magnitude);

		playerDelta = transform.position - lastPos;
		currentSpeed = playerDelta.magnitude / Time.deltaTime;
		int intSpeed = (int)currentSpeed;

		Debug.Log("Units/s: " + currentSpeed);

		lastPos = transform.position;
	}

	void Update () {

		

		rayPlane.transform.position = transform.position;

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
			//debug

			if (Input.GetKey(KeyCode.W)) {
				maxSpeedWithThrust += Time.deltaTime * 10;
			}
			if (Input.GetKey(KeyCode.S)) {
				maxSpeedWithThrust -= Time.deltaTime * 10;
			}

			if (mouseAim) {
				Ray touchRay = Camera.main.ScreenPointToRay(Input.mousePosition);
				RaycastHit hitPoint;
				int layerMask = 1 << 8;

				//Aim at mouse position in world space
				if (Physics.Raycast(touchRay, out hitPoint, Mathf.Infinity, layerMask)) {
					//transform.LookAt(hitPoint.point, Vector3.back);
					//transform.Rotate(0, 180, 0);
					
					rb.MoveRotation(Quaternion.LookRotation (transform.position - hitPoint.point, Vector3.back));
				}
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
						transform.Rotate(0, 180, 0);
					}
				}
			}
		}

	}
	//MaxSpeed test
	void OnTriggerEnter (Collider c) {

		if (c.tag == "Star") {
			maxSpeedWithThrust *= maxSpeedWithThrust;
		}
	}
}
