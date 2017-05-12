using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeguirAlAcercarte : MonoBehaviour {
	public GameObject Pelota;
	public float speed = 5;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerEnter (Collider other){
		if (other.CompareTag("Player")) {
			
			Pelota.GetComponent<Persecusion>().Velocidad = speed; 

		}
	}
	private void OnTriggerExit (Collider other){
		if (other.CompareTag("Player")) {

			Pelota.GetComponent<Persecusion>().Velocidad = 0; 

		}
	}

}
