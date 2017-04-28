using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoAI : MonoBehaviour {

    // Script del Enemigo para disparar sus balas

    public GameObject balaEnemigo;
    
    public Transform spwan;
    //
    public Transform[] _spawns;
    // Use this for initialization
    void Start () {
        
        InvokeRepeating("Disparo",0,1);
	}
	
	// Update is called once per frame
	void Update () {
  
       
    }


    void Disparo()
    {
        Quaternion rotacion = Quaternion.Euler(0, 0, 180);
        //Instantiate(balaEnemigo, transform.position, rotacion);

       
        // al final del for... se incrementa en uno
        for (int i = 0; i < _spawns.Length; i++)
        {
            Instantiate(balaEnemigo, _spawns[i].position, _spawns[i].rotation);
        }

    }
}
