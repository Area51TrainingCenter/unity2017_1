using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrigger : MonoBehaviour {

    public Rigidbody cilindro;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    //el "other" representa el objeto con el cual el trigger colisiona
    {
        if (other.CompareTag("Player"))
        {
            cilindro.isKinematic = false;
        }

    }

}
