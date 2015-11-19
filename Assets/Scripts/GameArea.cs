using UnityEngine;
using System.Collections;

public class GameArea : MonoBehaviour {

	public Transform player;
	Vector3 pos;

	void Update () {
		pos = new Vector3(0, player.transform.position.y, 0);
		transform.position = pos;
	}
}
