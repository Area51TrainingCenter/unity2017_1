using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoAI : MonoBehaviour {

    // Script del Enemigo para disparar sus balas

    public GameObject balaEnemigo;
     float numero = 5;
    // Use this for initialization
    void Start () {
        
        InvokeRepeating("Disparo",0,1);
	}
	
	// Update is called once per frame
	void Update () {
  
        if (transform.position.y >= 4.5f)
        {
            numero = -numero;
        }
        
        if (transform.position.y <= -4.5f) {
            numero = -numero ;
        }

        transform.Translate(0, numero*Time.deltaTime, 0);
    }


    void Disparo()
    {
        Quaternion rotacion = Quaternion.Euler(0, 0, 180);
        Instantiate(balaEnemigo, transform.position, rotacion);

    }
}
