using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrigger : MonoBehaviour {

    public Rigidbody trampa;

    void Start() {


        GetComponent<Renderer>().material.color = Color.red;
	}
	
	
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            trampa.isKinematic = false;
        }
    }
}
