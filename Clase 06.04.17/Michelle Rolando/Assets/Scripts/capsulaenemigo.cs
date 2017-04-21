using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class capsulaenemigo : MonoBehaviour {


    public GameObject explosion;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    //el "other" representa el objeto con el cual el trigger colisiona
    {
        if (other.CompareTag("Player"))
        {
            //destruimos el objeto que toca el trigger
            Destroy(other.gameObject);
            //el objeto se autodestruye
            Destroy(gameObject);
            //other.transform.position hace que la animación aparezca desde el enemigo
            Instantiate(explosion, other.transform.position, transform.rotation);

        }

    }
}