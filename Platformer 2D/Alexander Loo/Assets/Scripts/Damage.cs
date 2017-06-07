using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour {

	public float damage = 20;
	public string targetTag;

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == targetTag) {
			other.GetComponent<Health> ().ChangeHealth(damage);
		}
	}
}
