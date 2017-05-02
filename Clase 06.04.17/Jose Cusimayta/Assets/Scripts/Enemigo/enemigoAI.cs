using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemigoAI : MonoBehaviour
{

    public GameObject balaEnemigo;
    public Transform[] _spawns;
    public float frecDisparo = 1f;
    // Use this for initialization
    void Start()
    {
        InvokeRepeating("Disparo", 0, frecDisparo);
    }

    // Update is called once per frame
    void Update()
    {


    }
    void Disparo()
    {
        //Quaternion es el tipo de variable para almacenar rotaciones
        //Quaternion rotacion = Quaternion.Euler(0, 0, 180);
        //como la bala siempre se mueve en direccion a su
        //eje X local ... rotamos la bala
        //para que se vaya hacia la izquierda
        //Instantiate(balaEnemigo, transform.position, rotacion);
        //añt + 35 = #
        for (int i = 0; i < _spawns.Length; i++)
        {
            Instantiate(balaEnemigo, _spawns[i].position, _spawns[i].rotation);
        }

    }

}

