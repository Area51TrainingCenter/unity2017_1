using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZonaLenta : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            Debug.Log("Entro: " + other.name);
            PlayerMovement player = other.GetComponent<PlayerMovement>();
            player.speedX = player.speedX / 2;
            player.speedY = player.speedY / 2;

        }


    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            Debug.Log("Entro: " + other.name);
            PlayerMovement player = other.GetComponent<PlayerMovement>();
            player.speedX = player.speedX * 2;
            player.speedY = player.speedY * 2;

        }


    }
}
