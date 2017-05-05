using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambiarVelocidadJugador : MonoBehaviour
{


    void Start()
    {

    }


    void Update()
    {

    }
    //detecta cuando algo entra en colisión 
    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name + " Entró");
        if (other.CompareTag("Player"))
        {
            //  Time.timeScale = 0.3f;
            //Time.timeScale controla el flujo del tiempo(float)
            //el tiempo fluye normal = 1  
            //el tiempo corre mas lento = 0.3f
            //el tiempo se para por completo = 0

            PlayerMovement playerScript = other.GetComponent<PlayerMovement>();
            playerScript.speedx = playerScript.speedx / 2;
            playerScript.speedy = playerScript.speedy / 2;




        }

    }
    //detecta cuando algo sale de la colisión
    void OnTriggerExit(Collider other)
    {
        Debug.Log(other.name + " Salió");
        if (other.CompareTag("Player"))
        {
            //el flujo de tiempo regresa a la normalidad
            //  Time.timeScale = 1;

            PlayerMovement playerScript = other.GetComponent<PlayerMovement>();
            playerScript.speedx = playerScript.speedx * 2;
            playerScript.speedy = playerScript.speedy * 2;
        }
    }
}
