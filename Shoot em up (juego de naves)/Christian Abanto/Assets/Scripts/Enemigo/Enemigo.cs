using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour {
    public GameObject _explosion;
    public GameObject[] balasEnemigo;
    public float frecDisparo = 1;
    public float speedY = 2;
    // vamos a obtener componentes especificos de otros 
    public GameObject _proyectilEnemigo;
    // vamos a jalar componentes especificos de otros GameObject
    // public Transform _spawn; // solo obtener el componente transform del GameObject que asigemos en Unity
    // lo mismo que el anterio pero de recogiendo un Arreglo (Array)
    public Transform[] _spawns;

    PuntosVida healthScript;
    Renderer _renderer;
    // esta variable nos da cuanta vida tenia el enemigo en el frame anterior
    float previousHealth;

    // Use this for initialization
    void Start () {
        InvokeRepeating("Disparo", 0, frecDisparo); // todo lo maneja en segundos
        // asignamos la referencia del componente aqui
        healthScript = GetComponent<PuntosVida>();
        _renderer = GetComponent<Renderer>();
        // actualizamod el valor de la variable a la vida actual
        previousHealth = healthScript.health;
    }

    // Update is called once per frame
    void Update () {
        float playerHealth = GetComponent<PuntosVida>().health;

        if (playerHealth <= 0)
        {
            // INSTANCIAR
            Instantiate(_explosion, transform.position, transform.rotation);

            // DESTRUIR
            Destroy(gameObject); // destruimos este objeto ( esta esfera )
        }

        if (previousHealth != healthScript.health)
        {
            _renderer.material.color = Color.red;
            Invoke("restaurarColor", .1f);
        }

        // actualizamos el valor de la variable a la vida actual
        previousHealth = healthScript.health;

    }

    void restaurarColor()
    {
        _renderer.material.color = Color.white;
    }

    void Disparo()
    {
        // EJEMPLO 1
        // Quaternion es el tipo de variable para almacenar rotaciones
        //Quaternion rotationPersonalizada = Quaternion.Euler(0, 0, 180);
        // creamos ( instanciamos prefab ) el proyectil enemigo
        //Instantiate(_proyectilEnemigo, transform.position, rotationPersonalizada );

        // EJEMPLO 2
        //Instantiate(_proyectilEnemigo, _spawn.position, _spawn.rotation);

        for (int i = 0; i < _spawns.Length; i++)
        {
            // Instantiate(_proyectilEnemigo, _spawns[i].position, _spawns[i].rotation);
            for (int j = 0; j < balasEnemigo.Length; j++)
            {
                Instantiate(balasEnemigo[j], _spawns[i].position, _spawns[i].rotation);
            }            
        }

    }
}