using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AndroidTest : MonoBehaviour {

    public GameObject planet;
	public Text text;
	string debugText;

	void Update () {
		
		if (Input.touchCount > 0) {
			//touch positions
			for (int i = 0; i < Input.touchCount; i++) {
				if (i == 0) {
					debugText = ("");
				}
				debugText += ("\n Pos " + i + ":" + Input.touches[i].position + "	Touch Phase: " + Input.touches[i].phase);
			}
			text.text = debugText;
		}

















		/*
		// If device supports touch, touch didn't cancel or end
		if (Input.touchSupported) {
			// Ray from screen to touch position
			Ray ray = Camera.main.ScreenPointToRay(Input.touches[0].position);
			RaycastHit hit;
			int layerMask = 1 << 8;

			if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask)) {
				if (Input.touches[0].phase == TouchPhase.Began) {
					Instantiate(planet, hit.point, new Quaternion(0, 0, 0, 0));
				}
			}
		} else {
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			int layerMask = 1 << 8;

			if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask)) {
				if (Input.GetKeyDown(KeyCode.Mouse0)) {
					Instantiate(planet, hit.point, new Quaternion(0, 0, 0, 0));
				}
			}
		}
		*/
	}
}
