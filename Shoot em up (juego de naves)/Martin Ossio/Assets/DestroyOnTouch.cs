using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnTouch : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	

	void OnTriggerEnter (Collider other) {
		if (other.CompareTag("Player")) {
			Destroy (other.gameObject);
			Destroy (gameObject);
		}
	}
}
