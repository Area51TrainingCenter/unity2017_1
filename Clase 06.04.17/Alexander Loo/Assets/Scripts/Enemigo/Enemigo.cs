using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour {

    public float frecuencia = 2;
    public GameObject proyectil;
    //Esta variable nos da acceso al transform del objeto vacío
    //public Transform _spawn;
    public Transform[] _spawns;

    void Start () {
        //InvokeRepeating("nombre de funcion a llamar",tiempo de espera para iniciar, frecuencia)
        InvokeRepeating("Disparo", 0, frecuencia);
    }
	
	
	void Update () {
		
	}

    void Disparo()
    {
        //Quaternion es el tipo de variable para almacenar rotaciones
        //Quaternion rotacion = Quaternion.Euler(0, 0, 180);
        //Instantiate(proyectil, _spawn.position, _spawn.rotation);

        for (int i=0; i < _spawns.Length; i++)
        {
            Instantiate(proyectil, _spawns[i].position, _spawns[i].rotation);
        }
    }
    
    
}
