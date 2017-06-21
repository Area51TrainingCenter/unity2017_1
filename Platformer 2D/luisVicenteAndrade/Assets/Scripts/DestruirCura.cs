using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestruirCura : MonoBehaviour {
	public string TargetTag="Player";  //Definir a quien le va a hacer daño

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter2D(Collider2D other){
		//Función para verificar que el objetivo de ataque es el correcto
		if (other.CompareTag(TargetTag)) {
			//Operación para disminuir la vida de objetivo en base al daño de arma (damage)
			Destroy(gameObject);
		}
	}

}
