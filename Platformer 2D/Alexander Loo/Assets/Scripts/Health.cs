using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

	public float health = 100;
	public float maxHealth = 100;
	public GameObject lastAttacker;

	void Start(){

		health = maxHealth;
	}

	public void ChangeHealth(float damage,GameObject attacker){
		
		health -= damage;
		if (health > maxHealth) {
			health = maxHealth;
		}
		if (health < 0) {
			health = 0;
		}
		lastAttacker = attacker;
	}
}
