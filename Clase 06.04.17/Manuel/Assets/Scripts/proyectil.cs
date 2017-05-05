using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class proyectil : MonoBehaviour {
        // este representa cuál es el tag del objeto que buscamos destruir
    public string targetTag;
    public GameObject _explosion;
    public float damage = 30;
	// Use this for initialization
	void Start () {

    }
	
    private void OnTriggerEnter(Collider other)
    {
       
        if (other.CompareTag(targetTag))
        {
            other.GetComponent<Health>().ModificarVida(damage);

            //destruimos el objeto que toca este trigger
            //Destroy(other.gameObject);
            //auto destruimos el objeto
            Destroy(gameObject);
            Instantiate(_explosion, transform.position, transform.rotation);

        }

    }

}
