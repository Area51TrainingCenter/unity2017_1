using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour {
	public float damage = 20;
	public string targetTag = "Enemigo";

	// Use this for initialization
	void Start () {

	}

	void OnTriggerEnter(Collider other){
		if (other.CompareTag(targetTag)) {
			Debug.Log ("Hit");
			other.GetComponent<Health> ().ChangeHealth(damage);

		}
	}
}
