using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cambiarvelocidadjugador : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        Time.timeScale = 0.3f;        
    }
    private void OnTriggerExit(Collider other)
    {
        Time.timeScale = 1f;
    }
}
