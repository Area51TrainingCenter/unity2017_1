using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Proyectil del Player
//  Script de bala para destruir el Enemigo

public class Proyectil : MonoBehaviour {

    public GameObject _explosion;
 
    // este representa cual es el tag del objeto que buscamos destruir
    public string targetag;
    public float damage = 30;


    // Use this for initialization
    void Start () {
		
	}
	

    // Other el objeto con que colisiona.
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(targetag))
        {
            //destruimos el objeto que toca este trigger
            //Destroy(other.gameObject);
            // auto destruimos el objeto
            other.GetComponent<Health>().ModificarVida(damage);
            Destroy(gameObject);
            Instantiate(_explosion, other.transform.position, other.transform.rotation);
              
        }

       


    }
}
