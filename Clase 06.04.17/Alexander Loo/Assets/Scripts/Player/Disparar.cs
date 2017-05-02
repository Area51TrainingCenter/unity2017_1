using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparar : MonoBehaviour {

    //esta variable nos sirve para recibir el prefab del proyectil
    public GameObject _prefab;
	void Start () {
        
       
	}
	
	
	void Update () {
        bool disparo = Input.GetMouseButtonDown(0);
        if (disparo)
        {
            //Instantiate crea un clon del prefab que le damos
            Instantiate(_prefab,transform.position,transform.rotation);
        }
	}
}
