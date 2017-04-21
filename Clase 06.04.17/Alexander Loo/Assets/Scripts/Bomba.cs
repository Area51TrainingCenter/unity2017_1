using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomba : MonoBehaviour {
    public GameObject _prefap;

	
	void Start () {
		
	}
	
	
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
            Instantiate(_prefap, transform.position, transform.rotation);
        }

    }
}
