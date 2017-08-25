using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadPlayerData : MonoBehaviour {

	void Start(){

		//establecemos la vida máxima del player según los datos previamente guardados en la memoria
		Health playerHealth = GameObject.FindGameObjectWithTag ("Player").GetComponent<Health> ();
		playerHealth.maxHealth = PlayerPrefs.GetFloat ("playerMaxHealth",playerHealth.maxHealth);
	}

}
