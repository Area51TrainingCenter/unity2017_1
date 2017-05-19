using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
	public float speedX = 5;
	public float gravity = -10;
	private Rigidbody _rigidbody;
	private float verticalSpeed;
	public float rayLength = 0.6f;


	// Use this for initialization
	void Start () {
		_rigidbody = GetComponent<Rigidbody>();

	}


	
	// Update is called once per frame
	void Update () {
		//creamos un Vector3 que comienza en zero
		Vector3 moveVector = new Vector3(0,0,0);

		float h = Input.GetAxis ("Horizontal");
		moveVector.x = h*speedX;

		Vector3 down = new Vector3 (0, -1, 0);

		bool isGrounded = Physics.Raycast(transform.position, down, rayLength);

		if (isGrounded) {
			verticalSpeed = -0.01f;
		} else {
			verticalSpeed += gravity * Time.deltaTime;
		}

		moveVector += new Vector3 (0, verticalSpeed, 0);



		/*
		if (Input.GetKey(KeyCode.A)) {
			moveVector.x = -speedX;
		}
		if (Input.GetKey(KeyCode.D)) {
			moveVector.x = speedX;
		}
		*/
		//en lugar de pasarle los 3 numeros por separado
		//le pasamo a la funcion Translate el Vector3
		//cuando multiplicas un numero por un Vector3
		//Mulitplicas el X, Y y Z por ese numero.

		//transform.Translate (moveVector*Time.deltaTime);

		_rigidbody.velocity = moveVector;

		//transform.Translate (moveX * Time.deltaTime, 0, 0);
	}


}
