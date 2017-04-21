using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class capsula : MonoBehaviour {
    public float speedx = 1;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {

        Movimiento();

	}

    void Movimiento ()
    {
   
        transform.Translate(speedx* Time.deltaTime, 0, 0);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("enemigo"))
        {
            //destruimos el objeto que toca este trigger
            Destroy(other.gameObject);
            //auto destruimos el objeto
            Destroy(gameObject);
        }
        
    }

}
