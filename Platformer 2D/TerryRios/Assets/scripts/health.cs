using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class health : MonoBehaviour {
	public float Health = 100;
	public float maxHealth = 100;
	public GameObject lastAttacker;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	public void ChangeHealth (float Damage,GameObject attacker) 
	{
		Health -= Damage;
		if (Health > maxHealth) 
		{
			Health = maxHealth;
		}
		if (Health < 0) 
		{
			Health = 0;
		}

		lastAttacker = attacker;


	}
}
