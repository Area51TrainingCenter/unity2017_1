using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour {

    public GameObject _proyectilEnemigo;
    public float frecDisparo = 1;
    public float speedY = 2;

    // Use this for initialization
    void Start () {
        InvokeRepeating("Disparo", 0, frecDisparo); // todo lo maneja en segundos
    }
	
	// Update is called once per frame
	void Update () {

        /* CHRISTIAN: mi code es maaaaas largo :(
        if (estado)
        {
            if (transform.position.y <= 3)
            {
                transform.Translate(0, speed * Time.deltaTime, 0);
            }
            else
            {
                estado = false;
            }
        }
        else
        {
            if (transform.position.y >= -3)
            {
                transform.Translate(0, -speed * Time.deltaTime, 0);
            }
            else
            {
                estado = true;
            }

        }
        */

        // PROFE: su code mas cooorto :)
        // hace que suba y baje el enemigo
            if (transform.position.y >=  3) { speedY = -speedY; }
            if (transform.position.y <= -3) { speedY = -speedY; }
            transform.Translate(0, speedY * Time.deltaTime, 0);
    }

    void Disparo()
    {
        // Quaternion es el tipo de variable para almacenar rotaciones
        Quaternion rotationPersonalizada = Quaternion.Euler(0, 0, 180);
        // creamos ( instanciamos prefab ) el proyectil enemigo
        Instantiate(_proyectilEnemigo, transform.position, rotationPersonalizada );


    }
}
