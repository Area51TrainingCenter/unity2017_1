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
        Time.timeScale = 0.3f;
        Debug.Log(other.name);
      
    }
    void OnTriggerExit(Collider other)
    {
        Time.timeScale = 1f;

    }
}
