using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoAI : MonoBehaviour {
    public GameObject balaEnemigo;
    public float frecDisparo = 0.5f;
    public float speedY = 5;
	// Use this for initialization
	void Start () {
        InvokeRepeating("Disparo", 0, frecDisparo);
	}
	
	// Update is called once per frame
	void Update () {
        //transform.position.y
        if (transform.position.y >= 2.5f)
        {
            speedY = -speedY;
        }
        if (transform.position.y <= -3.5f)
        {
            speedY = -speedY;
        }
        transform.Translate(0, speedY*Time.deltaTime, 0);
	}

    void Disparo() {
        //Quaternion es el tipo de variable para almacenar rotaciones
        Quaternion rotacion = Quaternion.Euler(0, 0, 180);
        //como la bala siempre se mueve en direccion a su
        //eje X local ... rotamos la bala
        //para que se vaya hacia la izquierda
        Instantiate(balaEnemigo, transform.position, rotacion);
    }

}
