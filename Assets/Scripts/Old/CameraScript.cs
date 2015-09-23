using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

	GameObject player;
	Vector3 cameraPos;
    public float y;


	void Start () {
		player = GameObject.Find("Player");
	}

	void Update () {
	
		cameraPos = player.transform.position;
		cameraPos.z = -7;
		cameraPos.y = player.transform.position.y + y;
		transform.position = cameraPos;

	}
}
