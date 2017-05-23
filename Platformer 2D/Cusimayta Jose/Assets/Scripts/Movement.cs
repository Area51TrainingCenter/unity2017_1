﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
	public float speedX = 10f;
	public float gravity = -10;
	public float JumpForce=5;
	private Rigidbody _rigidbody;
	private float VerticalSpeed;
	public float RayLenght=0.01f;
	bool Jump=false;
	bool isGrounded, isTop, isRight, isLeft;
	float h;
	public Camera camara;
	// Use this for initialization
	void Start () {
		_rigidbody = GetComponent<Rigidbody> ();
	}
	

	void Update(){ // Update es llamada en cada frame 
		//Les pasamos los inputs a esta función
		h = Input.GetAxis ("Horizontal"); //Detectamos las teclas para el movimiento horizontal
		if (isRight) {
			if (h >= 0) {
				h = 0;
			}
		}
		if (isLeft) {
			if (h <= 0) {
				h = 0;
			}
		}
		if (Input.GetKeyDown (KeyCode.Space) && isGrounded) // Detectamos la tecla de salto cuando el personaje esta en el piso
			Jump = true; //Cambiamos el bool Jump a true, para que el personaje este apto para saltar, si no se le pone esto, el personaje saltara por si solo
	}
	void FixedUpdate () { // UpdateFixed es llamada cada que el motor de fisica se actualiza
		MovimientoLateral ();
	}

	void MovimientoLateral(){
		Vector3 moveVector = new Vector3 (0, 0, 0);
		moveVector.x = h * speedX;
		Vector3 down = new Vector3 (0, -1, 0);
		Vector3 up = new Vector3 (0, 1, 0);
		Vector3 right = new Vector3 (1, 0, 0);
		Vector3 left = new Vector3 (-1, 0, 0);
		Vector3 boxSize = new Vector3 (transform.localScale.x, transform.localScale.y, transform.localScale.z)*0.99f;
		isGrounded = Physics.BoxCast (transform.position, boxSize/2, down, Quaternion.identity, RayLenght);
		isTop = Physics.BoxCast (transform.position, boxSize/2, up, Quaternion.identity, RayLenght);
		isRight = Physics.BoxCast (transform.position, boxSize/2, right, Quaternion.identity, RayLenght);
		isLeft = Physics.BoxCast (transform.position, boxSize/2, left, Quaternion.identity, RayLenght);
		if (isTop) {
			VerticalSpeed = -0.1f;
		}
		if (isRight) {
			if (h >= 0) {
				moveVector.x = 0;
			}
		}
		if (isLeft) {
			if (h <= 0) {
				moveVector.x = 0;
			}
		}
		if (isGrounded) {
			VerticalSpeed = -0.1f;
			if (Jump) {				
				VerticalSpeed = JumpForce;
				Jump = false;
			}
		} else {
			VerticalSpeed += gravity * Time.deltaTime;
		}
		moveVector += new Vector3 (0, VerticalSpeed);
		_rigidbody.velocity = moveVector;
	}		
	void OnDrawGizmos(){
		if (isGrounded)
			Gizmos.color = Color.green;
		else
			Gizmos.color = Color.red;	
		Vector3 boxSize = new Vector3 (transform.localScale.x, transform.localScale.y, transform.localScale.z)*0.99f;
		Gizmos.DrawWireCube (transform.position, boxSize);
		Gizmos.DrawWireCube (transform.position + new Vector3 (0, -1, 0) * RayLenght, transform.localScale);
	}
}