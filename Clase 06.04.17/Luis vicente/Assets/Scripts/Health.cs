using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {
    public float vida = 100;
    public float vidaTotal = 100;
    // Use this for initialization
    void Start () {
		
	}
    //esta funcion sirve tanto para aplicar dano como para recuperar vida
    public void ModificarVida(float dano){
        vida = vida - dano;
        if (vida < 0)
        {
            vida = 0;
        }
        if (vida > vidaTotal)
        {
            vida = vidaTotal;
        }
    }

	// Update is called once per frame
	void Update () {
		
	}
}
