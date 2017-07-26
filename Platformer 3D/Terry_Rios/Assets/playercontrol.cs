using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {
	public float speed = 5;
	public float runSpeed = 8;
	public float crouchSpeed = 1;
	public bool cancontrol = true;
	public float gravity = 10;
	public float jumpForce = 20;

	public LayerMask _mask;

	private Vector3 moveVector;
	private bool isLowCeiling;
	private bool iscrouched;
	//esto sirve para que una variable publica
	//NO aparezca en el editor
	[System.NonSerialized]
	public float verticalSpeed = 0;
	public Collider _weapon;
	private CharacterController _controller;
	private Animator _animator;

	// Use this for initialization
	void Start () {
		_controller = GetComponent<CharacterController> ();	
		_animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		float v = Input.GetAxis ("Vertical");
		float h = Input.GetAxis ("Horizontal");

		GroundMovement (h, v);

		VerticalMovement ();

		moveVector *= Time.deltaTime;
		_controller.Move (moveVector);
		moveVector.y = 0;
		transform.LookAt (transform.position + moveVector);

		Crouch ();

		SetAnimatorParameters (h, v);
	}

	void FixedUpdate(){
		bool isCrouched = _animator.GetBool ("crouch");
		if (isCrouched) {
			//Physics.Raycast hace el chequeo del raycast pero no vas a poder
			//ver el rayo en si
			if (Physics.Raycast (transform.position, Vector3.up, 4.0f, _mask)) {
				//Debug.DrawRay dibuja la linea... le damos los mismos parametros que el raycast
				//al pasarle la direccion lo multiplicamos por la longitud que del rayo
				Debug.DrawRay (transform.position, Vector3.up * 4.0f, Color.green);
				isLowCeiling = true;
			} else {
				Debug.DrawRay (transform.position, Vector3.up * 4.0f, Color.red);
				isLowCeiling = false;
			}
		}
	}

	void GroundMovement(float h, float v){

		if (cancontrol == true) {

			/*

		(h,0,v)
		(h,0,0) + (0,0,v)
		h*(1,0,0)   +   v*(0,0,1)
		h*Vector3.right    +   v*Vector3.forward

		h*camera.transform.right    +   v*camera.transform.forward

		*/

			//le quitamos el componente "y" a los vectores de la camara
			//para que el player no quiera irse hacia arriba o hacia abajo
			//despues de eso normalizamos el vector para asegurarnos que tenga longitud = 1
			Vector3 cameraForward = Camera.main.transform.forward;
			cameraForward.y = 0;
			cameraForward.Normalize ();

			Vector3 cameraRight = Camera.main.transform.right;
			cameraRight.y = 0;
			cameraRight.Normalize ();


			//Camera.main te devuelve la camara principal de la escena
			//ahora el movimiento del personaje esta en funcion a la camara y no a
			//los ejes globales
			moveVector = (cameraRight * h) + (cameraForward * v);
			moveVector.Normalize ();

			if (Input.GetButton("Crouch") || isLowCeiling) {
				moveVector *= crouchSpeed;
			} else {

				if (Input.GetButton("Run")) {
					moveVector *= runSpeed;
				}else{
					moveVector *= speed;
				}
			}
		}
	}

	void VerticalMovement(){
		if (_controller.isGrounded) {
			verticalSpeed = -0.1f;
			if (Input.GetButtonDown("Jump")&&cancontrol == true) {
				verticalSpeed = jumpForce;
			}
		}else{
			verticalSpeed -= gravity*Time.deltaTime;
		}


		Vector3 gravityVector = new Vector3 (0, verticalSpeed, 0); 
		moveVector += gravityVector;

	}

	void Crouch(){
		bool isCrouched = _animator.GetBool ("crouch");
		//cuando estamos agachados reducimos el tamaño del CharacterController
		if (isCrouched) {
			_controller.height = 1;
			//no podemos modificar el y de la variable center defrente
			//para eso creamos una copia local
			Vector3 newCenter = _controller.center;
			//la modificamos
			newCenter.y = 0.45f;
			//y luego la asignamos al center de _controller
			_controller.center = newCenter;
		} else {
			if (!isLowCeiling) {
				_controller.height = 1.8f;
				Vector3 newCenter = _controller.center;
				newCenter.y = 0.85f;
				_controller.center = newCenter;
			}
		}
	}

	void SetAnimatorParameters(float h, float v){
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

		if (Input.GetButtonDown ("attack")&&_controller.isGrounded&&cancontrol == true&&iscrouched == false) {

			_animator.SetTrigger ("attack");

		} 

		_animator.SetBool ("isGrounded", _controller.isGrounded);
		if (Input.GetButton("Crouch") || isLowCeiling) {
			_animator.SetBool ("crouch", true);
			iscrouched = true;
		} else {
			_animator.SetBool ("crouch", false);
			iscrouched = false;
		}
	}
}
