using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	void OnTriggerEnter2D (Collider2D other) {
		if (other.CompareTag("Player")) {
			PlayerPrefs.SetFloat ("checkpointX", transform.position.x);
			PlayerPrefs.SetFloat ("checkpointY", transform.position.y);
			Destroy (gameObject);
		}
	}
}
