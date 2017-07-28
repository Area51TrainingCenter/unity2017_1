using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour {
	
	health salud;
	// Use this for initialization
	void Start () {
		salud=GetComponent<health>();
	}
	
	// Update is called once per frame
	void Update () {
		if(salud.saludActual<=0){
			//Instantiate
			morir();
		}
	}

	public void morir() {
		Destroy(gameObject);
	}
}
