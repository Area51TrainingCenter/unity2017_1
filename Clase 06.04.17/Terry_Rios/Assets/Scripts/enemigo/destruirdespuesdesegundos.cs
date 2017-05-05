using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destruirdespuesdesegundos : MonoBehaviour {
    public float tiempo = 5;

	// Use this for initialization
	void Start () {
        Invoke("destruir", tiempo);

		
	}

    void destruir()
    {
        Destroy(gameObject);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
