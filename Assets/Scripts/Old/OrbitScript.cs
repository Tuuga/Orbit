using UnityEngine;
using System.Collections;

public class OrbitScript : MonoBehaviour {

	public GameObject orbitAround;

	public int direction;
	public float orbSpeed;
	public float rotSpeed;

	void Start () {

		DirRand();
		orbSpeed = Random.Range (10,20);
	}

	void DirRand () {

		direction = (int)Random.Range(-1,2);
		if (direction == 0) {
			DirRand();
		}
	}

	void Update () {

		transform.RotateAround (orbitAround.transform.position, new Vector3 (0,0,direction) , orbSpeed * Time.deltaTime);
		transform.Rotate (new Vector3 (0,0,1) * rotSpeed);

	}
}
