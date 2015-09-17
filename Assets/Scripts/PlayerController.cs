using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float pushStr;
	Rigidbody rb;
	
	void Start () {
		rb = GetComponent<Rigidbody> ();
	}

	void Update () {
	
		//WASD Controls
		if (Input.GetKey (KeyCode.W)) {
			rb.AddForce (pushStr * Vector2.up);
		}
		if (Input.GetKey (KeyCode.A)) {
			rb.AddForce (pushStr * Vector2.left);
		}
		if (Input.GetKey (KeyCode.S)) {
			rb.AddForce (pushStr * Vector2.down);
		}
		if (Input.GetKey (KeyCode.D)) {
			rb.AddForce (pushStr * Vector2.right);
		}
	}
}
