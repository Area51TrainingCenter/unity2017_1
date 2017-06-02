using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dano : MonoBehaviour {
	public float dano = 20;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void OnTriggerEnter2D (Collider2D other) {
		if (other.CompareTag("enemigo")) {
			other.GetComponent<Vida>().vidaActual -= dano;
		}
	}
}
