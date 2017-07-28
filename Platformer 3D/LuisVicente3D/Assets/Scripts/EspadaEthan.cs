using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EspadaEthan : MonoBehaviour {
	public float ataque = 20;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter (Collider other){
		if (other.CompareTag("Enemy")) {
			other.GetComponent<Vida> ().CambioDeVida ( ataque );
		}

	}
}
