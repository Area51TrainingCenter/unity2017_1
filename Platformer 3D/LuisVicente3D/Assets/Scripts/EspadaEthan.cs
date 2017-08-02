﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EspadaEthan : MonoBehaviour {
	public float ataque = 20;
	public GameObject efecto;
	public Transform owner;
	public float empuje;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter (Collider other){
		
		if (other.CompareTag("Enemy")) {
			other.GetComponent<Vida> ().CambioDeVida ( ataque );
			Quaternion angulo = Quaternion.Euler(0,0,0); 
			Instantiate (efecto, transform.position, angulo);
			Vector3 dir = other.transform.position - owner.transform.position;
			dir.y = 0;
			dir.Normalize ();
			other.GetComponent<EnemyAi> ().AddImpact (dir, empuje);;
		}

	}
}
	