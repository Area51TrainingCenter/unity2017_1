using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pelota : MonoBehaviour {

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
			Destroy(other.gameObject); // destruimos objeto que colisiona ( Player )
			Destroy(gameObject); // destruimos este objeto ( Esfera )
		}
	}  
}
