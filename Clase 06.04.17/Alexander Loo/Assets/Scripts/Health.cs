using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

    public float health = 100;
    public float maxhealth = 100;

	void Start () {
		
	}
	
	
	void Update () {
		
	}
    //esta funcion sirve tanto para aplicar dano como
    //para recuperar vida
    public void ModificarVida(float dano)
    {
        health -= dano;
        if(health < 0)
        {
            health = 0;
        }
        if(health > maxhealth)
        {
            health = maxhealth;
        }
    }
}
