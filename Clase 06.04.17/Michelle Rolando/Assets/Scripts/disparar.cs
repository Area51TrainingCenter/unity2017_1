using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disparar : MonoBehaviour {


    public GameObject _prefab;
    //esta variable nos sirve para recibir el prefab del proyectil
            
    // Use this for initialization
    void Start() {

	}
	
	// Update is called once per frame
	void Update () {
        CrearProyectil();
        }

    void CrearProyectil()
    {
        bool KeyJPressed = Input.GetKeyDown(KeyCode.J);
        //usar el GetKeyDown para que la función se ejecute una sola vez. El GetKey lo ejecuta siempre
        //también se puede usar el "Input.GetMouseButtonDown(0);" en vez del "Input.GetKeyDown(KeyCode.J)"
        if (KeyJPressed)
        {
            //Instantiate crea un clon del prefab que tenemos y le asignamos
            Instantiate(_prefab, transform.position, transform.rotation);
        }

    }
}
