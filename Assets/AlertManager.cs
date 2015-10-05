using UnityEngine;
using System.Collections;

public class AlertManager : MonoBehaviour {

	public GameObject arrow;
	public GameObject canvas;
	GameObject[] planets;
	GameObject[] arrows;

	void Update() {

		planets = GameObject.FindGameObjectsWithTag("Planet");
		arrows = GameObject.FindGameObjectsWithTag("Arrow");

		//Does not work if planets are added during play (needs fixing)
		//If planet is added planets.lenght != arrows.lenght. For loop the whole list. Add planets.lenght arrows. planets.lenght != arrows.lenght...
		//Always 1 more planet than arrow

		if (planets.Length != arrows.Length) {
			for (int i = 0; i < planets.Length; i++) {
				GameObject arrowIns = (GameObject)Instantiate(arrow, Vector3.zero, new Quaternion(0, 0, 0, 0));
				arrowIns.name = "AlertArrow";
				arrowIns.tag = "Arrow";
				arrowIns.transform.parent = canvas.transform;
				arrowIns.GetComponent<ObjectAlert>().planet = planets[i];
			}
		}
	}
}