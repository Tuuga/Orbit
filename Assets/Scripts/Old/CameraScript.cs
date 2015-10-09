using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

	GameObject player;
	Vector3 cameraPos;
    public float y;
    public float z;
	public Material skybox1;
	public Material skybox2;


	void Start () {
		player = GameObject.Find("Player");
	}

	void Update () {

		if (player != null) {
			z += Input.mouseScrollDelta.y;
			cameraPos = player.transform.position;
			cameraPos.z = z;
			cameraPos.y = player.transform.position.y + y;
			transform.position = cameraPos;
		}

		if (Input.GetKeyDown(KeyCode.F)) {
			RenderSettings.skybox = skybox1;
		}
		if (Input.GetKeyDown(KeyCode.V)) {
			RenderSettings.skybox = skybox2;
		}
	}

	void UpdateEnvironment () {
	}
}
