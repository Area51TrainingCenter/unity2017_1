using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {
	
	public float speed = 5;
	public float runSpeed = 8;
	// esto sirve para que una variable publica , no aparesca en el editor
	[System.NonSerialized]
	public float verticalSpeed = 0;
	private CharacterController _controller;
	private Animator _animator;
	public float gravity = 10;
	public float jumpForce = 20;

	public float crouchSpeed = 1;

	public Vector3 moveVector;
	public bool isCrouch;

	public LayerMask _mask;
	// agachadao modificar el collider 
	public bool isLowColling;// variable para saber el techo esta bajo

	public GameObject _camara;// Camara
	public bool canControl = true;

	public Collider _weapon;

	// Use this for initialization
	void Start () {
		_controller = GetComponent<CharacterController> ();	
		_animator = GetComponent<Animator> ();

	}
	
	// Update is called once per frame
	void Update () {


		float v = Input.GetAxis ("Vertical");
		float h = Input.GetAxis ("Horizontal");

		// --- Function Movimiento ---
		if(canControl){
			GroundMovement (h,v);
		}

		VerticalMovement ();

			
		// --- Function Animacion ---


		moveVector *= Time.deltaTime;	
		//transform.Translate (moveVector,Space.World);
		_controller.Move (moveVector);
		moveVector.y = 0;
		transform.LookAt (transform.position + moveVector);



		Crouch ();

		// --- Function Animacion ---
		SetAnimatorParameters (h,v);

	}

	void GroundMovement(float h, float v){
		 // si cantroncol es falso ejecutar
	
		// PEGAR CON ESPADA
		if (canControl) {
			if (Input.GetMouseButtonDown (0)) {
				if( _controller.isGrounded && !_animator.GetBool("isGrouch")){						
						_animator.SetTrigger("isAttack");
				}
			}
		}


			// Tecla control para Agacharse para agaracharse
			if (Input.GetKey (KeyCode.LeftControl) ) {				
				isCrouch = true;
				_animator.SetBool ("isGrouch", true);			
			} else {			
				if (!isLowColling) {
					isCrouch = false;
					_animator.SetBool ("isGrouch", false);
				}	
			}

			Vector3 cameraForward = Camera.main.transform.forward;
			cameraForward.y = 0;
			cameraForward.Normalize ();

			Vector3 cameraRight = Camera.main.transform.right;
			cameraRight.y = 0;
			cameraRight.Normalize ();

			moveVector = (cameraRight * h) + (cameraForward * v);
			moveVector.Normalize ();


			if (Input.GetButton ("Agacharse") || isLowColling) {			
				moveVector *= crouchSpeed; 

			} else {

				// Tecla shift	
				if (Input.GetButton ("Correr")) {
					moveVector *= runSpeed;
				} else {
					moveVector *= speed;
				}

			}

	}

	void VerticalMovement(){
		
		if (_controller.isGrounded) {

			verticalSpeed = -0.1f;
			// ---- Saltar ----
			if (Input.GetKeyDown(KeyCode.Space) && canControl) {
				verticalSpeed = jumpForce;
			}

		}else{

			verticalSpeed -= gravity*Time.deltaTime;
		}

		Vector3 gravityVector = new Vector3 (0, verticalSpeed, 0); 
		moveVector += gravityVector;
		
	}

	void SetAnimatorParameters(float h,float v){

		/*
		 * 	lerp requiere 3 valores
		 * tu valor inicial
		 * el valor de destino
		 * velocidad con la que quieres llegar al destino
		*/

		//el valor de destino varía segun estemos moviendonos o no
		float end;
		if (h != 0 || v != 0) {
			if (Input.GetKey (KeyCode.LeftShift)) {
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


		// ---- animacion para saltar --
		if(!_controller.isGrounded){
			_animator.SetFloat ("verticalSpeed", verticalSpeed);
		}
		_animator.SetBool ("isGrounded", _controller.isGrounded);	

	}

	void FixedUpdate(){
		//Debug.Log ("canControl: " + canControl);

		bool isCrouched = _animator.GetBool ("isGrouch");
		if(isCrouched){
			//Physics Raycast hace el chequeo del raycast pero no vas a poder	
			if (Physics.Raycast (transform.position, Vector3.up, 4.0f, _mask)) {
				// Debug DrawRay dibuja la linea... le damos los mismos parametros que el raycast
				// al pasarle la direccion lo multiplicamos por la longitud 
				Debug.DrawRay (transform.position, Vector3.up*4.0f, Color.grey);
				isLowColling = true;
			} else {
				isLowColling = false;
				Debug.DrawRay (transform.position, Vector3.up*4.0f, Color.red);
			}
		}
		
	}

	void Crouch(){

		if (isCrouch) { 
	
			_controller.height = 1;
			Vector3 newcenter = _controller.center;
			newcenter.y = 0.45f;
			_controller.center = newcenter;

		} else {

			if(!isLowColling){
				_controller.height = 1.8f;
				Vector3 newcenter = _controller.center;
				newcenter.y = 0.85f;
				_controller.center = newcenter;


			}
		}

	}


	public void EnableweaponTrail(){
		_weapon.GetComponentInChildren<TrailRenderer> ().time = 0.3f;

	}

	public void DisableweaponTrail(){
		_weapon.GetComponentInChildren<TrailRenderer> ().time = 0.0f;
	}


}
