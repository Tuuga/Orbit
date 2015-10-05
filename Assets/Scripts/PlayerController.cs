using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float pushStr;
	public float mouseSensitivity;
	public enum moveMode {boost, vertical, turn, cardinal, android};

	public bool boost;
	public bool vertical;
	public bool turn;
    public bool cardinal;
    public bool android;

    float timer;
    Vector3 direction;
    Vector2 mouseCurrent;
	Vector2 mouseDelta;
	Vector2 mouseLast;
	Rigidbody rb;
	
	void Awake () {
		rb = GetComponent<Rigidbody> ();
        transform.LookAt(Vector3.up, Vector3.back);
	}

    void FixedUpdate()
    {

        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitPoint;
        int layerMask = 1 << 8;

        //Aim at mouse position in world space
        if (Physics.Raycast(camRay, out hitPoint, 100f, layerMask))
        {

            if (boost == true)
            {
                direction = hitPoint.point;

                /* Old boost
                direction = hitPoint.point - transform.position;
				transform.LookAt (direction, Vector3.back);
				rb.AddForce (pushStr * direction, ForceMode.Impulse);
                */
            }
        }

        //Stop
        if (Input.GetKey(KeyCode.Mouse1))
        {
            rb.isKinematic = true;
        }
        else
        {
            rb.isKinematic = false;
        }

        if (turn == true)
        {
            rb.AddForce(transform.forward * pushStr);
        }

        //WASD Controls
        if (cardinal) {
            if (Input.GetKey(KeyCode.W))
            {
                rb.AddForce(pushStr * Vector2.up);
            }
            if (Input.GetKey(KeyCode.A))
            {
                rb.AddForce(pushStr * Vector2.left);
            }
            if (Input.GetKey(KeyCode.S))
            {
                rb.AddForce(pushStr * Vector2.down);
            }
            if (Input.GetKey(KeyCode.D))
            {
                rb.AddForce(pushStr * Vector2.right);
            }
            transform.position = new Vector3(transform.position.x, transform.position.y, 0f);
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

            if (Input.GetKey(KeyCode.A)) {
                transform.rotation *= Quaternion.Euler (Vector3.down);
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

            Ray touchRay = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit hitPoint;
            int layerMask = 1 << 8;

            //Aim at touch position in world space
            if (Physics.Raycast(touchRay, out hitPoint, 100f, layerMask)) {
                transform.LookAt(hitPoint.point, Vector3.back);
            }
        }
    }
}
