using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadPlayerData : MonoBehaviour {
	private GameObject player;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		Health healthScript = player.GetComponent<Health>() ; 
		float MaxHealthGuardada = PlayerPrefs.GetFloat("PlayerMaxHealth", 100);

		healthScript.maxHealth = MaxHealthGuardada;



	}
	
	// Update is called once per frame
	void Update () {
			
	}
}
