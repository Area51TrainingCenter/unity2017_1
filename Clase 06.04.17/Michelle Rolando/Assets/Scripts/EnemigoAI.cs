using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoAI : MonoBehaviour {

    public GameObject BalaEnemigo;
    public float FrecuenciaDisparo = 1f;
    public float speedX = 0f;
    public float speedY = 10f;

	// Use this for initialization
	void Start () {
        //InvokeRepeating hace que cada ciertos segundos se produzca cierta función
        //el segundo es la demora
        //el tercero es el intervalo de tiempo de cuántos segudos se tomará la función en repetir
        //la función InvokeRepeating transforma todo en segundos
        InvokeRepeating("Disparo", 0, FrecuenciaDisparo);
	}
	
	// Update is called once per frame
	void Update () {
        CambioPosicion ();
	}

    void Disparo() {
        //Quaternion es el tipo de variable para almacenar rotaciones
        Quaternion rotacion = Quaternion.Euler(0, 0, 180);
        //como la bala se mueve en dirección a su eje local X, rotamos la bala para que se vaya hacia la izquierda
        Instantiate(BalaEnemigo, transform.position, rotacion);
    }

    void CambioPosicion ()
    {
        //el "transform.Translate(speedX * Time.deltaTime, speedY * Time.deltaTime, 0);" se declara una vez 
        transform.Translate(speedX * Time.deltaTime, speedY * Time.deltaTime, 0);

        if (transform.position.y >= 2.5)
        {
            speedY = speedY * -1;
            //speedY = -2;(otra forma de hacerlo)
        }
        if (transform.position.y <= -3)
        {
            speedY = speedY * -1;
            //speedY = 2;
        }

    }

}
