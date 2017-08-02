using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vida : MonoBehaviour {
	
	public float vida = 100;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	public void CambioDeVida(float dano){
		vida -= dano;

	}

}
