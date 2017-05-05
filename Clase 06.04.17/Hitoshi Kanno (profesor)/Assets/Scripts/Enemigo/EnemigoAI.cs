using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoAI : MonoBehaviour {
    public GameObject[] balasEnemigo;
    //esta variable nos da acceso al componente Transform del objeto vacio
//    public Transform _spawn;
    //cuando colocamos [] delante del tipo de variable... estamos creando
    //un arreglo que contendra elementos de ese tipo
    public Transform[] _spawns;
    public float frecDisparo = 0.5f;
    public GameObject explosionMuerte;


    //creamos una variable global que almacenara la referencia al 
    //componente Health... de esta forma no tenemos que hacer GetComponent
    //cada vez que queramos acceder a la vida del enemigo
    Health healthScript;
    Renderer _renderer;
    //esta variable nos da cuanta vida tenia el enemigo en el frame anterior
    float previousHealth;
	// Use this for initialization
	void Start () {
        InvokeRepeating("Disparo", 0, frecDisparo);
        //asignamos la referencia del componente aquí
        healthScript = GetComponent<Health>();
        _renderer = GetComponent<Renderer>();
        previousHealth = healthScript.health;
	}
	
	// Update is called once per frame
	void Update () {
        float playerHealth = healthScript.health;
        if (playerHealth <= 0)
        {
            Destroy(gameObject);
            Instantiate(explosionMuerte, transform.position, transform.rotation);
        }
        //preguntamos si la vida en el frame anterior es diferente a la vida actual
        if (previousHealth != healthScript.health)
        {
            _renderer.material.color = Color.white;
            Invoke("RestaurarColor", 0.1f);
        }
        //actualizamos el valor de la variable a la vida actual
        previousHealth = healthScript.health;

    }

    void RestaurarColor() {
        _renderer.material.color = Color.black;
    }

    void Disparo() {
        
        //Ahora creamos la bala en la posicion y rotacion del objeto vacio
        //Instantiate(balaEnemigo, _spawn.position, _spawn.rotation);

        //el for repite una seccion de codigo una cantidad N de vueltas
        //mientras el contador i sea menor que _spawns.Length (el tamaño del arreglo)
        //el for seguira repitiendose

        //al final del for... i se incrementa en uno
        for (int i = 0; i < _spawns.Length; i++)
        {
            for (int j = 0; j < balasEnemigo.Length; j++)
            {
                Instantiate(balasEnemigo[j], _spawns[i].position, _spawns[i].rotation);
            }
        }
    }

}
