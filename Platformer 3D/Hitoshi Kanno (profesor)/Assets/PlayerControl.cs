using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {
	public float speed = 5;
	public float runSpeed = 8;
	public float crouchSpeed = 1;
	private float verticalSpeed = 0;
	private CharacterController _controller;
	private Animator _animator;
	public float gravity = 10;
	public float jumpForce = 20;
	// Use this for initialization
	void Start () {
		_controller = GetComponent<CharacterController> ();	
		_animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		float v = Input.GetAxis ("Vertical");
		float h = Input.GetAxis ("Horizontal");

		Vector3 moveVector = new Vector3 (h, 0, v);
		moveVector.Normalize ();

		if (Input.GetButton("Crouch")) {
			moveVector *= crouchSpeed;
		} else {
			
			if (Input.GetButton("Run")) {
				moveVector *= runSpeed;
			}else{
				moveVector *= speed;
			}
		}

		if (_controller.isGrounded) {
			verticalSpeed = -0.1f;
			if (Input.GetButtonDown("Jump")) {
				verticalSpeed = jumpForce;
			}
		}else{
			verticalSpeed -= gravity*Time.deltaTime;
		}


		Vector3 gravityVector = new Vector3 (0, verticalSpeed, 0); 
		moveVector += gravityVector;
		moveVector *= Time.deltaTime;
		//transform.Translate (moveVector,Space.World);
		_controller.Move (moveVector);
		moveVector.y = 0;
		transform.LookAt (transform.position + moveVector);

		//lerp requiere 3 valores
		//tu valor inicial
		//el valor de destino
		//velocidad con la que quieres llegar al destino

		//el valor de destino varía segun estemos moviendonos o no
		float end;
		if (h != 0 || v != 0) {
			if (Input.GetButton("Run")) {
				end = 2;
			} else {
				end = 1;
			}
		}else{
			end = 0;
		}
		//el valor inicial es el valor actual del parametro speed
		float start = _animator.GetFloat ("speed");
		//la funcion Lerp SOLAMENTE CALCULA EL NUMERO no hace nada con el animator
		//por lo que almacenamos el resultado de lerp en una variable
		float result = Mathf.Lerp (start, end, Time.deltaTime * 5);
		//y luego lo aplicamos al parametro speed del animator
		_animator.SetFloat ("speed", result);


		if (!_controller.isGrounded) {
			_animator.SetFloat ("verticalSpeed", verticalSpeed);	
		}

		_animator.SetBool ("isGrounded", _controller.isGrounded);
		if (Input.GetButton("Crouch")) {
			_animator.SetBool ("crouch", true);
		} else {
			_animator.SetBool ("crouch", false);
		}
	}
}
