using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoAI : MonoBehaviour {
	

	private Health _healthScript;


	// Use this for initialization
	void Start () {
		//_rigidbody = GetComponent<Rigidbody> ();
		_healthScript = GetComponent<Health> ();

	}

	void Update(){
		//detectamos cuando han lastimado al enemigo

		//matamos al enemigo cuando tenga vida cero
		if (_healthScript.health <= 0) {
			Destroy (gameObject, 0.1f);
		}
	}

	void FixedUpdate () {


	}
}
