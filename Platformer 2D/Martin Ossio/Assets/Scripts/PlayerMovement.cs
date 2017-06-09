﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
	public float speedX = 5;
	public float jumpForce = 8;
	public float gravity = -10;

	public float rayLength = 0.6f;

	public LayerMask _mask;

	public bool canControl = true;

	public float invulnerableTime = 1.5f;

	private Rigidbody2D _rigidbody;
	private Animator _animator;
	private SpriteRenderer _spriteRenderer;
	private Health _healthScript;

	private float previousHealth;

	private float verticalSpeed;
	private bool isGrounded;

	private bool hurt;

	private float knockback;
	private float targetAlpha;

	private float h;
	private bool pressedJump;
	// Use this for initialization
	void Start () {
		//guardamos la referencia la componente Rigidbody 
		//en nuestra variable
		_rigidbody = GetComponent<Rigidbody2D>();
		_animator = GetComponentInChildren<Animator> ();
		_healthScript = GetComponent<Health> ();
		_spriteRenderer = GetComponentInChildren<SpriteRenderer> ();
		targetAlpha = 0;

	}
	// Update is called once per frame
	void Update(){

		ReceiveInputs ();

		Hurt ();

		ManageFlipping ();

		ManageAnimations ();

		HandleKnockback ();

		ManageBlinking ();
	}

	//FixedUpdate se ejecuta cada 0.02 segundos
	//aqui incluimos todo el codigo que manipule los rigidbodies
	void FixedUpdate () {
		//creamos un Vector3 que comienza en zero
		Vector3 moveVector = new Vector3(0,0,0);



		// el knockback es el empuje que se la hace al player cuando recibe daño
		if (knockback > 0) {
			moveVector.x = -knockback;
		} else {
			// esto se hace en el estado normal.. mover el player con el input de h
			moveVector.x = h * speedX;
		}



		RaycastHit2D hitInfo;


		Vector3 down = new Vector3 (0, -1, 0);


		Vector3 boxSize = new Vector3 (transform.localScale.x, transform.localScale.y, transform.localScale.z);
		boxSize = boxSize * 0.99f;

		hitInfo = Physics2D.BoxCast (transform.position, boxSize, 0, down, rayLength,_mask.value);
		if (hitInfo.collider == null) {
			isGrounded = false;
		} else {
			isGrounded = true;
		}


		Vector3 up = new Vector3 (0, 1, 0);
		bool hitUp = false;
		hitInfo = Physics2D.BoxCast (transform.position, boxSize, 0, up, rayLength,_mask.value);
		if (hitInfo.collider != null) {
			hitUp = true;
		}
		if (hitUp) {
			verticalSpeed = -1;
		}


		Vector3 left = new Vector3 (-1, 0, 0);
		bool hitLeft = false;
		hitInfo = Physics2D.BoxCast (transform.position, boxSize, 0, left, rayLength,_mask.value);
		if (hitInfo.collider !=null) {
			hitLeft = true;
		}
		/*****************/
		if (hitLeft) {
			if (h < 0) {
				moveVector.x = 0;
			}
		}
		/*****************/



		Vector3 right = new Vector3 (1, 0, 0);
		hitInfo = Physics2D.BoxCast (transform.position, boxSize, 0, right, rayLength,_mask.value);
		bool hitRight = false;
		if (hitInfo.collider != null) {
			hitRight = true;
		}
		/*****************/
		if (hitRight) {
			if (h > 0) {
				moveVector.x = 0;
			}
		}
		/*****************/
		if (isGrounded) {
			//si estoy en el piso el verticalSpeed es 
			//un valor negativo pequeño... esto es para 
			//asegurarnos que el player toque el piso
			//y no impida el movernos de lado a lado
			verticalSpeed = -0.1f;
			if (pressedJump) {
				//aplicamos salto haciendo verticalSpeed sea positivo
				verticalSpeed = jumpForce;
				//ya que hemos aplicado el salto...reseteamos pressedJump
				pressedJump = false;
			}

		} else {
			//la gravedad se va aplicando al verticalSpeed
			verticalSpeed += gravity * Time.deltaTime;
		}


		moveVector += new Vector3 (0, verticalSpeed, 0);

		//en lugar de pasarle los 3 numeros por separado
		//le pasamo a la funcion Translate el Vector3
		//cuando multiplicas un numero por un Vector3
		//Mulitplicas el X, Y y Z por ese numero.
		_rigidbody.velocity = moveVector;
		//transform.Translate (moveVector*Time.deltaTime);
		//transform.Translate (moveX * Time.deltaTime, 0, 0);
	}

	void OnDrawGizmos(){
		if (isGrounded) {
			Gizmos.color = Color.green;	
		} else {
			Gizmos.color = Color.red;
		}

		Vector3 boxSize = new Vector3 (transform.localScale.x, transform.localScale.y, transform.localScale.z);
		boxSize = boxSize * 0.99f;
		Gizmos.DrawWireCube (transform.position, boxSize);

		Vector3 down = new Vector3 (0, -1, 0);
		Vector3 pos = transform.position + (down * rayLength);
		Gizmos.DrawWireCube (pos, boxSize);
	}
	//Controla los inputs del teclado y mouse
	void ReceiveInputs(){
		if (canControl) {
			//necesitamos leer los inputs en cada frame
			//por eso es que lo colocamos en Update
			//y guardamos el resultado en variables globales que 
			//se usaran en FixedUpdate
			h = Input.GetAxis ("Horizontal");

			//si presionas espacio pressedJump permanecera en true
			//hasta que se aplique el salto dentro de FixedUpdate
			if (Input.GetKeyDown (KeyCode.Space) && isGrounded) {
				pressedJump = true;	
			}
		} else {
			h = 0;
		}
	}
	//se encarga de voltear el SpriteRenderer cuando caminas hacia la izquierda o derecha
	void ManageFlipping(){
		if (h<0) {
			_spriteRenderer.flipX = true;
		}
		if (h>0) {
			_spriteRenderer.flipX = false;	
		}
	}



	void ManageBlinking(){
		if (gameObject.layer == 10) {
			Color newColor = _spriteRenderer.color;
			newColor.a = Mathf.Lerp (newColor.a, targetAlpha, Time.deltaTime * 20);
			if (newColor.a < 0.05f) {
				targetAlpha = 1;
			}
			if (newColor.a > 0.95) {
				targetAlpha = 0;
			}
			_spriteRenderer.color = newColor;
		} else {
			Color newColor = _spriteRenderer.color;
			newColor.a = 1;
			_spriteRenderer.color = newColor;

		}
	}


	//controla los parametros del animator
	void ManageAnimations(){
		//le pasamos el valor absoluto de h porque cuando presionas
		//hacia la izquierda h se vuelve negativo
		float absH = Mathf.Abs (h);
		_animator.SetFloat ("speed", absH);
		_animator.SetFloat ("verticalSpeed", verticalSpeed);
		_animator.SetBool ("isGrounded", isGrounded);
		_animator.SetBool ("hurt", hurt);

		if (Input.GetMouseButtonDown(0) && isGrounded && canControl) {
			_animator.SetTrigger ("attack");
		}

		if (knockback > 0) {
			hurt = true;
		} else {
			hurt = false;

		}
	}

	void HandleKnockback(){
		if (knockback > 0) {
			knockback -= Time.deltaTime * 2.5f;
			if (knockback <= 0) {
				canControl = true;
			}
		}
	}

	//esto se encarga de cuando te hacen daño
	void Hurt(){
		//si la vida actual es menor a la vida que teniamos antes
		//significa que hemos recibido daño
		if (_healthScript.health < previousHealth) {
			//Layer 10 es la capa Invulnerable
			gameObject.layer = 10;

			canControl = false;
			knockback = 1.5f;
			verticalSpeed = 0.2f;

			Invoke ("MakePlayerVulnerable", invulnerableTime);
		}
		//despues de hacer el if actualizamos la variable previousHealth
		previousHealth = _healthScript.health;

	}

	void MakePlayerVulnerable(){
		//Layer 8 es la capa Jugadores
		gameObject.layer = 8;
	}
}