using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arma : MonoBehaviour {
	public float ataque=50f;
	// Use this for initialization
	void Start () {
		ataque = GetComponent<MeleeDamage> ().damage;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other){
		if(other.CompareTag("Enemigo")){
			//Debug.Log("Ataque a enemigo");
			if (other.GetComponent<health>().saludActual>0) {
				other.GetComponent<health>().changeHealth(ataque);
			}
		}
	}
}
