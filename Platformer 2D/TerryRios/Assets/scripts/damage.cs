using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damage : MonoBehaviour {
	public float Damage = 20;


	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject.CompareTag("Player")) {
			
		}
		
	}

}
