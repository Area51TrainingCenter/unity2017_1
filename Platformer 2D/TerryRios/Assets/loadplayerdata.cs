using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loadplayerdata : MonoBehaviour {

	// Use this for initialization
	void Start () {

		int lifeupgrade = PlayerPrefs.GetInt ("playermaxhealth", 0);
		GameObject player = GameObject.FindGameObjectWithTag ("Player");
		if (lifeupgrade != 0) {

			player.GetComponent<Health> ().maxHealth = lifeupgrade;



		}
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
