using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
	public float Danno = 20;

	void Start () {
	;
	}

	void OnTriggerEnter2D (Collider2D other){
		other.GetComponent<Vida> ().CambioDeSalud (Danno);
		Destroy (gameObject);
	}
}
