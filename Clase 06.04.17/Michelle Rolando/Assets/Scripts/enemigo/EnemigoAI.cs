using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoAI : MonoBehaviour {

    public GameObject[] BalasEnemigo;
    //transform _ spawn me da acceso a otro objeto dentro de la escena.
    //esta variable nos da acceso al componente Transform del objeto vacío
    public Transform _spawn;
    public Transform[] _spawns;
    public float FrecuenciaDisparo = 1f;

    public GameObject explosionMuerte;

    Health healthScript;
    Renderer _renderer;
    //esta variable nos da cuanta vida tenía el enemigo en el frame anterior
    float previousHealth;


	// Use this for initialization
	void Start () {
        //InvokeRepeating hace que cada ciertos segundos se produzca cierta función
        //el segundo es la demora
        //el tercero es el intervalo de tiempo de cuántos segudos se tomará la función en repetir
        //la función InvokeRepeating transforma todo en segundos
        InvokeRepeating("Disparo", 0, FrecuenciaDisparo);
        //se pone en el Start para que se almacene la información y luego la use como cache
        healthScript = GetComponent<Health>();
        _renderer = GetComponent<Renderer>();
        previousHealth = healthScript.health;
    }
	
	// Update is called once per frame
	void Update () {
        
        float PlayerHealth = healthScript.health;

        if (PlayerHealth <= 0)
        {
            Destroy(gameObject);
            Instantiate(explosionMuerte, transform.position, transform.rotation);
        }
        //preguntamos si la vida  en el frame anterior es diferente a la vida actual
        if (previousHealth != healthScript.health)
        {
            _renderer.material.color = Color.white;
            Invoke("RegresarColor", 0.1f);
        }
      
        
        //actualizamos el valor de la variable a la vida actual
        healthScript = GetComponent<Health>();
    }

    void RegresarColor() {
        _renderer.material.color = Color.blue;
        }

void Disparo() {
        //Quaternion es el tipo de variable para almacenar rotaciones
        //Quaternion rotacion = Quaternion.Euler(0, 0, 180);
        //como la bala se mueve en dirección a su eje local X, rotamos la bala para que se vaya hacia la izquierda
        //Instantiate(BalaEnemigo, transform.position, rotacion);

        //ahora creamos la bala en la posición
        //Instantiate(BalaEnemigo, _spawn.position, _spawn.rotation);

        for (int i = 0; i < _spawns.Length; i++)
        {
            //for anidado
            for (int j = 0; j < BalasEnemigo.Length; j++)
            {
                Instantiate(BalasEnemigo[j], _spawns[i].position, _spawns[i].rotation);
            }

            
        }

    }

    
}
