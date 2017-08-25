using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeUpgrade : MonoBehaviour {
	public string name = "corazon1";
	// Use this for initialization
	void Start () {
		int isHeartTaken = PlayerPrefs.GetInt (name, 0);
		if (isHeartTaken == 1) {
			Destroy (gameObject);
		}
	}
	
	void OnTriggerEnter2D (Collider2D other) {
		if (other.CompareTag("Player")) {
			Health healthScript = other.GetComponent<Health> ();
			healthScript.maxHealth += 20;
			//healthScript.maxHealth = healthScript.maxHealth + 20;
			healthScript.health = healthScript.maxHealth;
			PlayerPrefs.SetFloat("playerMaxHealth",healthScript.maxHealth);
			PlayerPrefs.SetInt (name, 1);
			Destroy (gameObject);
		}
	}
}
