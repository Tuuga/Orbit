using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	//Strength of the forward throttle
	public float maxSpeedWithThrust;
	public float thrustAcceleration;
	public float gravityPassBoost;

	public float starMaxSpeedBoostRate;
	public float startSpeed;
	public float turnSpeed;
	public bool pc;
	public bool mouseAim;
	public bool android;

	Vector3 lastPos;
	Vector3 playerDelta;
	float currentSpeed;
	float topSpeed;
	GameObject rayPlane;
	Rigidbody rb;
	Text speedText;

	void Awake () {
		rayPlane = GameObject.Find("RayPlane");
		rb = GetComponent<Rigidbody>();
		transform.LookAt(Vector3.up * 10f, Vector3.back);
		lastPos = new Vector3(0, 0, 0);
		speedText = GameObject.Find("SpeedText").GetComponent<Text>();
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
		playerDelta = transform.position - lastPos;
		currentSpeed = playerDelta.magnitude / Time.deltaTime;

		
		if (topSpeed < currentSpeed) {
			topSpeed = currentSpeed;
		}
		//fix for 135 topSpeed at start
        if (Time.time < 0.1f) {
			topSpeed = 0;
		}

		//Speed UI
		speedText.text = "Units/s: " + Mathf.Round(currentSpeed) + "\n<color=red>Top Speed: " + Mathf.Round(topSpeed) + "</color>";
		lastPos = transform.position;
	}

	void Update () {

		rb.drag = thrustAcceleration / maxSpeedWithThrust;
		rayPlane.transform.position = transform.position;

		if (Input.GetKeyDown(KeyCode.Space)) {
			transform.FindChild("GravitySource").GetComponent<Attraction>().mass1 = 0;
		}
		if (Input.GetKeyUp(KeyCode.Space)) {
			transform.FindChild("GravitySource").GetComponent<Attraction>().mass1 = 1;
		}

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
	void OnTriggerEnter (Collider c) {
		if (c.transform.parent != null && c.transform.parent.tag == "Star") {	//If player is in a gravity source of a star
			maxSpeedWithThrust *= gravityPassBoost;                             //Multiplies the max speed
			thrustAcceleration *= gravityPassBoost;								//Multiplies the acceleration
		}
	}
}
