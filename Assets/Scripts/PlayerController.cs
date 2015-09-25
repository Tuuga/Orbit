using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float pushStr;
	public float mouseSensitivity;
	public bool boost;
	public bool vertical;
	public bool turn;

    float timer;
    Vector3 direction;
    Vector2 mouseCurrent;
	Vector2 mouseDelta;
	Vector2 mouseLast;
	Rigidbody rb;
	
	void Awake () {
		rb = GetComponent<Rigidbody> ();
	}

	void FixedUpdate () {

		Ray camRay = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hitPoint;
		int layerMask = 1 << 8;

		//Aim at mouse position in world space
		if (Physics.Raycast (camRay, out hitPoint, 100f,layerMask)) {

			if (boost == true) {
                direction = hitPoint.point;
                
                /* Old boost
                direction = hitPoint.point - transform.position;
				transform.LookAt (direction, Vector3.back);
				rb.AddForce (pushStr * direction, ForceMode.Impulse);
                */
			}
		}

		//Stop
		if (Input.GetKey(KeyCode.Mouse1)) {
			rb.isKinematic = true;
		} else {
			rb.isKinematic = false;
		}

		if (turn == true) {
			rb.AddForce (transform.up * pushStr);
		}

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
		transform.position = new Vector3 (transform.position.x, transform.position.y, 0f);
	}

    void Controls() {
        
        //Boost (power by time held)
        if (Input.GetKeyDown (KeyCode.Mouse0)) {
            timer += Time.deltaTime;
            Debug.Log(timer);
        }

        if (Input.GetKeyUp(KeyCode.Mouse0)) {
            rb.AddForce (timer * pushStr * direction, ForceMode.Impulse);
            timer = 0;
        }
    }
	void Update () {

        if (boost == true) {
            //Boost (power by time held)
            if (Input.GetKey(KeyCode.Mouse0)) {
                transform.LookAt(direction, Vector3.back);
                timer += Time.deltaTime;
                Debug.Log(timer);
            }

            if (Input.GetKeyUp(KeyCode.Mouse0)) {
                rb.AddForce(timer * pushStr * (direction - transform.position).normalized, ForceMode.Impulse);
                timer = 0;
                Debug.Log(timer);
            }
        }

        if (turn == true) {

			mouseCurrent = Input.mousePosition;
			if (Input.GetKey(KeyCode.Mouse0)) {
				mouseDelta = mouseCurrent - mouseLast;
				transform.eulerAngles += new Vector3 (0, 0, mouseDelta.x * mouseSensitivity);
			}
			mouseLast = mouseCurrent;
		}

		if (Input.touchSupported == true) {
			transform.eulerAngles += new Vector3 (0, 0, Input.GetTouch(0).deltaPosition.x);
		}
	}
}
