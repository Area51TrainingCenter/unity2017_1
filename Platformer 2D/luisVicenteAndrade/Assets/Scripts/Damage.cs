using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour {
	public float damage = 20;  //Definir el daño el arma
	public string TargetTag="enemigo";  //Definir a quien le va a hacer daño
	public bool destroyOntouch;
    // Use this for initialization
    void Start(){

    }

    void OnTriggerEnter2D(Collider2D other){
        //Función para verificar que el objetivo de ataque es el correcto
		if (other.CompareTag(TargetTag)) {
            //Operación para disminuir la vida de objetivo en base al daño de arma (damage)
			other.GetComponent<Health> ().ChangeHealth (damage, gameObject);
			if (destroyOntouch) {
				Destroy (gameObject);
			}
		}
    }
}
