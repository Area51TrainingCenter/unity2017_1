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
	private float knockBack;
	private float TargetAlpha;
	private bool knockBackToRigth;
	public bool canAtaca = true;
	// Use this for initialization
	void Start () {
		_rigibody = GetComponent <Rigidbody2D>();
		_Animacion = GetComponentInChildren <Animator>();
		_SpriteRenderer = GetComponentInChildren <SpriteRenderer>();
		_vida = GetComponent <Vida> ();
	}
	void Update (){

		Inputs ();
		HandleKnockback ();
		RecibirDano ();
		Flipping ();
		ManageBlinking ();
		Animaciones ();
			

	}
	// Update is called once per frame
	void FixedUpdate () {
		
		Vector3 MoveVector = new Vector3 (0,0,0);
		Vector3 down = new Vector3 (0, -1, 0);
		Vector3 up = new Vector3 (0, 1, 0);
		Vector3 right = new Vector3 (1, 0, 0);
		Vector3 left = new Vector3 (-1, 0, 0);
		if (knockBack > 0) {
			if (knockBackToRigth) {
				MoveVector.x = knockBack;
			} else {
				MoveVector.x = -knockBack;
			}

		} else {
			MoveVector.x = h * SpeddX;

		}					
	

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
	void ManageBlinking (){

		if (gameObject.layer == 10) {
			Color newColor = _SpriteRenderer.color;
			newColor.a = Mathf.Lerp (newColor.a, TargetAlpha, Time.deltaTime * 20);
			if (newColor.a <= 0.5f) {
				TargetAlpha = 1;
			}if (newColor.a > 0.95f) {
				TargetAlpha = 0;
			}
			else {
				Color newColor1 = _SpriteRenderer.color;
				newColor.a = Mathf.Lerp (newColor.a, 1, Time.deltaTime * 20);
				_SpriteRenderer.color = newColor;
			}
			_SpriteRenderer.color = newColor;
		}

	}
	void Animaciones (){
		float absH = Mathf.Abs (h);
		_Animacion.SetFloat ("Speed", absH);
		_Animacion.SetFloat ("VerticalSpeed", VerticalSpeed);
		_Animacion.SetBool ("isGrounded", isGrounded);
		if (Input.GetKeyDown (KeyCode.Z) && isGrounded && canAtaca) {
			_Animacion.SetTrigger ("Atacar");
			canAtaca = false;
		}
		if (knockBack > 0) {
			_Animacion.SetBool ("Danno", true);
		}
		if (knockBack <= 0) {
			_Animacion.SetBool ("Danno", false);
		}
	}
	void HandleKnockback(){
		if (knockBack > 0) {
			knockBack -= Time.deltaTime * 2.5f;
			if (knockBack <= 0) {
				canCondicion = true;
			}
		}
	
	}
	void RecibirDano (){
		if (_vida.vidaActual < vidaPrevia) {
			// layer 10 Es la capa inmortal 
			gameObject.layer = 10;
			knockBack = 1.5f;
			VerticalSpeed = 2;
			canCondicion = false;
			if (transform.position.x < _vida.LastAttacker.transform.position.x) {
				knockBackToRigth = false;
			} else {
				knockBackToRigth = true;

			}

			Invoke ("RestaurarCapa", 2);

		}	
		vidaPrevia = _vida.vidaActual;
	}

	void RestaurarCapa(){
		// La capa 8 es Jugador
		gameObject.layer = 8;
	}
}
