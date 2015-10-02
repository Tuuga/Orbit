using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AndroidControls : MonoBehaviour {

	public GameObject planet;

	void Start () {

	}

	void Update () {


		if (Input.touchSupported) {
			if (Input.GetTouch(0).phase == TouchPhase.Began) {
				Ray camRay = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);

				RaycastHit hitPoint;
				int layerMask = 1 << 8;

				//Aim at mouse position in world space
				if (Physics.Raycast(camRay, out hitPoint, Mathf.Infinity, layerMask)) {
					Instantiate(planet, hitPoint.point, new Quaternion(0, 0, 0, 0));
				}
			}
		} else {
			if (Input.GetKeyDown(KeyCode.Mouse0)) {
				Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);

				RaycastHit hitPoint;
				int layerMask = 1 << 8;

				//Aim at mouse position in world space
				if (Physics.Raycast(camRay, out hitPoint, Mathf.Infinity, layerMask)) {
					Instantiate(planet, hitPoint.point, new Quaternion(0, 0, 0, 0));
				}
			}
		}
	}
}
