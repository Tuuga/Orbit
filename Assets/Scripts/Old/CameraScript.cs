using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

	GameObject player;
	Vector3 cameraPos;
    public float y;
    public float z;


	void Start () {
		player = GameObject.Find("Player");
	}

	void Update () {
	
		cameraPos = player.transform.position;
		cameraPos.z = z;
		cameraPos.y = player.transform.position.y + y;
		transform.position = cameraPos;

	}
}
