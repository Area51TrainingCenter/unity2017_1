using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuntosVida : MonoBehaviour {
    public float health = 100; // vida actual
    public float maxhealth = 100; // limite de vida

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ModificarVida( float danio )
    {
        health = health - danio;

        if ( health < 0 )
        {
            health = 0;
            Debug.Log("destruido");
        }

        if ( health >= maxhealth )
        {
            health = maxhealth;
        }
    }
}
