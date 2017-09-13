using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void OnTriggerEnter2D (Collider2D other) {
		other.GetComponent<health>().TakeDamage ( 20 );
		Destroy (gameObject);	
	}
}
