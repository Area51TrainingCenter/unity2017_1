﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class segundocubo : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        //Time.timeScale controla el flujo del tiempo dentro del juego
        //cuando este vale 1, el tiempo fluye normal y en 0 esta detenido
        // en 0.3 el tiempo correría más lento

        if (other.CompareTag("Player"))
        {
            Time.timeScale = 0.3f;
        }
    }

    //esta función se ejecuta cuando un objeto sale de la zona del trigger
    private void OnTriggerExit(Collider other)
    {
        
        if (other.CompareTag("Player"))
        {
            Time.timeScale = 1;
        }
    }

    
           
}

