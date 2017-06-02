using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour {
	public float danio = 20;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter2D( Collider2D other ){
		if (other.CompareTag("enemigo")) {
			other.GetComponent<Health>().health -= danio; 
		}
	}
}
