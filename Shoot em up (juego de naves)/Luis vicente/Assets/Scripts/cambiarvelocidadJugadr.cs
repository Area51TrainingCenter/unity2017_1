using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cambiarvelocidadJugadr : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	

	void Update () {
		
	}
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Time.timeScale = 0.3f;
            //Debug.Log(other.name);
            PlayerMovement playerScript = other.GetComponent<PlayerMovement>();
            playerScript.speedx = playerScript.speedx / 2;
            playerScript.speedy = playerScript.speedy / 2;
        }       
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Time.timeScale = 1f;
            //Debug.Log(other.name);
            PlayerMovement playerScript = other.GetComponent<PlayerMovement>();
            playerScript.speedx = playerScript.speedx * 2;
            playerScript.speedy = playerScript.speedy * 2;
        }

    }
}
