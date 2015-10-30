using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ChunkManager : MonoBehaviour {

	public GameObject[] chunks;
	public GameObject chunkParent;
	float nextChunkPos;
	int randomInt;
	Vector3 chunkSpot;

	int rotInt;
	Quaternion[] chunkRot;
	public List<GameObject> chunkList;

	void Awake () {

		nextChunkPos = chunks[0].GetComponent<BoxCollider>().size.y;
		chunkRot = new Quaternion[4];

		chunkRot[0] = Quaternion.Euler(0, 0, 0);
		chunkRot[1] = Quaternion.Euler(0, 0, 90);
		chunkRot[2] = Quaternion.Euler(0, 0, 180);
		chunkRot[3] = Quaternion.Euler(0, 0, 270);


		for (int i = 0; i < 3; i++) {			
			randomInt = (int)Random.Range(0, chunks.Length);
			chunkSpot += new Vector3(0, nextChunkPos, 0);
			GameObject chunkIns = (GameObject)Instantiate(chunks[randomInt], chunkSpot, new Quaternion(0, 0, 0, 0));
			chunkIns.transform.parent = chunkParent.transform;
			chunkList.Add(chunkIns);
		}
	}

	public void SpawnChunk () {

		rotInt = (int)Random.Range(0, 4);
		randomInt = (int)Random.Range(0, chunks.Length);
		Destroy(chunkList[0]);
		chunkList.Remove(chunkList[0]);
		chunkSpot += new Vector3(0, 100, 0);
		GameObject chunkIns = (GameObject)Instantiate(chunks[randomInt], chunkSpot, chunkRot[rotInt]);
		chunkIns.transform.parent = chunkParent.transform;
		chunkList.Add(chunkIns);

	}

	void Update () {
	
	}
}
