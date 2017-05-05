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
            Destroy(gameObject);
            Instantiate(_explosion, other.transform.position, transform.rotation);

            #region Destruye al objetivo al contacto
            /*
            //destruimos el objeto que toca este trigger
            Destroy(other.gameObject);
            //auto destruimos el objeto
            Destroy(gameObject);
            Instantiate(_explosion, other.transform.position, transform.rotation);
            */
            #endregion
        }

    }
    private void OnBecameInvisible()
    {
        //Destruye el objeto cuando sale de la camara
        Destroy(gameObject);
    }

}
