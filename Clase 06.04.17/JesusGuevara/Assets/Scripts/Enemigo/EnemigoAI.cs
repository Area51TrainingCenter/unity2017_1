using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoAI : MonoBehaviour {

    // Script del Enemigo para disparar sus balas

    public GameObject[] balasEnemigo;
    //esta variable nos da acceso al componente Transform del objeto vacio
    //public Transform spwan;

    //un arreglo que contendra elementos de ese tipo
    public Transform[] _spawns;
    // Use this for initialization
    void Start () {
        
        InvokeRepeating("Disparo",0,1);
	}
	
	// Update is called once per frame
	void Update () {

        float playerHealth = GetComponent<Health>().health;
        if (playerHealth <= 0)
        {
            Destroy(gameObject);
    
        }

    }


    void Disparo()
    {
        //Quaternion rotacion = Quaternion.Euler(0, 0, 180);
        //Instantiate(balaEnemigo, transform.position, rotacion);

       
        // al final del for... se incrementa en uno
        for (int i = 0; i < _spawns.Length; i++)
        {

            for (int j = 0; j < balasEnemigo.Length; j++)
            {
                Instantiate(balasEnemigo[j], _spawns[i].position, _spawns[i].rotation);
            }

        }

    }
}
