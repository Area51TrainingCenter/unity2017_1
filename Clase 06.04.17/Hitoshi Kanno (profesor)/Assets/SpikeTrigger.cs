﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrigger : MonoBehaviour {
    public Rigidbody _spike;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void OnTriggerEnter (Collider other) {
        if (other.CompareTag("Player"))
        {
            _spike.isKinematic = false;
        }

	}
}
