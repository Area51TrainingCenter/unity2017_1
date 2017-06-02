using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour {
	public string targetTag;
	public float damage = 20;
	// Use this for initialization
	void Start () {
		
	}
	
	void OnTriggerEnter2D(Collider2D other) {
		if (other.CompareTag(targetTag)) {
			other.GetComponent<Health> ().health -= damage;
		}
	}
}
