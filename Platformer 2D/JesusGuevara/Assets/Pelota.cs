using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pelota : MonoBehaviour {
	// Destruir Enemigo
	void Start () {
		
	}

	void OnTriggerEnter(Collider other)
	{
		

		if (other.CompareTag("Player"))
		{
			Destroy(other.gameObject);
			Destroy (gameObject);
		}
	}

}
