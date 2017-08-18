using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeDamage : MonoBehaviour {
	public Transform owner;
	public string target ="enemy";
	public float damage = 20;
	public GameObject hitEffect;
	public float knockbackForce = 30;
	// Use this for initialization
	void Start () {
		
	}
	
	void OnTriggerEnter (Collider other) {
		if (other.CompareTag(target)) {
			other.GetComponent<Health> ().ChangeHealth (damage);
			Instantiate (hitEffect, transform.position, Quaternion.identity);
			Vector3 dir = other.transform.position - owner.transform.position;
			dir.y = 0;
			dir.Normalize ();
			//como este script será usado tanto por el player como por el enemigo
			//es posible que _enemyScript sea nulo
			EnemyAI _enemyScript = other.GetComponent<EnemyAI> ();
			//debido a esto hacemos este chequeo para evitar errores
			if (_enemyScript != null) {
				_enemyScript.AddImpact (dir, knockbackForce);
			}

		}
	}
}
