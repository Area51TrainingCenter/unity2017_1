using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnTouch : MonoBehaviour {


	void Start () {
		
	}
	void Update () {
		
	}
	void OnTriggerEnter(Collider other){
		if(other.CompareTag("Player")){
			Destroy (gameObject);
			Destroy (other.gameObject);
		}
	}
}
