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

    // esta funcion va detectar cualquier cosa que entre en su volumen
    // OJO: antes, debes ir a Unity y en
    // Componente "Box Collider"
    // activar check 'Is Trigger'
    void OnTriggerEnter(Collider other)
    {
        // other, representa el objeto que ha tocado este elemento ( Zona Lenta )
        Debug.Log(other.name);

        if (other.CompareTag("Player"))
        {
            Time.timeScale = 0.3f;  // timeScale 0 ( juego movimiento detenido ) 
                                    // timeScale 0.1 a 0.9 ( definimos la lentitud )
                                    // timeScale 1 ( juego movimiento normal  )
        }


    }

    void OnTriggerExit(Collider other)
    {
        Time.timeScale = 1f;            
    }
}
