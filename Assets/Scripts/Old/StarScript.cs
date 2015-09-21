using UnityEngine;
using System.Collections;

public class StarScript : MonoBehaviour {

	public float rotSpeed;

	void Update () {
	
		transform.Rotate (new Vector3 (0,0,1) * rotSpeed);

	}
}
