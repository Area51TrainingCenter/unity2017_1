using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoAI : MonoBehaviour {
    public GameObject[] balasEnemigo; //public GameObject es para abrir ventana para enlazar algo
    public Transform[] spawns;
    public float FTiempo = 0.3f;
   
    // trasnform nos da acceso al compotente transform del objeto vacio
    public bool Estado = true;
    // Use this for initialization
    void Start () {
        InvokeRepeating("Disparo",0,FTiempo);
        
    }
	
	// Update is called once per frame
	void Update () {
       
        
    }
    void Disparo() {
        //Quaternion rotacion = Quaternion.Euler(0, 0, 180);
        //Instantiate(balaEnemigo, transform.position, rotacion);
        //Instantiate(balaEnemigo, spawn.position, spawn.rotation);

        for (int i = 0; i < spawns.Length ; i++)
        {
            for (int j = 0; j < balasEnemigo.Length; j++)
            {
                Instantiate(balasEnemigo[j], spawns[i].position, spawns[i].rotation);
            }
          
        }
    }
    
}
