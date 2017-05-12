using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	public float speedX = 1f;
	public Vector3 position;

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		Mover ();
	}

	void Mover(){
		//	creamos un Vector3 que comienza en zero
		Vector3 moverVector = new Vector3(0,0,0);
		// un Vector3 se usa para 2 casos:
		// Coordenadas ( Posicion exacta en el espacio ) 
		// Movimiento  ( Indica cuanto debemos sumar a su posicion actual )

		//	CASO 1: detectamos entradas de tecla
		// if (Input.GetKey(KeyCode.A)) moverVector.x = -speedX;	
		// if (Input.GetKey(KeyCode.D)) moverVector.x =  speedX;
		// al presionar A y D o FlechaIzq y FlechaDer, se empieza a sumar -1 o 1,
		// ahora SI es de inmediato, no tiene suavizado gradual

		//	CASO 1: Mover usando GetAxis
		float h = Input.GetAxis("Horizontal");
		moverVector.x = h*speedX;
		// al presionar A y D o FlechaIzq y FlechaDer, se empieza a sumar -1 o 1,
		// ahora NO es de inmediato tiene un suavizado gradual ( parte de -1 ... a ... 0 ... a ... 1, quedando fijo en -1 o 1 )

		//	en lugar de pasarle los 3 numeros por separado
		//	le pasamos a la función translate el Vector3
		//	cuando multiplicas un numero por Vector3
		//	multiplicas el X, Y, Z por ese numero.
		transform.Translate(moverVector*Time.deltaTime);
	}


}
