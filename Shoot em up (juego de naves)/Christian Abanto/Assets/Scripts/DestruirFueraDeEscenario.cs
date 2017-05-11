using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestruirFueraDeEscenario : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        // Invoke ejecutara la funcion "Destruir" despues
        Invoke("Destruir", 1);
    }

    void Destruir()
    {
        Destroy(gameObject);
    }
}
