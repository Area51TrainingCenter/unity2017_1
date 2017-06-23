using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestruirDespuesDeSegundos : MonoBehaviour {

	// Use this for initialization
	void Start () {
        //Invoke ejecutará la funcion "Destruir" despues de 5 segundos
        Invoke("Destruir", 5);
	}
	//esta funcion destruye el GameObject
	void Destruir () {
        Destroy(gameObject);
	}
}
