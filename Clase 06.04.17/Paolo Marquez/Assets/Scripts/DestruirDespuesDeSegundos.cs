using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestruirDespuesDeSegundos : MonoBehaviour {
    public float tiempoEnDestruir = 5;
	// Use this for initialization
	void Start () {
        //invoke ejecutara la funcion destruir cada 5 segundos
        Invoke("Destruir", tiempoEnDestruir);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void Destruir()
    {
        Destroy(gameObject);
    }
}
