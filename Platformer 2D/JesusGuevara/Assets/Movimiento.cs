using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour {
	// Player
	public float speedX = 10f;
	//
	public float gravity = -10f;
	public float raylength = 0.6f;

	private Rigidbody _rigibody;
	private float verticalSpeed;


	// Use this for initialization
	void Start () {
		// Guardamos la referencia la componente RigiBody
		_rigibody = GetComponent<Rigidbody> ();

	}
	
	// Update is called once per frame
	void Update () {
		Mover ();
	}

	// creamos nuestra funcion movimiento
	void Mover() {
		
		Vector3 moveVector = new Vector3(0,0,0);
		float h = Input.GetAxis ("Horizontal");
		float y = Input.GetAxis ("Vertical");

		moveVector.x = h * speedX;
		moveVector.y = y * speedX;	

		Vector3 down = new Vector3(0,-1,0);
		// hacemos raycast  genera un rayo invisible 
		// que te devuelve  true si el rayo toca algo 
		// y false si el rayo no toca nada
		bool isGrounded = Physics.Raycast (transform.position, down, raylength);
		if (isGrounded) {
			//si estoy en el piso el verticalspeed es 
			//un valor negativo pequeño--- esto es para
			// asegurarnos que el player toque el piso
			//y no impida el movernos de lado a lado
			verticalSpeed = -0.1f; 
		} else {
			// la gravedad se va aplicando al verticalspeed
			verticalSpeed += gravity * Time.deltaTime;
		}


		moveVector += new Vector3 (0, verticalSpeed, 0);	
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
		//transform.Translate (moveVector*Time.deltaTime);
		_rigibody.velocity = moveVector;



	}// end movimiento


}
