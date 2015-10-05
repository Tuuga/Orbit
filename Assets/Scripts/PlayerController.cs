using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float pushStr;

	public bool pc;
	public bool android;

	Rigidbody rb;

	void Awake () {
		rb = GetComponent<Rigidbody>();
		transform.LookAt(Vector3.up, Vector3.back);
	}

	void FixedUpdate () {

		//Stop
		if (Input.GetKey(KeyCode.Mouse1)) {
			rb.isKinematic = true;
		} else {
			rb.isKinematic = false;
		}

		rb.AddForce(transform.forward * pushStr);
	}

	void Update () {

		if (pc == true) {

			if (Input.GetKey(KeyCode.A)) {
				transform.rotation *= Quaternion.Euler(Vector3.down);
			}

			if (Input.GetKey(KeyCode.D)) {
				transform.rotation *= Quaternion.Euler(Vector3.up);
			}

			if (Input.GetKey(KeyCode.W)) {
				pushStr += Time.deltaTime;
			}

			if (Input.GetKey(KeyCode.S)) {
				pushStr -= Time.deltaTime;
			}
		}

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
