using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destruirdespuesdesegundos : MonoBehaviour {

    public float tiempoDeDestrucción;

	// Use this for initialization
	void Start () {
        //Invoke ejecutará la función "Destruir" después de 5 segundos
        Invoke("Destruir", tiempoDeDestrucción);
	}
	
	// Esta función destruye el game object
	void Destruir () {
        Destroy(gameObject);
	}
}
