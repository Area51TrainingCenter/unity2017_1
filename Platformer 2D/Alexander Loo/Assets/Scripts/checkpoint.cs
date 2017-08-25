using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkpoint : MonoBehaviour {


	void OnTriggerEnter2D(Collider2D other){

		if (other.CompareTag("Player")) {
			//Para guardar datos en el disco duro
			//En este caso guardamos la posición del checkpoint
			PlayerPrefs.SetFloat ("checkpointX", transform.position.x);
			PlayerPrefs.SetFloat ("checkpointY", transform.position.y);
		}
	}
}
