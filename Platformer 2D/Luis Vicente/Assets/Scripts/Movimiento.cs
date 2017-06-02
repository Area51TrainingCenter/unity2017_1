using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour {
	public float SpeddX = 5;
	public float Gravity = -10;
	public float rayLength = 0.6f;
	public LayerMask Mascara;
	private Rigidbody2D _rigibody;
	private Animator _Animacion;
	private SpriteRenderer _SpriteRenderer;
	private float VerticalSpeed = 0;
	private bool isGrounded;
	private bool isHitup;
	private bool isRight;
	private bool isLeft;
	bool Salto = false;
	float h = 0;
	public bool canCondicion = true;
	private int Contador = 0; 
	private Vida _vida;
	private float vidaPrevia;

	// Use this for initialization
	void Start () {
		_rigibody = GetComponent <Rigidbody2D>();
		_Animacion = GetComponentInChildren <Animator>();
		_SpriteRenderer = GetComponentInChildren <SpriteRenderer>();
		_vida = GetComponent <Vida> ();
	}
	void Update (){

		Inputs ();
		RecibirDano ();
		Flipping ();
		Animaciones ();
			

	}
	// Update is called once per frame
	void FixedUpdate () {
		
		Vector3 MoveVector = new Vector3 (0,0,0);
		Vector3 down = new Vector3 (0, -1, 0);
		Vector3 up = new Vector3 (0, 1, 0);
		Vector3 right = new Vector3 (1, 0, 0);
		Vector3 left = new Vector3 (-1, 0, 0);
		MoveVector.x = h * SpeddX;

		RaycastHit2D hitInfo;
		//bool isGrounded = Physics.Raycast (transform.position,down,rayLength);
		Vector3 boxSize = new Vector3 (transform.localScale.x,transform.localScale.y,transform.localScale.z)*0.99f;
		//isGrounded = Physics.BoxCast (transform.position,boxSize/2,down,Quaternion.identity,rayLength);
		//isTocar = Physics.BoxCast (transform.position,boxSize/2,up,Quaternion.identity,rayLength);
		//isRight = Physics.BoxCast (transform.position,boxSize/2,right,Quaternion.identity,rayLength);
		//isLeft = Physics.BoxCast (transform.position,boxSize/2,left,Quaternion.identity,rayLength);
		hitInfo = Physics2D.BoxCast (transform.position,boxSize,0,down,rayLength,Mascara.value);
		if (hitInfo.collider != null) {
			isGrounded = true;
		} else {
			isGrounded = false;
		}
		hitInfo = Physics2D.BoxCast (transform.position,boxSize,0,up,rayLength,Mascara.value);
		if (hitInfo.collider != null) {
			isHitup = true;
		} else {
			isHitup = false;
		}
		hitInfo = Physics2D.BoxCast (transform.position,boxSize,0,right,rayLength,Mascara.value);
		if (hitInfo.collider != null) {
			isRight = true;
		} else {
			isRight = false;	
		}				

		hitInfo = Physics2D.BoxCast (transform.position,boxSize,0,left,rayLength,Mascara.value);
		if (hitInfo.collider != null) {
			isLeft = true;
		} else {
			isLeft = false;
		}
	

		if (isRight) {
			if (h >= 0) {
				MoveVector.x = 0;
			} 
		}

		if (isLeft) {
			if (h <= 0) {
				MoveVector.x = 0;
			} 
		}

		if (isHitup) {
			VerticalSpeed = -0.1f;
		}

		if (isGrounded) {
			VerticalSpeed = -0.1f;

			if (Salto) {
				VerticalSpeed = 7f;
				Salto = false;
			}
		}
			else {
			VerticalSpeed += Gravity * Time.deltaTime;
			}
		


		MoveVector += new Vector3 (0, VerticalSpeed, 0);

		_rigibody.velocity = MoveVector;
		//transform.Translate (MoveVector * Time.deltaTime);
		//transform.Translate (moveX * Time.deltaTime,0,0);
	}
		void OnDrawGizmos(){

			Gizmos.color = Color.red;
			Vector3 boxSize = new Vector3 (transform.localScale.x,transform.localScale.y,transform.localScale.z)*0.99f;
		if (isGrounded) {
			Gizmos.color = Color.blue;

		} 
		else {
			Gizmos.color = Color.green;
		}
			Gizmos.DrawWireCube (transform.position,boxSize);
			Vector3 down = new Vector3 (0, -1, 0);
			Gizmos.DrawWireCube (transform.position+ (down * rayLength),boxSize);
	}

	void Inputs (){
		if (canCondicion) {
			h = Input.GetAxis ("Horizontal");
			if (Input.GetKeyDown (KeyCode.Space) && isGrounded) {
				Salto = true;
			} 
		} else {
			h = 0;
		}
	}

	void Flipping (){
		if (h < 0) {
			_SpriteRenderer.flipX = true;
		}
		if (h > 0) {
			_SpriteRenderer.flipX = false;
		}
	}

	void Animaciones (){
		float absH = Mathf.Abs (h);
		_Animacion.SetFloat ("Speed", absH);
		_Animacion.SetFloat ("VerticalSpeed", VerticalSpeed);
		_Animacion.SetBool ("isGrounded", isGrounded);
		if (Input.GetKeyDown (KeyCode.Z) && isGrounded && canCondicion) {
			_Animacion.SetTrigger ("Atacar");

		}	
	}
	void RecibirDano (){
		if (_vida.vidaActual < vidaPrevia) {
			// layer 10 Es la capa inmortal 
			gameObject.layer = 10;
			Invoke ("RestaurarCapa", 2);

		}	
		vidaPrevia = _vida.vidaActual;
	}

	void RestaurarCapa(){
		// La capa 8 es Jugador
		gameObject.layer = 8;
	}
}
