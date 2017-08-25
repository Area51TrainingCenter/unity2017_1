using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeUpgrade : MonoBehaviour {

	// Use this for initialization
	void Start () {
		int isHeartUsed = PlayerPrefs.GetInt ("HeartUp", 0);
		if (isHeartUsed == 1) {
			Destroy (gameObject);
		}
		
	}
	void Update () 	{
		if (Input.GetKeyDown(KeyCode.I)) {
			PlayerPrefs.DeleteKey("HeartUp");
		}
		
}
	// Update is called once per frame
	void OnTriggerEnter2D (Collider2D other) {
		if (other.CompareTag("Player")) {
			Health healthScript = other.GetComponent<Health> ();
			healthScript.maxHealth += 20;
			healthScript.health = healthScript.maxHealth;
			PlayerPrefs.SetFloat ("PlayerMaxHealth", healthScript.maxHealth);

			PlayerPrefs.SetInt ("HeartUp", 1);
			Destroy	(gameObject);
	}
	}
	}
