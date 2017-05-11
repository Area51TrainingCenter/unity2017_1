using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaCongela : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        //Time.timeScale controla el flujo del tiempo dentro del juego
        //cuando este vale 1, el tiempo fluye normal y en 0 esta detenido
        // en 0.3 el tiempo correría más lento

        if (other.CompareTag("Player"))
        {
            //Time.timeScale = 0.3f;
            PlayerMovement playerScript = other.GetComponent<PlayerMovement>();
            playerScript.speedX = playerScript.speedX / 2;
            playerScript.speedY = playerScript.speedY / 2;
            
        }
    }

    //esta función se ejecuta cuando un objeto sale de la zona del trigger
    void OnTriggerExit(Collider other)
    {
        
        if (other.CompareTag("Player"))
        {
            //Time.timeScale = 1;
            PlayerMovement playerScript = other.GetComponent<PlayerMovement>();
            playerScript.speedX = playerScript.speedX * 2;
            playerScript.speedY = playerScript.speedY * 2;
        }
    }

    
           
}

