using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrigger : MonoBehaviour {
    public Rigidbody _prefab;
    //public GameObject explo;

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
            _prefab.isKinematic = false;
            //Destroy(other.gameObject);
            //destruimos el objeto
            //Destroy(gameObject);
           // Instantiate(explo, other.transform.position, other.transform.rotation);
        }


    }
}
