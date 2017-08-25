using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lifeupgrade : MonoBehaviour {

	public string name = "heart1";

	// Use this for initialization 
	void Start () {
		
		int ishearttaken = PlayerPrefs.GetInt (name, 0);
		if (ishearttaken == 1) {
			Destroy (gameObject);
		}
					
	}
	
	// Update is called once per frame
	void Update () {
			
	}

	void OnTriggerEnter2D (Collider2D other) {

		if (other.CompareTag ("Player")) {
			
			Health healthscript = other.GetComponent<Health> ();
			healthscript.maxHealth += 25;
			healthscript.health = healthscript.maxHealth;
			PlayerPrefs.SetFloat ("playermaxhealth", healthscript.maxHealth);
			PlayerPrefs.SetInt (name, 1);
			Destroy (gameObject);

		}
	}
}
