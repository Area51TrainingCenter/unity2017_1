using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoAI : MonoBehaviour {
    public GameObject balaEnemigo;
    public float freaDIsparo = 0.5f;
    public float speedarriba = 100;
    // Use this for initialization
    void Start () {
        InvokeRepeating("DisparoEnemigo", 0, freaDIsparo);
        
    }
	
	// Update is called once per frame
	void Update () {
        

        Movimiento();
transform.Translate(0, speedarriba*Time.deltaTime, 0);
        //transform.position.y
    }
    void DisparoEnemigo() { 
        Quaternion rotacion = Quaternion.Euler(0, 0, 180);
    //aparecer una bala al costado del enemigo 
    Instantiate(balaEnemigo, transform.position,rotacion);
    }
    void Movimiento () { 
        if (transform.position.y >= 1.5)
        {
            speedarriba = -speedarriba;
        }
        if (transform.position.y <= -1.5)
        {
            speedarriba = -speedarriba;
        }

    }
}
