using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour {

    public float speed = 2;
    public GameObject proyectil;
    public float movimientoY = 5;
	void Start () {
        //InvokeRepeating("nombre de funcion a llamar",tiempo de espera para iniciar, frecuencia)
        InvokeRepeating("Disparo", 0, speed);
    }
	
	
	void Update () {

        Movimiento();
		
	}

    void Disparo()
    {
        //Quaternion es el tipo de variable para almacenar rotaciones
        Quaternion rotacion = Quaternion.Euler(0, 0, 180);
        Instantiate(proyectil, transform.position, rotacion);
    }
    void Movimiento()
    {
        
        if (transform.position.y >= 3)
        {
            movimientoY = -movimientoY;
        }
        if (transform.position.y <= -3)
        {
            movimientoY = -movimientoY;
        }
        transform.Translate(0, movimientoY * Time.deltaTime, 0);
    }
    
}
