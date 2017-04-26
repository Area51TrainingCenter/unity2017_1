using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoAI : MonoBehaviour {
    public GameObject balaEnemigo; //public GameObject es para abrir ventana para enlazar algo
    public float FTiempo = 0.3f;
    public float speedY = 5;
    
    public bool Estado = true;
    // Use this for initialization
    void Start () {
        InvokeRepeating("Disparo",0,FTiempo);
       
    }
	
	// Update is called once per frame
	void Update () {
        if (transform.position.y <= -2)
        {
            speedY = -speedY;
        }    
        if (transform.position.y >= 0)
            {
            speedY = -speedY;

        }
      transform.Translate(0 * Time.deltaTime, speedY * Time.deltaTime, 0);
        
    }
    void Disparo() {
        Quaternion rotacion = Quaternion.Euler(0, 0, 180);
        Instantiate(balaEnemigo, transform.position, rotacion);

    }
    
}
