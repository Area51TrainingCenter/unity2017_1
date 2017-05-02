using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestruirDespuesdeSegundos : MonoBehaviour {

    public float destruir = 5;
	void Start () {
        //Invoke ejecutará la función "Destruir" después de 5 segundos
        //Invoke se utiliza una sola vez...
        Invoke("Destruir", destruir);
	}
	
	
	void Destruir () {
        Destroy(gameObject);
	}
}
