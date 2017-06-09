using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dano : MonoBehaviour {
	public float dano = 20;
	public string targetTag = "enemigo";
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void OnTriggerEnter2D (Collider2D other) {
		if (other.CompareTag(targetTag)) {
			other.GetComponent<Vida>().CanbiarSalud(dano,gameObject);
		}
	}
}
