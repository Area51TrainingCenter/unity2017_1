using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponDamage : MonoBehaviour {

	public Transform owner;
	public GameObject hitEffect;
	public float damage;
	public float force;

	void OnTriggerEnter(Collider other){

		if (other.CompareTag ("Enemy")) {

			other.GetComponent<Health> ().ChangeHealth (damage);
			Instantiate (hitEffect, transform.position, Quaternion.identity);

			Vector3 dir = other.transform.position - owner.transform.position;
			dir.y = 0;
			dir.Normalize ();
			other.GetComponent<Enemy> ().AddImpact (dir,force);
		}
	}
}
