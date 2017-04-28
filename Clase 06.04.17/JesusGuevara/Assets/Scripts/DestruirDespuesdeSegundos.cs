using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestruirDespuesdeSegundos : MonoBehaviour {

	// Use this for initialization
	void Start () {
        //Invoke ejecutara la funcion "destruir" despues de 5 segundos 
        Invoke("Destruir",5);	
	}
	
	// esta funcion destruye los gameobject
	void Destruir () {
        Destroy(gameObject);
	}
}
