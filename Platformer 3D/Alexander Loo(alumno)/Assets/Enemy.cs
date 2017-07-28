using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	private Health health;

	void Start(){

		health = GetComponent<Health> ();
	}

	void Update(){

		if (health.health <= 0) {
			transform.rotation = Quaternion.Euler (-90, 180, 0);
			//Destroy (gameObject);
		}
	}
}
