﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class health : MonoBehaviour {

    public float Health = 100;
    public float MaxHealth = 100;

	// Use this for initialization
	void Start () {

		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ModificarVida(float Vida)
    {
        Health = Health - Vida;
        if (Health <= 0)
        {
            Health = 0;
        }
        if (Health >= MaxHealth)
        {
            Health = MaxHealth;
        }
    }
}