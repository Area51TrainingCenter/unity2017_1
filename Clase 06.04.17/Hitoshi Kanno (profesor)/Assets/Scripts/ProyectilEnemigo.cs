using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProyectilEnemigo : MonoBehaviour {

    public GameObject _explosion;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //destruimos el objeto que toca este trigger
            Destroy(other.gameObject);
            //auto destruimos el objeto
            Destroy(gameObject);
            Instantiate(_explosion, other.transform.position, transform.rotation);
        }
        
    }
}
