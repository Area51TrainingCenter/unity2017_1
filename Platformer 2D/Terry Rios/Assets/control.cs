using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class control : MonoBehaviour {

    public float speedX = 5;
	private float gravity = -10;
	public float jumpForce = 8;
	private Rigidbody2D _rigidbody;
	public LayerMask _mask;
	private Animator _animator;
	private SpriteRenderer _spriterenderer;
	private float verticalSpeed;
	public float rayLength = 0.6f;
	private bool isGrounded;
	private bool isStoped;
    private float h;
	private bool pressedJump;


	// Use this for initialization
	void Start () 
	{
		_rigidbody = GetComponent<Rigidbody2D>();
		_animator = GetComponentInChildren<Animator> ();
		_spriterenderer = GetComponentInChildren<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {

		h = Input.GetAxis ("Horizontal");

		if (Input.GetKeyDown (KeyCode.Space)) 
		{
			if (isGrounded) {
				pressedJump = true;
			}	
		}

		if (h < 0) {
			_spriterenderer.flipX = true;
		}
		if (h > 0) {
			_spriterenderer.flipX = false;
		}

		//
		float absh = Mathf.Abs(h);
		_animator.SetFloat ("speed", absh);

		_animator.SetFloat ("verticalspeed",verticalSpeed);

		_animator.SetBool ("isGrounded",isGrounded);

		if(Input.GetKeyDown(KeyCode.F)){
			if (isGrounded) {
				_animator.SetTrigger("attack1");

			}
			
		}



	}

	void FixedUpdate (){
		//creamos un Vector3 que comienza en zero
		Vector3 moveVector = new Vector3(0,0,0);

		moveVector.x = h*speedX;
		RaycastHit2D hitinfo;

		Vector3 up = new Vector3 (0, 1, 0);
		Vector3 left = new Vector3 (-1, 0, 0);
		Vector3 rigth = new Vector3 (1, 0, 0);
		Vector3 down = new Vector3 (0, -1, 0);
		//Physics.Raycast genera un rayo invisible
		//que te devuelve true si el rayo toca algo
		//y false si el rayo no toca nada



		Vector3 boxSize = new Vector3 (transform.localScale.x, transform.localScale.y, transform.localScale.z);
		boxSize = boxSize * 0.99f;

		hitinfo = Physics2D.BoxCast(transform.position,boxSize,0,down,rayLength,_mask.value);

		if (hitinfo.collider == null) {
			isGrounded = false;
		} 
		else {
			isGrounded = true;
		}

		//isStoped = Physics.BoxCast (transform.position, boxSize/2, up, Quaternion.identity, rayLength);


		hitinfo = Physics2D.BoxCast(transform.position,boxSize,0,up,rayLength,_mask.value);
		if (hitinfo.collider == null) {
			isStoped = false;
		} 
		else {
			isStoped = true;
		}





		bool isStopedR = false;

		hitinfo = Physics2D.BoxCast (transform.position, boxSize,0, rigth, rayLength,_mask.value);

		if (hitinfo.collider == null) {
			isStopedR = false;
		} 
		else {
			isStopedR = true;
		}

		if (isStopedR) {
			if (h>0) {
				moveVector.x = 0;
			}
		}

		bool isStopedL = false;
		hitinfo = Physics2D.BoxCast (transform.position, boxSize,0, left, rayLength,_mask.value);
		if (hitinfo.collider == null) {
			isStopedL = false;
		} 
		else {
			isStopedL = true;
		}

		if (isStopedL) {
			if (h<0) {
				moveVector.x = 0;
			}
		}

		if (isStoped) {
			//si estoy en el piso el verticalSpeed es 
			//un valor negativo pequeño... esto es para 
			//asegurarnos que el player toque el piso
			//y no impida el movernos de lado a lado
			verticalSpeed = -1;
			}

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
		Vector3 left = new Vector3 (-1, 0, 0);
		Vector3 rigth = new Vector3 (1, 0, 0);
		Vector3 up = new Vector3 (0, 1, 0);
		Vector3 arriba = transform.position + (up * rayLength);
		Vector3 izquierda = transform.position + (left * rayLength);
		Vector3 pos = transform.position + (down * rayLength);
		Vector3 derecha = transform.position + (rigth * rayLength);
		Gizmos.DrawWireCube (pos, boxSize);
		Gizmos.DrawWireCube (arriba, boxSize);
		Gizmos.DrawWireCube (izquierda, boxSize);
		Gizmos.DrawWireCube (derecha, boxSize);
	}

	


}