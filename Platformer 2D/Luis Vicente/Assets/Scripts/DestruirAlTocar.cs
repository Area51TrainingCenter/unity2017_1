﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestruirAlTocar : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerEnter (Collider other){
		if (other.CompareTag("Player")) {
			Destroy (other.gameObject);
			Destroy (gameObject);

		}
	}
}
