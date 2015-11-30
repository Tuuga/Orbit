using UnityEngine;
using System.Collections;

public class AlertManagerScript : MonoBehaviour {

	public GameObject arrow;
	public GameObject[] objectsNoArrow;
	public GameObject canvas;

	void Start () {
		SetArrow();
	}

	public void SetArrow() {
		objectsNoArrow = GameObject.FindGameObjectsWithTag("ObjectNoArrow");
		for (int i = 0; i < objectsNoArrow.Length; i++) {
			GameObject arrowIns = (GameObject)Instantiate(arrow, Vector3.zero, new Quaternion(0, 0, 0, 0));
			arrowIns.transform.SetParent(canvas.transform,false);
			arrowIns.GetComponent<ObjectAlert>().aObject = objectsNoArrow[i];
			objectsNoArrow[i].tag = "ObjectHasArrow";
		}
	}
}
