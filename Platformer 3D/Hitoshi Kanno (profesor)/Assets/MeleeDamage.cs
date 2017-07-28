using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeDamage : MonoBehaviour {
	public float damage = 20;
	// Use this for initialization
	void Start () {
		
	}
	
	void OnTriggerEnter (Collider other) {
		if (other.CompareTag("enemy")) {
			other.GetComponent<Health> ().ChangeHealth (damage);
		}
	}
}
