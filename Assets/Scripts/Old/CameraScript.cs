using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

	public float defaultCamY;
	public float defaultCamZ;
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
		camZ = defaultCamZ - (speed * cameraZBySpeed);
		camY = defaultCamY + (speed * cameraYBySpeed);
	}
}
