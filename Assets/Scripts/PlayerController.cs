using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float pushStr;

	//enum for controls

	Rigidbody rb;
	
	void Start () {
		rb = GetComponent<Rigidbody> ();
	}

	void FixedUpdate () {


		Ray camRay = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hitPoint;
		int layerMask = 1 << 8;

		//Aim at mouse position in world space
		if (Physics.Raycast (camRay, out hitPoint, 100f,layerMask)) {

			if (Input.GetKeyDown (KeyCode.Mouse0)) {
				Vector3 direction = hitPoint.point - transform.position;
				rb.AddForce (pushStr * direction, ForceMode.Impulse);
			}
		}

		if (Input.GetKey(KeyCode.Mouse1)) {
			rb.velocity = Vector3.zero;
		}

		//WASD Controls
		if (Input.GetKey (KeyCode.W)) {
			rb.AddForce (pushStr * Vector2.up, ForceMode.Impulse);
		}
		if (Input.GetKey (KeyCode.A)) {
			rb.AddForce (pushStr * Vector2.left, ForceMode.Impulse);
		}
		if (Input.GetKey (KeyCode.S)) {
			rb.AddForce (pushStr * Vector2.down, ForceMode.Impulse);
		}
		if (Input.GetKey (KeyCode.D)) {
			rb.AddForce (pushStr * Vector2.right, ForceMode.Impulse);
		}
		transform.position = new Vector3 (transform.position.x, transform.position.y, 0f);
	}

	void OnTriggerStay (Collider c) {

		//If input g
			//stay in current radius and orbit at same speed
		//if input g released
			//continue forward with same velocity

	}
}
