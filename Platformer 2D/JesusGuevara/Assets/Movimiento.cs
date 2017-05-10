using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour {
	// Player
	public float speedX = 10f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Mover ();
	}

	// creamos nuestra funcion movimiento
	void Mover() {
		
		Vector3 moveVector = new Vector3(0,0,0);
		float h = Input.GetAxis ("Horizontal");
		moveVector.x = h * speedX;
	
	
		/*
		 * 
		// TECLA A
		bool kewAPressed = Input.GetKey(KeyCode.A);
		if (kewAPressed)
		{
			moveVector.x = -speedX;
		}

	
		// TECLA D
		bool kewDPressed = Input.GetKey(KeyCode.D);
		if (kewDPressed)
		{
			moveVector.x = speedX;
		}*/
			
		//transform.Translate(*Time.deltaTime, 0, 0);
		// En lugar de pasarle los 3 numeros por separado
		// le pasamo a la funcion translate el Vector3
		transform.Translate (moveVector*Time.deltaTime);

	}// end movimiento


}
