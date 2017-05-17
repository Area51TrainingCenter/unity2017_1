using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarEnemigo : MonoBehaviour {
	public GameObject Bolita;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	private void OnTriggerEnter(Collider other)
	{
		if(other.CompareTag("Player")){
			Bolita.GetComponent<FollowPlayer> ().velocidad_bolita = 5;
		}
	}
	private void OnTriggerExit(Collider other){
		if(other.CompareTag("Player")){
			Bolita.GetComponent<FollowPlayer> ().velocidad_bolita = 0;
		}
	}
}
