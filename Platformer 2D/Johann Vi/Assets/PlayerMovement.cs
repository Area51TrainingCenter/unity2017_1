using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
	public float speedX = 5;
	public float gravity = -10;
	private bool isGrounded;
	private bool isGroundedLeft;
	private bool isCrashed;
	private bool isGroundedRight;
	public float rayLength = 0.6f;
	private Animator _animator;
	public bool NoControl = true;
	public int NumberJumps = 0; 


	private SpriteRenderer _spriterenderer;
	public float jumpForce = 0.9f;
	private Rigidbody2D _rigidbody;
	public LayerMask _mask ;
	private float verticalSpeed;
	private float h;
	public bool jump;
	// Use this for initialization
	void Start () {
		//guardamos la referencia la componente Rigidbody 
		//en nuestra variable
		_rigidbody = GetComponent<Rigidbody2D>();
		_animator = GetComponentInChildren<Animator> ();
		_spriterenderer = GetComponentInChildren<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update() {
		
		if (isGrounded){ if(Input.GetKeyDown (KeyCode.Space)){
			_animator.SetTrigger ("attack");
		}
		}

		if (NoControl) {
			h = Input.GetAxis ("Horizontal");
			if (isGrounded){ 
				if(Input.GetKeyDown (KeyCode.UpArrow)) {
				jump = true;
					}
			} 		 

		} else {
			h = 0;
		}


		if(h<0){
			_spriterenderer.flipX = true;
		}
		if(h>0){
			_spriterenderer.flipX = false;
		}
		float absH = Mathf.Abs (h);
		_animator.SetFloat ("speed", absH); 
	
		_animator.SetFloat ("verticalSpeed",verticalSpeed ); 
		_animator.SetBool ("isGrounded", isGrounded ); 
		 
		if (true) {
			
		}
	
	}



	void FixedUpdate () {
		//CUANDO MANIPULAS FISICA O BOX AND RAYCAST
		//creamos un Vector3 que comienza en zero
		Vector3 moveVector = new Vector3(0,0,0);

		moveVector.x = h*speedX;

		RaycastHit2D hitInfo;

		Vector3 down = new Vector3 (0, -1, 0);
		Vector3 up = new Vector3 (0, 1, 0);
		Vector3 left = new Vector3 (-1, 0, 0);
		Vector3 right = new Vector3 (1, 0, 0);
		//Physics.Raycast genera un rayo invisible
		//que te devuelve true si el rayo toca algo
		//y false si el rayo no toca nada
		//bool isGrounded = Physics.Raycast (transform.position, down, rayLength);

		Vector3 boxSize = new Vector3 (transform.localScale.x, transform.localScale.y, transform.localScale.z); 
		//Crear una variable de boxsize para poder editarla en el editor
		boxSize = boxSize * 0.99f;		
		//isGrounded = Physics.BoxCast (transform.position, boxSize/2, down, Quaternion.identity, rayLength);
		hitInfo = Physics2D.BoxCast (transform.position, boxSize, 0, down, rayLength,_mask.value);

	
		if(hitInfo.collider ==null) {  
			isGrounded = false;
		} else { 
			isGrounded = true;
		}

		hitInfo = Physics2D.BoxCast (transform.position, boxSize, 0,up, rayLength, _mask.value);
		if(hitInfo.collider == null) {  
			isCrashed = false;
		} else { 
			isCrashed = true;
		}

		hitInfo = Physics2D.BoxCast (transform.position, boxSize,0, left ,  rayLength,_mask.value);
		if(hitInfo.collider ==null) {  
			isGroundedLeft = false;
		} else { 
			isGroundedLeft= true;
		}
		hitInfo = Physics2D.BoxCast (transform.position, boxSize,0, right , rayLength,_mask.value);
		if(hitInfo.collider ==null) {  
			isGroundedRight = false;
		} else { 
			isGroundedRight = true;
		}


		if (isGroundedLeft &&  h < 0  ) {  

			moveVector.x = 0;}

		if (isGroundedRight &&  h > 0) {

			moveVector.x = 0;}

		if (isCrashed) {

			verticalSpeed = 0;
		}
		if (isGrounded) {
			//si estoy en el piso el verticalSpeed es 
			//un valor negativo pequeño... esto es para 
			//asegurarnos que el player toque el piso
			//y no impida el movernos de lado a lado
			verticalSpeed = -0.1f;
			if (jump) {
				verticalSpeed = jumpForce;
				jump = false;
			}

		} 
			

		else {
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
	void OnDrawGizmos() {

	  	if (isGrounded) {
			Gizmos.color = Color.green;
		}	else {
		Gizmos.color = Color.red;
		}

		Vector3 boxSize = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z);
		boxSize = boxSize * 0.99f;
		Gizmos.DrawWireCube (transform.position, boxSize);

		Vector3 down = new Vector3 (0, -1, 0);

		Vector3 pos = transform.position + (down * rayLength);
		Gizmos.DrawWireCube (pos, boxSize);

	}
}
