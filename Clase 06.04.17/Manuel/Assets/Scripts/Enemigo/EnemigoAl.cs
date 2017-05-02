using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoAl : MonoBehaviour {
    public GameObject balaEnemigo;
    public Transform _spawn;
    //cuando colocamos [] delante del tipo de variable ... estamos creando
    //un arreglo que contendra elementos de este tipo
    public Transform[] _spawns;
    public float frecDisparo= 0.5f;
    
	// Use this for initialization
	void Start () {
        InvokeRepeating("Disparo", 0, frecDisparo);
	}
	
	// Update is called once per frame
	void Update () {
  
	}

    void Disparo() {
        //Quaternion es el tipo de variable para almacenar rotaciones
        //Quaternion rotacion = Quaternion.Euler(0, 0, 180);
        //como la bala siempre se mueve en direccion a su
        //eje X local ... rotamos la bala
        //para que se vaya hacia la izquierda
        //Instantiate(balaEnemigo, transform.position, rotacion);

        //Ahora creamos la bbala en la posicion y rotacion del objeto vacio
        //Instantiate(balaEnemigo, _spawn.position, _spawn.rotation);

        //el for repite una seccion de codigo una cantidad N de vueltas
        //mientras el contador i sea menor que _spawns.Lenght (el tamaño del arreglo)
        //el for seguira repitiendose

        //al final del for ... i se incrementa en uno
        for (int i = 0; i < _spawns.Length; i++)
        {
            Instantiate(balaEnemigo, _spawns[i].position, _spawns[i].rotation);
        }
    }
}
