using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class esfera : MonoBehaviour {

    public float speedX = 3f;
    public float speedY = 0f;
    public GameObject explosion;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        MovimientoContinuo();
        
	}
    void MovimientoContinuo()
    {
        
        transform.Translate(speedX * Time.deltaTime, speedY * Time.deltaTime, 0);
    }

    private void OnTriggerEnter(Collider other)
        //el "other" representa el objeto con el cual el trigger colisiona
    {
        if (other.CompareTag("enemigo"))
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
