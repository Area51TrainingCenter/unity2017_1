using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponDamage : MonoBehaviour {

	public Transform owner;
	public GameObject hitEffect;
	public float damage;
	public float force;
	public string target = "Enemy";

	void OnTriggerEnter(Collider other){

		if (other.CompareTag (target)) {

			other.GetComponent<Health> ().ChangeHealth (damage);
			Instantiate (hitEffect, transform.position, Quaternion.identity);

			Vector3 dir = other.transform.position - owner.transform.position;
			dir.y = 0;
			dir.Normalize ();
			//Si hacemos un GetComponent y no se encuentra el componente, no ejecuta ningún error...
			//a menos que usemos alguna función con el GetComponent si ejecutará un error
			Enemy _enemyScript = other.GetComponent<Enemy> ();
			if (_enemyScript != null) {
				other.GetComponent<Enemy> ().AddImpact (dir, force);
			}
		}
	}
}
