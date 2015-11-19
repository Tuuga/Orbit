using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

	public float minCamY;
	public float minCamZ;
	public float maxCamY;
	public float maxCamZ;
	public float cameraYBySpeed;
	public float cameraZBySpeed;

	GameObject player;
	Vector3 playerPos;
    float camY;
    float camZ;

	void Start () {
		player = GameObject.Find("Player");
	}
	void Update () {

		if (player != null) {
			playerPos = player.transform.position;
			transform.position = new Vector3(playerPos.x, playerPos.y + camY, camZ);
		}
	}
	public void CameraMovement(float speed) {
		camZ = Mathf.Clamp(maxCamZ - (speed * cameraZBySpeed), minCamZ, maxCamZ);
		camY = Mathf.Clamp(minCamY + (speed * cameraYBySpeed), minCamY, maxCamY);
	}
}
