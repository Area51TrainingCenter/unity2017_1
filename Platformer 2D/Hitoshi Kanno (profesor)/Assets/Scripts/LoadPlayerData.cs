using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadPlayerData : MonoBehaviour {

	// Use this for initialization
	void Start () {
		float savedMaxHealth = PlayerPrefs.GetFloat ("playerMaxHealth",0);
		GameObject playerObject = GameObject.FindGameObjectWithTag ("Player");
		if (savedMaxHealth != 0) {
			Health playerHealthScript = playerObject.GetComponent<Health> ();
			playerHealthScript.maxHealth = savedMaxHealth;
			playerHealthScript.health = playerHealthScript.maxHealth;
		}
	}
	
	// Update is called once per frame
	void Update () {

	}
}
