using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destruir_en_segundos : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Invoke("Destruir", 5);
	}
	
	
	void Destruir () {
        Destroy(gameObject);
	}
}
