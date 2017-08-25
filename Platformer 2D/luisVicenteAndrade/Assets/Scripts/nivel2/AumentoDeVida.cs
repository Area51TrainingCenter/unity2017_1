using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AumentoDeVida : MonoBehaviour {
	public string name = "Corazon1";
	// Use this for initialization
	void Start () {
		int kokoro = PlayerPrefs.GetInt (name,0);
		if (kokoro == 1) {
			Destroy (gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter2D(Collider2D other ){
		if (other.CompareTag("Player")) {
			Health _health = other.GetComponent<Health> ();
			_health.maxHealth += 20;
			_health.health = _health.maxHealth;
			PlayerPrefs.SetFloat("PlayerMaxVida",_health.maxHealth);
			PlayerPrefs.SetInt (name, 1);
			Destroy (gameObject); 
		}
	}
}

