using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampa : MonoBehaviour {

    public Rigidbody _preb;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("jugador"))
        {

            _preb.isKinematic = false;
        }
    }

}
