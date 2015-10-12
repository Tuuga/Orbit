using UnityEngine;
using System.Collections;

public class ChunkTrigger : MonoBehaviour {

	GameObject ChunkManager;

	void Awake () {
		ChunkManager = GameObject.Find("ChunkSpawn");
	}

	void OnTriggerEnter (Collider c) {
		if (c.name == "Player" && gameObject == ChunkManager.GetComponent<ChunkManager>().chunkList[2]) {
			ChunkManager.GetComponent<ChunkManager>().SpawnChunk();
		}
	}
}
