using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparar : MonoBehaviour {

    // Llamar a objeto ( esto aparece en Inspect, donde luego asignaremos el objeto que queramos)
    public GameObject _prefab;

    // Use this for initialization
    void Start () {

        // este va recibir nuestro objeto desde el panel Script ( lo asignamos cual va ser )
        //Instantiate( _prefab );
	}
	
	// Update is called once per frame
	void Update () {
        /*
        bool keyPressedR = Input.GetKeyDown(KeyCode.R);
        if (keyPressedR)
        {
            Instantiate(_prefab);
        }
        */

        if ( Input.GetMouseButtonDown(0))
        {
            // este va recibir nuestro objeto desde el panel Script ( lo asignamos cual va ser )
            Instantiate( _prefab, transform.position, transform.rotation );
        }

    }
}
