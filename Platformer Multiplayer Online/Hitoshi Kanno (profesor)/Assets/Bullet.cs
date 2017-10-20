﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
	public float damage = 20;
	// Use this for initialization
	void Start () {
		
	}
	
	void OnTriggerEnter2D (Collider2D other) {
		other.GetComponent<Health> ().TakeDamage (damage);
		Destroy (gameObject);
	}
}