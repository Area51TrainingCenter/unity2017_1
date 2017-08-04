using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeDamage : MonoBehaviour {
	public Transform owner;
	public float damage=20f;
	public string target="Enemigo";
	public GameObject hitEffect;
	public float impacto;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other){
		if (other.CompareTag(target)) {
			other.GetComponent<health> ().changeHealth (damage);
			Instantiate (hitEffect, transform.position, Quaternion.identity);
			Vector3 dir = other.transform.position-owner.transform.position;
			dir.y = 0;
			dir.Normalize ();
			Enemigo _enemigoScript = other.GetComponent<Enemigo> ();
			if (_enemigoScript!=null) {
				_enemigoScript.AddImpact (dir,impacto);
			}


		}
	}

}
