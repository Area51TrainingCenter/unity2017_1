using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vida : MonoBehaviour {
    public float vida = 100;
    public float maxVida = 100;
	// Use this for initialization
	void Start () {
		
	}
	

    public void ModificarDanio(float dano) {
        vida -= dano;
        if (vida < 0)
        {
            vida=0;
        }
        //para aumentar la vida basta con enviar el parametro dano en negativo
        if (vida > maxVida)
        {
            vida = maxVida;
        }
        Debug.Log("Mi vida es: " + vida);
    }
	// Update is called once per frame
	void Update () {
		
	}
}
