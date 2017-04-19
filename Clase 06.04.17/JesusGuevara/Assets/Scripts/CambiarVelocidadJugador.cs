using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambiarVelocidadJugador : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    // Activar la casilla [is trigger] en el espacio BOX Collider del objeto grande
    // En el objeto pequeño añadir Script RIGIbody , dentro activar la casilla: IS Kinematic

        // Detecta cuando algun objeto con colision entra en la zona del Trigger
    void OnTriggerEnter(Collider other)
    {
        // Debug.Log(other.name);
        /*
            Time.timeScale controla el flujo del tiempo dentro del juego. Cuando este vale 1 el tiempo fluye  normal
            normal  y en 0 esta 
         */
        Time.timeScale = 0.3f;// velocidad lento

    }

    private void OnTriggerExit(Collider other)
    {
        Time.timeScale = 2;// velocidad rapita
    }

}
