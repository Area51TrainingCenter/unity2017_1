using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectil : MonoBehaviour {

   
    public GameObject explosion;
    //targetTag representa cuál es el tag el objeto que buscamos destruir
    public string targetTag;
    public float damage = 30;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
	}
    

    private void OnTriggerEnter(Collider other)
        //el "other" representa el objeto con el cual el trigger colisiona
    {
        if (other.CompareTag(targetTag))
        {
            //destruimos el objeto que toca el trigger
            //Destroy(other.gameObject);

            Health VidaEnemigo = other.GetComponent<Health> ();
            VidaEnemigo.ModificarVida(damage);
            

            //el objeto se autodestruye
            Destroy(gameObject);
            //other.transform.position hace que la animación aparezca desde el enemigo
            Instantiate(explosion, transform.position, transform.rotation);
            
        }

       

    }

}

/*public class BalaEnemiga : MonoBehaviour {

public float speedX = 4f;
public float speedY = 0f;
public GameObject explosion;

// Use this for initialization
void Start()
{

}

// Update is called once per frame
void Update()
{
    MovimientoContinuo();

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
void MovimientoContinuo()
{

    transform.Translate(speedX * Time.deltaTime, speedY * Time.deltaTime, 0);
}*/