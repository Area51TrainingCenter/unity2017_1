using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeDamage : MonoBehaviour {
	public Transform owner;
	public float damage = 20;
	public GameObject hitEffect;
	public float knockbackForce = 30;
	// Use this for initialization
	void Start () {
		
	}
	
	void OnTriggerEnter (Collider other) {
		if (other.CompareTag("enemy")) {
			other.GetComponent<Health> ().ChangeHealth (damage);
			Instantiate (hitEffect, transform.position, Quaternion.identity);
			Vector3 dir = other.transform.position - owner.transform.position;
			dir.y = 0;
			dir.Normalize ();
			other.GetComponent<EnemyAI> ().AddImpact (dir, knockbackForce);
		}
	}
}
