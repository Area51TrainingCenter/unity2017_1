using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestruirDespuesdeSegundos : MonoBehaviour {

	// Use this for initialization
	void Start () {
        //Invoke ejecutará la funcion "Destruir" 
        Invoke("Destruir", 6);
	}
	
	
	void Destruir() {
        Destroy(gameObject);
	}
}
