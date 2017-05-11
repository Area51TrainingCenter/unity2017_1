using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleDetected : MonoBehaviour {

    public Rigidbody _capsule;

	// Use this for initialization
	void Start () {
        //GetComponent<Renderer>().material.color = Color.red;	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _capsule.isKinematic = false;
        }
    }
}
