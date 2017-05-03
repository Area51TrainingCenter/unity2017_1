using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour {

    public float frecuencia = 2;
    public GameObject[] balas;
    //Esta variable nos da acceso al transform del objeto vacío
    //public Transform _spawn;
    public Transform[] _spawns;
    public GameObject prefab;
    void Start () {
        //InvokeRepeating("nombre de funcion a llamar",tiempo de espera para iniciar, frecuencia)
        InvokeRepeating("Disparo", 0, frecuencia);
    }
	
	
	void Update () {
        float enemigoHealth = GetComponent<Health>().health;
        if (enemigoHealth == 0)
        {
            Destroy(gameObject);
            Instantiate(prefab, transform.position, transform.rotation);
        }

    }

    void Disparo()
    {
        //Quaternion es el tipo de variable para almacenar rotaciones
        //Quaternion rotacion = Quaternion.Euler(0, 0, 180);
        //Instantiate(proyectil, _spawn.position, _spawn.rotation);

        for (int i=0; i < _spawns.Length; i++)
        {
            for (int j = 0; j < balas.Length; j++)
            {
                Instantiate(balas[j], _spawns[i].position, _spawns[i].rotation);
            }
            
        }
    }
    
    
}
