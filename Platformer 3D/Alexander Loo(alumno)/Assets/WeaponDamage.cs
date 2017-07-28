using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponDamage : MonoBehaviour {

	public float damage;

	void OnTriggerEnter(Collider other){

		if (other.CompareTag ("Enemy")) {

			other.GetComponent<Health> ().ChangeHealth (damage);
		}
	}
}
