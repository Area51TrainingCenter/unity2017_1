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

    Health healthScript;
    Renderer _renderer;
    float previusHealth;
    // Use this for initialization
    void Start () {
        InvokeRepeating("Disparo", 0, frecDisparo);
        healthScript = GetComponent<Health>();
        _renderer = GetComponent<Renderer>();
        previusHealth = healthScript.health;
    }
	
	// Update is called once per frame
	void Update () {
        float enemyHealth = healthScript.health;
        if (enemyHealth <= 0)
        {
            Destroy(gameObject);
            Instantiate(explosionMuerte, transform.position, transform.rotation);
        }
        if (previusHealth != healthScript.health)
        {
            _renderer.material.color = Color.white;
            Invoke("Cambiar", 0.1f);
        }
        previusHealth = healthScript.health;


    }
    void Cambiar()
    {
        _renderer.material.color = Color.green;
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
