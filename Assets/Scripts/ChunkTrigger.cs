using UnityEngine;
using System.Collections;

public class ChunkTrigger : MonoBehaviour {

	GameObject ChunkManager;

	void Awake () {
		ChunkManager = GameObject.Find("ChunkSpawn");
	}
	void OnTriggerEnter (Collider c) {
		if (c.name == "Player" && gameObject == ChunkManager.GetComponent<ChunkManager>().chunkList[2]) {	//If player enters the last chunk
			ChunkManager.GetComponent<ChunkManager>().SpawnChunk();											//Spawn new chunk and destroy the oldest one
		}
	}
}
