using UnityEngine;
using System.Collections;

public class ObjectAlert : MonoBehaviour {

	public GameObject planet;
	public float arrowPosFix;

	Vector3 planetPos;
	Vector3 arrowPosition;

	void Awake () {
		//planet = transform.parent.gameObject;
	}

	void Update () {

		planetPos = planet.transform.position;

		Vector3 planetScreenPoint = Camera.main.WorldToScreenPoint(planetPos);
		arrowPosition = new Vector2 (planetScreenPoint.x, Camera.main.pixelHeight + arrowPosFix);
		transform.position = arrowPosition;
	
	}
}
