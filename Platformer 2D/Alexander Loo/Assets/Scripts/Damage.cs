using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour {

	public float damage = 20;

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "enemigo") {
			other.GetComponent<Health> ().health -= damage;
		}
	}
}
