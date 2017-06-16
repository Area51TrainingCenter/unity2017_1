using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
	public float speedX = 5;
	public float jumpForce = 8;
	public float gravity = -10;
	private health _healthscript;
	public float rayLength = 0.6f;
	private float _previoushealth;
	public LayerMask _mask;
	public float _restoreplayer = 1.5f;
	public bool canControl = true;
	private Rigidbody2D _rigidbody;
	private Animator _animator;
	private SpriteRenderer _spriteRenderer;
	private float knockback;
	private float verticalSpeed;
	private bool isGrounded;
	private float targetalpha;
	private float h;
	private bool pressedJump;
	private bool knockbacktoright;
	public bool canAttack = true;
	// Use this for initialization
	void Start () {
		//guardamos la referencia la componente Rigidbody 
		//en nuestra variable
		_rigidbody = GetComponent<Rigidbody2D>();
		_animator = GetComponentInChildren<Animator> ();
		_spriteRenderer = GetComponentInChildren<SpriteRenderer> ();
		_healthscript = GetComponent<health> ();

	}
	// Update is called once per frame
	void Update(){
		
		ReceiveInputs ();

		Handleknockback ();

		Hurt ();

		Handleflipping ();

		handleblinking ();

		HandleAnimations ();

	}

	//FixedUpdate se ejecuta cada 0.02 segundos
	//aqui incluimos todo el codigo que manipule los rigidbodies
	void FixedUpdate () {
		//creamos un Vector3 que comienza en zero
		Vector3 moveVector = new Vector3(0,0,0);

		if (knockback > 0) 
		{
			if (knockbacktoright) 
			{
				moveVector.x = knockback;
			} 
			else 
			{
				moveVector.x = -knockback;
			}					

		} 
		else 
		{
			moveVector.x = h*speedX;	
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

	void ReceiveInputs()
	{
		if (canControl) {
			//necesitamos leer los inputs en cada frame
			//por eso es que lo colocamos en Update
			//y guardamos el resultado en variables globales que 
			//se usaran en FixedUpdate
			h = Input.GetAxis ("Horizontal");

			//si presionas espacio pressedJump permanecera en true
			//hasta que se aplique el salto dentro de FixedUpdate
			if (Input.GetKeyDown (KeyCode.Space) && isGrounded ) {
				pressedJump = true;	
			}
		} else {
			h = 0;
		}
	}

	void Handleknockback ()
	{
		if (knockback > 0) 
		{
			knockback -= Time.deltaTime * 2.5f;
			

			if (knockback <= 0) 
			{
				canControl = true;
			}

		}


	}

	void Handleflipping()
	{
		if (h<0) {
			_spriteRenderer.flipX = true;
		}
		if (h>0) {
			_spriteRenderer.flipX = false;	
		}
	}

	void handleblinking()
	{
		if (gameObject.layer == 10) 
		{
			Color newColor = _spriteRenderer.color;
			newColor.a = Mathf.Lerp (newColor.a, targetalpha, Time.deltaTime * 5);
			_spriteRenderer.color = newColor;
			if (newColor.a <=0.1f) {
				targetalpha = 1;
			}
			if (newColor.a >=0.95) {
				targetalpha = 0;
			}
		} 
		else
		{
			Color newColor = _spriteRenderer.color;
			newColor.a = 1;
			_spriteRenderer.color = newColor;
		}

	}



	void HandleAnimations()
	{
		//le pasamos el valor absoluto de h porque cuando presionas
		//hacia la izquierda h se vuelve negativo
		float absH = Mathf.Abs (h);
		_animator.SetFloat ("speed", absH);
		_animator.SetFloat ("verticalSpeed", verticalSpeed);
		_animator.SetBool ("isGrounded", isGrounded);

		if (Input.GetMouseButtonDown(0) && isGrounded && canAttack) {
			_animator.SetTrigger ("attack");
			canAttack = false;
		}

		if (knockback > 0) {
			_animator.SetBool ("Hurt", true);
		} else {
			_animator.SetBool ("Hurt", false);
		}
	}		

	void Hurt()
	{
		// se compara el valor actual de health con el posterior
	

		if (_healthscript.Health < _previoushealth) 
		{
			gameObject.layer = 10;

			canControl = false;

			knockback = 2;

			if(_healthscript.lastAttacker != null){

			if (transform.position.x <_healthscript.lastAttacker.transform.position.x) 
			{
				knockbacktoright = false;
			}

			}

			verticalSpeed = 2;

			Invoke ("Makeplayervulnerable",_restoreplayer);
		}

		//luego se actualiza

		_previoushealth = _healthscript.Health;


	}

	void Makeplayervulnerable()
	{
		gameObject.layer = 8;
	}
}
