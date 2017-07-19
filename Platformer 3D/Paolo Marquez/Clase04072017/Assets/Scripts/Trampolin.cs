using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampolin : MonoBehaviour {
	private float speedVertical=15f;
	private GameObject playerSaltado;

	// Use this for initialization
	void Start () {
		playerSaltado = GameObject.FindGameObjectWithTag ("Player");

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other) {
		
		playerSaltado.GetComponent<Movimiento> ().verticalSpeed = speedVertical;
		Debug.Log ("Colisiono con trampolin");
	}
}
