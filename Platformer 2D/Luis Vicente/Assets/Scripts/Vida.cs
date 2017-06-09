using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vida : MonoBehaviour {
	public float vidaActual = 100;
	public float vidaMax = 100;
	public GameObject LastAttacker;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	public void CanbiarSalud (float Danno, GameObject Attacker) {
		vidaActual -= Danno;
		if (vidaActual > vidaMax ) {
			vidaActual = vidaMax;
		}
		if (vidaActual < 0) {
			vidaActual = 0;
		}

		LastAttacker = Attacker;
	}
}
