using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTriger : MonoBehaviour {
    public Rigidbody _spike;
    public Renderer _rendere; //Opcion 1
	// Use this for initialization
	void Start () {
        _rendere.material.color = Color.red; //Opcion 1

        #region Opcion 2
        /*
       GetComponent<Renderer>().material.color = Color.red;
         */
        #endregion

    }

    // Update is called once per frame
    void Update () {
		
	}
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _spike.isKinematic = false;
        }
    }
}
