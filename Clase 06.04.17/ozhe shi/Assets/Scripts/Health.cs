using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {
    public float health = 100;

    public float maxHealth = 100;
    // Use this for initialization
    void Start() {

    }
    public void ModificarVida (float dano) { 
        health = health - dano;
        if (health < 0)
        {
            health = 0;
                 }
        if (health > maxHealth)
        { health = maxHealth;
            }
        }
}
