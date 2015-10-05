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

			Ray touchRay = Camera.main.ScreenPointToRay(Input.touches[0].position);
			RaycastHit hitPoint;
			int layerMask = 1 << 8;

			if (Input.touches[0].phase == TouchPhase.Began) {
				if (Physics.Raycast(touchRay, out hitPoint, Mathf.Infinity, layerMask)) {
					Instantiate(planet, hitPoint.point, new Quaternion(0, 0, 0, 0));
				}
			}
		}
	}

	public void Reset () {
		GameObject[] allPlanets = GameObject.FindGameObjectsWithTag("Planet");

		for (int i = 0; i < allPlanets.Length; i++) {
			Destroy(allPlanets[i]);
		}
	}
}
