using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AndroidTest : MonoBehaviour {

    public GameObject planet;
	public GameObject player;
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
	}

	public void Reset () {
		GameObject[] allPlanets = GameObject.FindGameObjectsWithTag("Planet");

		for (int i = 0; i < allPlanets.Length; i++) {
			Destroy(allPlanets[i]);
		}
		player.transform.position = new Vector3(0, -20, 0);
		player.GetComponent<Rigidbody>().velocity = new Vector3 (0,0,0);
	}
}
