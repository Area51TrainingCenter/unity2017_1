using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class proyectil : MonoBehaviour {
    
    //este representa cuál es el tag del objeto que buscamos destruir
    public string targetTag;
    public GameObject _explosion;
    public float damage=30;
    // Use this for initialization 
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
       
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(targetTag))
        {
            Health _health = other.GetComponent<Health>();
            _health.ModificarVida(damage);
            Instantiate(_explosion, transform.position, transform.rotation);
            Destroy(gameObject);        
        }

    }
    private void OnBecameInvisible()
    {
        //Destruye el objeto cuando sale de la camara
        Destroy(gameObject);
    }

}
