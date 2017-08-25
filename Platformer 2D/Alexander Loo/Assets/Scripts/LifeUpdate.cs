using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeUpdate : MonoBehaviour {

	//para darle flexibilidad con los nombres de otros corazones
	public string heartNum;

	void Start(){
		
		if (PlayerPrefs.GetInt(heartNum) == 1) {
			gameObject.SetActive (false);
			//Destroy (gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D other){

		if (other.CompareTag ("Player")) {
			//no se pueden guardar booleanos en la memoria, por eso usamos un entero de valor 1
			//al tocar el corazón guardamos en la memoria el dato q ya se toco para q no vuelva a aparecer en escena
			PlayerPrefs.SetInt (heartNum, 1);
			//le aumentamos la vida máxima del player y lo guardamos en la memoria
			Health healthScript = other.GetComponent<Health> ();
			healthScript.maxHealth += 20;
			healthScript.health = healthScript.maxHealth;
			PlayerPrefs.SetFloat ("playerMaxHealth", healthScript.maxHealth);
			Destroy (gameObject);
		}
	}
}
