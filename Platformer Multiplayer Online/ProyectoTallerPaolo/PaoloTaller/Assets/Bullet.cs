using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	// Se ejecuta cada vez que la bala sela e
	void OnEnable () {
		//hacem
		GetComponent<Rigidbody> ().velocity = Vector3.up * 20;
		;
		Invoke ("destruirBala",2);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void destruirBala() {
		gameObject.SetActive (false);
	}
}
