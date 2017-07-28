using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Danio : MonoBehaviour {
	public float damage = 20;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other){
		if(other.CompareTag("enemigo")){
			other.GetComponent<Health>().ChangeHealth(damage); 

		}
	}
}
