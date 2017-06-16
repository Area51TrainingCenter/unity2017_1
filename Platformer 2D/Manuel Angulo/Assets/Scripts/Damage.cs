using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour {
	public float damage = 20;
	public string targetTag = "enemigo";
	// Use this for initialization
	void Start () {
		
	}
	
	void OnTriggerEnter2D(Collider2D other){
		if (other.CompareTag(targetTag)) {
			other.GetComponent<Health> ().ChangeHealth(damage,gameObject);
		}
	}
}
