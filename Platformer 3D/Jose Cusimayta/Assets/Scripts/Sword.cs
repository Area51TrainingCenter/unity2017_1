using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour {
	public float damage = 20;  //Definir el daño el arma
	public string TargetTag="enemigo";  //Definir a quien le va a hacer daño
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter(Collider other){
		if (other.CompareTag(TargetTag)) {
			//Operación para disminuir la vida de objetivo en base al daño de arma (damage)
			other.GetComponent<Health> ().ChangeHealth (damage, gameObject);
		}
	}
}
