using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
	Health _health;
	// Use this for initialization
	void Start () {
		_health = GetComponent<Health> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (_health.health <= 0) {
			Destroy (gameObject);
		}
	}
}
