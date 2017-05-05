using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cambiarvelocidadjugador : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerMovement playerMovement = other.GetComponent<PlayerMovement>();
        if (other.gameObject.tag == "Player")
        {
            playerMovement.speedX = playerMovement.speedX / 2;
            playerMovement.speedY = playerMovement.speedY / 2;
            // Time.timeScale = 0.3f;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        PlayerMovement playerMovement = other.GetComponent<PlayerMovement>();
        if (other.gameObject.tag == "Player")
        {
            playerMovement.speedX = playerMovement.speedX * 2;
            playerMovement.speedY = playerMovement.speedY * 2;
            //Time.timeScale = 1f;
        }
        
    }
    //Cusimayta
}