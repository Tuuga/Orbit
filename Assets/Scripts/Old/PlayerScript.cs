using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour {

	public float shipSpeed = 10;
	public GameObject gameOver;
	public GameObject win;
	public GameObject scoreUi;
	public GameObject gm;

	Text text;

	public int launchCount = 2;

	GameObject cursorPlane;
	Vector3 launchDir;
	bool launching;
	public int score;

	void Awake () {

		transform.parent = GameObject.Find ("Star 1").transform;
		text = scoreUi.GetComponent <Text> ();
	}

	void Start () {

		if (GameObject.Find ("GM(Clone)") == null) {
			Instantiate (gm);
		}
	}

	public void GameOver () {
		gameOver.SetActive (true);
		Time.timeScale = 0;
	}

	void Update () {

		text.text = "Jump Count: " + score + " \nHigh Score: " + GameObject.Find("GM(Clone)").GetComponent<Score>().highScore;
	
		Ray camRay = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hitPoint;

		int layerMask = 1 << 8;

		//Aim at mouse position in world space
		if (Physics.Raycast (camRay, out hitPoint, 100f,layerMask)) {
			transform.LookAt (hitPoint.point);
		}

		//Launch
		if (Input.GetKeyDown(KeyCode.Mouse0) && launchCount > 0) {
			launchDir = transform.forward;
			launchCount --;
			transform.parent = null;
			launching = true;
		}

		//Restart
		if (Input.GetKeyDown(KeyCode.R)) {
			Application.LoadLevel(0);
			Time.timeScale = 1;

		}
	}

	void FixedUpdate () {

		//if m1 -> move towards last mouse position
		if (launching) {
			transform.position += launchDir * Time.fixedDeltaTime * shipSpeed;
		}

	}

	void OnTriggerEnter (Collider c) {

		if (c.gameObject.tag == "Orbit") {
			launching = false;
			launchCount = 2;

			if (transform.parent == null) {
				transform.parent = c.transform.parent;
				score ++;

				if (transform.parent.name == "PlanetWin") {
					win.SetActive (true);
					gm.GetComponent<Score>().HighScoreUpdate();
					Time.timeScale = 0;
				}
			}
		}
	}
	void OnCollisionEnter (Collision c) {
		GameOver();
	}
}
