using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoAl : MonoBehaviour {
    public GameObject[] balasEnemigo;
    public GameObject explosionMuerte;

    //creamos una variable global que almacena la referencia al
    //componente Health... de esta forma no tenemos que hacer GetComponent
    //cada vez que queramos acceder a la vida del enemigo
    Health healthScript;
    Renderer _renderer;
    //esta variable nos da cuanta vida tenia el enemigo en el frame anterior
    float previousHealth;
    // esta variable nos da acceso al componente Transform del objeto vacio
//     public Transform _spawn;
    //cuando colocamos [] delante del tipo de variable ... estamos creando
    //un arreglo que contendra elementos de este tipo
    public Transform[] _spawns;
    public float frecDisparo= 0.5f;
   	// Use this for initialization
	void Start () {
        InvokeRepeating("Disparo", 0, frecDisparo);
        //asignamos la referencia del componente aqui
        healthScript = GetComponent<Health>();
        _renderer = GetComponent<Renderer>();
        previousHealth = healthScript.health;
    }
	
	// Update is called once per frame
	void Update () {
        float playerhealth = healthScript.health;
        if (playerhealth <= 0)
        {
            Destroy(gameObject);
            Instantiate(explosionMuerte, transform.position, transform.rotation);
        }
        //preguntamos si la vida en el frame anterior es diferente a la vida actual
        if (previousHealth != healthScript.health)
        {
            _renderer.material.color = Color.white;
            Invoke("RestaurarColor", 0.2f);
        }
        //actualizamos el valor de la variable a la vida actual
        previousHealth = healthScript.health;
    }
    void RestaurarColor()
    {
        _renderer.material.color = Color.black;
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
            for (int j = 0; j < balasEnemigo.Length; j++)
            {
                Instantiate(balasEnemigo[j], _spawns[i].position, _spawns[i].rotation);
            }
        }
    }
}
