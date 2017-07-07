using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {
	
	public float speed = 1;
	private float verticalSpeed = 0;
	private CharacterController _controller;
	public float gravity = 10;
	public float jumpForce = 20;
	private float speedRun = 2;
	private bool conditionRun = false;
	private Animator _animator;
	// Use this for initialization
	void Start () {
		_controller = GetComponent<CharacterController> ();	
		_animator = GetComponent<Animator> ();
	}
	

	void Update () {
		
		float v = Input.GetAxis ("Vertical");
		float h = Input.GetAxis ("Horizontal");

		Vector3 moveVector = new Vector3 (h, 0, v);

		moveVector.Normalize ();
		moveVector *= speed;

		if (_controller.isGrounded) {

			verticalSpeed = -0.1f;
			if (Input.GetKeyDown(KeyCode.Space)) {
				
				verticalSpeed = jumpForce;
			}

		}else{
			verticalSpeed -= gravity*Time.deltaTime;
		}

		// SHIFT aumentar velocidad
		conditionRun = false;
		if (Input.GetKey (KeyCode.LeftShift)) {
			conditionRun = true;
			moveVector *= speedRun;		
		} 

		Vector3 gravityVector = new Vector3 (0, verticalSpeed, 0); 

		moveVector += gravityVector;
		moveVector *= Time.deltaTime;
		//transform.Translate (moveVector,Space.World);
		_controller.Move (moveVector);
		moveVector.y = 0;
	
		// ++++++ Animacion Caminar ++++++
		// El valor de destino varia segun estemos movimiendonos o no
		float end;
		if (h != 0 || v != 0) {
			_animator.SetFloat ("speed", 1);
			end = 1;		
		} else {
			end = 0;
			_animator.SetFloat ("speed", 0);
		}

		// Correr
		if (conditionRun) {
			_animator.SetFloat ("speed", 3);
		}
		// el valor inicial es el valor actual del parametro speed
		float start = _animator.GetFloat ("speed");
		// la funcion LERP SOLAMENTE CALCULA el NUMERO no hace nada con el animator
		// por lo que almacenamos el resultado de LERP en una variable
		float result = Mathf.Lerp (start, end, Time.deltaTime * 5);
		// y luego 
		_animator.SetFloat ("speed", result); 
		// ++++++++++++++++++++++++

		transform.LookAt (transform.position + moveVector);
	}
}
