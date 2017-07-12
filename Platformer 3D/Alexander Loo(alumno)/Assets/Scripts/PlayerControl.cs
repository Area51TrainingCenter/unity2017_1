using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {

	private CharacterController _controller;
	private Animator _animator;

	private float v;
	private float h;
	private bool isCrouch;
	public float speed;
	public float turbo;
	public float crouchSpeed;
	private bool running;
	private float verticalSpeed = 0;
	public float gravity = 10;
	public float jumpForce = 20;

	void Start () {
		_controller = GetComponent<CharacterController> ();
		_animator = GetComponent<Animator> ();
	}

	void Update () {
		 v = Input.GetAxis ("Vertical");
		 h = Input.GetAxis ("Horizontal");
		isCrouch = Input.GetButton("Crouch");
		Vector3 moveVector = new Vector3 (h, 0, v);
		moveVector.Normalize ();

		if (_controller.isGrounded) {
			verticalSpeed = -0.1f;
			if (Input.GetKeyDown(KeyCode.Space)) {
				verticalSpeed = jumpForce;
			}
			if (isCrouch) {
				moveVector *= crouchSpeed;
			}
			else if (Input.GetKey (KeyCode.LeftShift)) {
				moveVector *= turbo;
				running = true;
			} else {
				moveVector *= speed;
				running = false;
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
		//para ver hacia una dirección (posición del objeto + dirección de movimiento)
		transform.LookAt (transform.position + moveVector);
		AnimationsManager ();
	} 

	void AnimationsManager(){

		/*if (Mathf.Abs (v) > 0 || Mathf.Abs(h) > 0) {
			_animator.SetBool ("movement", true);
		} else {
			_animator.SetBool ("movement", false);
		}*/
		float end;
		if (h != 0 || v != 0) {
			if (running) {
				end = 2;
			} else {
				end = 1;
			}
		} else {
			end = 0;
		}
		//el valor inicial es el valor actual del parametro speed
		float start = _animator.GetFloat ("Speed");
		//la función lerp SOLAMANETE CALCULA EL NÚMERO no hace nada con el animator
		//por lo que almacenamos el resultado de lerp en una variable
		float result = Mathf.Lerp (start, end, Time.deltaTime * 5);
		//y luego lo aplicamos al parametro speed del animator
		_animator.SetFloat ("Speed", result);
		_animator.SetBool ("isGrounded", _controller.isGrounded);
		if (!_controller.isGrounded) {
			_animator.SetFloat ("VerticalSpeed", verticalSpeed);
		}
		_animator.SetBool ("isCrouch", isCrouch);
	}
}
