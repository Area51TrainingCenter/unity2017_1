using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour {
	// Player
	public float speedX = 10f;
	//
	public float gravity = -10f;
	public float raylength = 0.6f;
	public float speedJump = 10;

	private Rigidbody2D _rigibody;
	private Animator _animator;
	public SpriteRenderer _spriteRenderer;

	private Health _healthScript;
	private float previousHealth;

	private float verticalSpeed;
	public bool isGrounded; // abajo
	private bool isGrounded2; // arriba
	private bool isGrounded3;// izquierda
	private bool isGrounded4;// derecha

	public float h;
	private bool KeySpacePressed;

	public LayerMask _mask;

	public bool controlPlayer = true;
	public bool canAttack = true;

	public float invulnerableTime = 1.5f;

	private float knockback;
	private bool knockbackToRight; // para si saber golpear a la derecha o izquierda

	private float targetAlpha; 


	// Use this for initialization
	void Start () {
		// Guardamos la referencia la componente RigiBody
		_rigibody = GetComponent<Rigidbody2D> ();
		_animator = GetComponentInChildren<Animator> ();
		_spriteRenderer = GetComponentInChildren<SpriteRenderer> ();
		_healthScript = GetComponent<Health> ();// Vida
	}
	
	// Update is called once per frame
	void Update () {

		ReceiveInputs ();
		HandleKnockback ();
		Hurt ();
		ManageFlipping ();	
		ManageAnimation ();
		ManageDlinking ();		
	}



	// creamos nuestra funcion movimiento
	void FixedUpdate() {
		
		Vector3 moveVector = new Vector3(0,0,0);

		// el knockback es el empuje envie que se le hace al player cuando recibe daño
		// en el update se reduce gradualmente el knockback hasta que sea cero o menos
		if(knockback > 0){

			// aplicamos el knockback al movimiento del player
			if (knockbackToRight) {
				moveVector.x = knockback;
			} else {
				moveVector.x = -knockback;
			}

		}else{
			// esto se hace en el estado normal.. mover el player con el input de h
			moveVector.x = h * speedX;			
		}
	

		Vector3 down   = new Vector3(0,-1,0);// direccion hacia abajo
		Vector3 up     = new Vector3(0,1,0);// direccion hacia arriba
		Vector3 left   = new Vector3(-1,0,0);// izquierda
		Vector3 right   = new Vector3(1,0,0);// Derecha

		// hacemos raycast  genera un rayo invisible 
		// que te devuelve  true si el rayo toca algo 
		// y false si el rayo no toca nada
		//bool isGrounded = Physics.Raycast (transform.position, down, raylength);

		Vector3 boxSize = new Vector3 (transform.localScale.x, transform.localScale.y,transform.localScale.z);// tamaño de la caja
		boxSize = boxSize*0.99f;

		RaycastHit2D hitInfo;

		//------ ABAJO DOWN -----//
		//isGrounded = Physics.BoxCast(transform.position,boxSize/2,down,Quaternion.identity,raylength); //Quaternion.identity => rotacion= 0,0,0 
		hitInfo = Physics2D.BoxCast(transform.position,boxSize,0,down,raylength,_mask.value);
		if (hitInfo.collider == null) {
			isGrounded = false;
		} else {
			isGrounded = true;
		}

		//// ARRIBA UP ////
		//isGrounded2 = Physics.BoxCast(transform.position,boxSize/2,up,Quaternion.identity,raylength);   
		hitInfo = Physics2D.BoxCast(transform.position,boxSize,0,up,raylength,_mask.value);
		if (hitInfo.collider == null) {
			isGrounded2 = false;
		} else {
			isGrounded2 = true;
		}

		//// IZQUIERDA - LEFT ///
		//isGrounded3 = Physics.BoxCast(transform.position,boxSize/2,left,Quaternion.identity,raylength);  
		hitInfo = Physics2D.BoxCast(transform.position,boxSize,0,left,raylength,_mask.value);
		if (hitInfo.collider == null) {
			isGrounded3 = false;
		} else {
			isGrounded3 = true;
		}

		//// DERECHA - RIGHT ////
		//isGrounded4 = Physics.BoxCast(transform.position,boxSize/2,right,Quaternion.identity,raylength); 
		hitInfo = Physics2D.BoxCast(transform.position,boxSize,0,right,raylength,_mask.value);
		if (hitInfo.collider == null) {
			isGrounded4 = false;
		} else {
			isGrounded4 = true;
		}

		// DERECHA //
		if (isGrounded4 && h>0) {
			moveVector.x = 0;
		} 

		// IZQUIERDA //
		if (isGrounded3 && h<0) {
			moveVector.x = 0;
		} 

		// ARRIBA  [Para que no se quede pegado en el techo]
		if (isGrounded2) {
			verticalSpeed = 0;
		} 

		// ABAJO [Piso] //
		if (isGrounded) {
			//si estoy en el piso el verticalspeed es 
			//un valor negativo pequeño--- esto es para
			// asegurarnos que el player toque el piso
			//y no impida el movernos de lado a lado
			verticalSpeed = -0.1f;

			// Para saltar
			if (KeySpacePressed) {
				verticalSpeed = speedJump;
				KeySpacePressed = false;
			}
				
		} else {
			// la gravedad se va aplicando al verticalspeed
			verticalSpeed += gravity * Time.deltaTime;
		}


		moveVector += new Vector3 (0, verticalSpeed, 0);	

		// En lugar de pasarle los 3 numeros por separado
		// le pasamo a la funcion translate el Vector3
		//transform.Translate (moveVector*Time.deltaTime);
		_rigibody.velocity = moveVector;


	}// end movimiento

	void OnDrawGizmos(){
		
		if (isGrounded) {
			Gizmos.color = Color.red;
		} else {
			Gizmos.color = Color.blue;
		}

		Vector3 boxSize = new Vector3 (transform.localScale.x, transform.localScale.y,transform.localScale.z);// tamaño de la caja
		boxSize = boxSize*0.99f;
		Gizmos.DrawWireCube (transform.position, boxSize);

		Vector3 down = new Vector3(0,-1,0);// direccion hacia abajo
		Vector3 posicion2 = transform.position + (down * raylength);
		Gizmos.DrawWireCube (posicion2, boxSize);


	}

	void ReceiveInputs(){
		
		if (controlPlayer) {

			h = Input.GetAxis ("Horizontal");

			if (Input.GetKeyDown (KeyCode.Space) && isGrounded) {
				KeySpacePressed = true;
			}

		} else {
			h = 0;
		}
	}

	// se encarga de 
	void ManageFlipping(){

		// para voltear al personaje
		if (h < 0) {
			_spriteRenderer.flipX = true;
		} 
		if(h>0) {
			_spriteRenderer.flipX = false;
		}
			
	}

	// se encarga de 
	void ManageDlinking (){

		if (gameObject.layer == 10) {

			Color newColor = _spriteRenderer.color;
			newColor.a = Mathf.Lerp (newColor.a, targetAlpha, Time.deltaTime * 20);

			if (newColor.a < 0.05f) {
				targetAlpha = 1;
			}

			if (newColor.a > 0.95f) {
				targetAlpha = 0;
			}
				
			_spriteRenderer.color = newColor;

		}else{

			Color newColor = _spriteRenderer.color;
			newColor.a = 1;
			_spriteRenderer.color = newColor;
		}


	}

	// controla los parametros del anterior 
	void ManageAnimation(){
		
		float absH = Mathf.Abs (h);
		// Animator
		_animator.SetFloat ("speed",absH);
		_animator.SetFloat ("verticalspeed",verticalSpeed);
		_animator.SetBool ("isGrounded", isGrounded);


		if (Input.GetMouseButtonDown (0) && isGrounded && canAttack) {
			_animator.SetTrigger ("isAttack");
			canAttack = false;
		}


		if (knockback > 0) {			
			_animator.SetBool ("hurt", true);
		}else{
			_animator.SetBool ("hurt", false);
		}
			
	}


	void HandleKnockback (){
		
		if(knockback > 0){
			knockback -= Time.deltaTime * 2.5f; 	
			if(knockback <= 0){
				controlPlayer = true;
			}
		}

	}

	// esto se encarga de cuando te hacen daño
	void Hurt(){
		
		// vida..... 
		// si la vida actual es menor a la vida que teniamos antes 
		// significa que hemos recibido daño 
		if (_healthScript.health < previousHealth) {
			// 
			gameObject.layer = 10; 
			// pierdes el control del personaje
			controlPlayer = false;
			// 
			knockback = 3;

			if (_healthScript.lastAttacker != null ) {// si el ultimo que lo ataca es diferente de vacio 
				if (transform.position.x < _healthScript.lastAttacker.transform.position.x) {
					knockbackToRight = false;
				} else {
					knockbackToRight = true;
				}
			}

			verticalSpeed = 1;// salto

			Invoke ("restorePlayer", invulnerableTime);
		}
		//  despues de hacer el if actualmente la variable previousHealth
		previousHealth = _healthScript.health; // vida actual
		// vida..... 
	}

	void restorePlayer(){
		gameObject.layer = 8; 
	}



}
