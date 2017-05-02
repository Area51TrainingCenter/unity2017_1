using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemigo : MonoBehaviour {
    
    public GameObject _baladeenemigo;
    public float freedisparo = 1.0f;
    //esta variable nos acceso al componente del objeto vacio
    public Transform _spawn;
    public Transform[] _spawns;
    
	// Use this for initialization
	void Start () {
       
	}

    // Update is called once per frame
    void Update() {

        
       
    }
        void disparo()
         {
        //  Quaternion rotacion = Quaternion.Euler(0, 0, 180);
        //Instantiate(_baladeenemigo, transform.position, transform.rotation);

        for ( int i = 0; i < _spawns.Length; i++)
        {
            Instantiate(_baladeenemigo, _spawns[i].position, _spawns[i].rotation);
        }

        }
	}

