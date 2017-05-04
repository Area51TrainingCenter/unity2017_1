﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambiarVelocidadJugador : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //detecta cuando algun objeto con colision
    //entra en la zona del Trigger    
    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name + "player entro");
      
       if (other.CompareTag("Player"))
       {
            //Time.timeScale controla el flujo del tiempo
            //dentro del juego. Cuando este vale
            //1 el tiempo fluye normal y en 0 esta detenido
            //en 0.3 el tiempo correria mas lento
            //       Time.timeScale = 0.3f;

            PlayerMovement playerScript = other.GetComponent<PlayerMovement>();
            playerScript.speedx = playerScript.speedx / 2;
            playerScript.speedy = playerScript.speedy / 2;
        }

        }

    //esta funcion se ejecuta cuando un objeto sale
    //de la zona del trigger
    void OnTriggerExit(Collider other)
    {
        Debug.Log(other.name + "player salio");
       
        if (other.CompareTag("Player"))
        {
            //        Time.timeScale = 1;
            PlayerMovement playerScript = other.GetComponent<PlayerMovement>();
            playerScript.speedx = playerScript.speedx * 2;
            playerScript.speedy = playerScript.speedy * 2;
        }
    }


}
