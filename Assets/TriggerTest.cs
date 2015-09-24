using UnityEngine;
using System.Collections;

public class TriggerTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerStay (Collider c)
    {
        Debug.Log("Trigger");

    }
}
