using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pelotaHijo : MonoBehaviour {
	public GameObject padre;
	public float speed = 0.1f;
	// Use this for initialization
	void Start () {
		padre=GameObject.FindGameObjectWithTag ("enemigo");

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other){
		Debug.Log ("Entro al campo de fuerza");
		if(other.CompareTag("Player")){
			padre.GetComponent<FollowPlayer> ().speed = speed;
		}	
	}	

	void OnTriggerExit(Collider other){
		Debug.Log ("Entro al campo de fuerza");
		if(other.CompareTag("Player")){
			padre.GetComponent<FollowPlayer> ().speed = 0;
		}	
	}	
}
