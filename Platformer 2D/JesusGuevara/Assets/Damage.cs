using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour {
	public float damage = 20;
	//public GameObject explosionMuerte;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.CompareTag("enemigo")){
			other.GetComponent<Health>().health -= damage; 
			//Instantiate(explosionMuerte, other.transform.position, other.transform.rotation);
		}
	}


}
