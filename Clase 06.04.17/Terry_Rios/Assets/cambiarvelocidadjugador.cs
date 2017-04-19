﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cambiarvelocidadjugador : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //detecta cuando un objeto con colision entra en la zona de trigger
    void OnTriggerEnter(Collider other)
    {
        //Time.timeScale 1=velocidad normal 0=tiempo detenido valores intermedios relentizan el tiempo
        Time.timeScale = 0.3F;
        Debug.Log(other.name);
    }

    //detecta cuando un objeto con colision sale de la zona de trigger

    void OnTriggerExit(Collider other)
    {
        Time.timeScale = 1;
        Debug.Log(other.name);
    }
}
