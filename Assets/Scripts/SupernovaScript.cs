using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SupernovaScript : MonoBehaviour {

	public float speed;
	public float maxDist = 100f; //If player is maxDist units away from supernova, the indicator is transparent
	public Color snIndicator;
	float acceleration = 1f;
	float snToPlayerDist;
	GameObject player;
	Image supernovaDist;

	void Awake () {
		player = GameObject.Find("Player");
		supernovaDist = GameObject.Find("SupernovaDistance").GetComponent<Image>();
	}
	void Update () {
		snToPlayerDist = Vector3.Distance(transform.position, player.transform.position);
		snToPlayerDist = Mathf.Clamp(snToPlayerDist, 0, maxDist);
		supernovaDist.color = new Color(snIndicator.r, snIndicator.g, snIndicator.b, 1 - (snToPlayerDist / 100));
	}

	void FixedUpdate () {
		acceleration += 0.01f; //Magic number
		transform.position += Vector3.up * speed * acceleration * Time.fixedDeltaTime;
	}

	void OnTriggerEnter(Collider c) {
		if (c.tag == "Player") {
			Debug.Log("Supernova hit player");
		}
	}
}
