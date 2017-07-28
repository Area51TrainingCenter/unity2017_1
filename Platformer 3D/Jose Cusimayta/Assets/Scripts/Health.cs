using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {
	public float health = 100;
	public float maxHealth = 100;
	public GameObject lastAttacker;
	// Use this for initialization
	void Start()
	{

	}

	// Esta función detecta quien es el objeto atacante define el daño a realizar
	public void ChangeHealth(float damage, GameObject attacker){
		health -= damage;           //Realizamos la operación del daño
		if (health > maxHealth)     //Comprobamos que su valor máximo sea la salud máxima
			health = maxHealth;
		if (health < 0)             //Comprobamos que su valor minimo sea 0
			health = 0;
		lastAttacker = attacker;    //Guardamos la variable del atacante
	}
}
