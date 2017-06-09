using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public float speedX = 5;
	private Rigidbody2D _rigidbody;
	private float verticalSpeed;
	public float gravity = -10;
	public float rayleght = 1.1f;
	private bool isGrounded;
	private bool isCrash;
	private bool isleftCrash;
	private bool isrightCrash;
	public float jumpForce;
	public bool controlPlayer;
	private float h;
	private bool jump;
	public float layerTime;
	public float knockBack;
	private bool KnockBackToRight;
	private bool hurt;
	public bool canAttack = true;

	private float targetAlpha;

	public LayerMask _mask;
	private Animator _animator;
	public SpriteRenderer _spriteRenderer;

	private Health health;
	private float previousHealth;

	void Start () {
		_rigidbody = GetComponent<Rigidbody2D> ();
		_animator = GetComponentInChildren<Animator> ();
		_spriteRenderer = GetComponentInChildren<SpriteRenderer> ();
		health = GetComponent<Health> ();
	}

	void Update () {

		ReceiveInputs ();
		HandleKnockBack ();
		Hurt ();
		ManageBlinking ();
		ManageFlipping ();
		ManageAnimations ();
	}
	//FixedUpdate se ejecuta cada 0.02 segundos
	//Es útil para usar física
	void FixedUpdate(){
		//Creamos un Vector3 que comienza en cero
		Vector3 moveVector = new Vector3 (0, 0, 0);
		Vector3 down = new Vector3 (0, -1, 0);
		Vector3 up = new Vector3 (0, 1, 0);
		Vector3 left = new Vector3 (-1, 0, 0);
		Vector3 right = new Vector3 (1, 0, 0);

		if (knockBack > 0) {
			if (KnockBackToRight) {
				moveVector.x = knockBack;
			} else {
				moveVector.x = -knockBack;
			}
		}else {
			moveVector.x = h * speedX;
		}
		//Physics.Raycast genera un rayo invisible
		//que te devuelve true si el rayo toca algo
		//y false si el rayo no toca nada
		//bool isGrounded = Physics.Raycast (transform.position, down, rayleght);
		Vector3 boxSize = new Vector3 (transform.localScale.x, transform.localScale.y, transform.localScale.z);
		boxSize *= 0.99f;
		RaycastHit2D hitInfo;

		hitInfo = Physics2D.BoxCast (transform.position, boxSize, 0, up, rayleght,_mask.value);
		if (hitInfo.collider != null) {
			isCrash = true;
		} else {
			isCrash = false;
		}
		if (isCrash) {
			verticalSpeed = 0;
		}

		hitInfo = Physics2D.BoxCast (transform.position, boxSize, 0, left, rayleght,_mask.value);
		if (hitInfo.collider != null) {
			isleftCrash = true;
		} else {
			isleftCrash = false;
		}
		if (isleftCrash) {
			if (moveVector.x < 0) {
				moveVector.x = 0;
			}
		}

		hitInfo = Physics2D.BoxCast (transform.position, boxSize, 0, right, rayleght,_mask.value);
		if (hitInfo.collider != null) {
			isrightCrash = true;
		} else {
			isrightCrash = false;
		}
		if (isrightCrash) {
			if (moveVector.x > 0) {
				moveVector.x = 0;
			}
		}

		hitInfo = Physics2D.BoxCast (transform.position, boxSize, 0, down, rayleght,_mask.value);
		if (hitInfo.collider != null) {
			isGrounded = true;
		} else {
			isGrounded = false;
		}
		if (isGrounded) {
			/*si estoy en el piso el verticalspeed es un valor negativo pequeño...esto es para asegurarnos que el
			 player toque el piso y no impida el movernos de lado a lado*/
			verticalSpeed = -0.1f;
			if (jump) {
				verticalSpeed = jumpForce;
				jump = false;
			}
		}else {
			//la gravedad se va aplicando al verticaSpeed
			verticalSpeed += gravity * Time.deltaTime;
		}
		//Debug.Log (h);
		//Debug.Log(moveVector);
		/*if (Input.GetKey (KeyCode.A)) {
			moveVector.x = -speedX;
		}
		if (Input.GetKey (KeyCode.D)) {
			moveVector.x = speedX;
		}*/
		//En lugar de pasarle los 3 números por separado le pasamos a la función Translate el Vector3
		//Cuando multiplicas un número por un Vector3 multiplicas ese número al X,Y y Z por ese número
		//transform.Translate (moveVector * Time.deltaTime);
		moveVector += new Vector3 (0, verticalSpeed, 0);
		_rigidbody.velocity = moveVector;

	}
	//sirve para los desarrolladores a la hora de testear el juego
	void OnDrawGizmos(){

		Vector3 boxSize = new Vector3 (transform.localScale.x, transform.localScale.y, transform.localScale.z);
		Vector3 down = new Vector3 (0, -1, 0);
		//Se define primero el color antes de usar una función...las funciones usaran el color establecido...
		if (isGrounded) {
			Gizmos.color = Color.green;
		} else {
			Gizmos.color = Color.red;
		}
		Gizmos.DrawWireCube (transform.position, boxSize * 0.99f);
		Gizmos.DrawWireCube (transform.position + (down * rayleght), boxSize * 0.99f);
  	}
	void ManageAnimations(){

		if (Input.GetMouseButtonDown (0) && isGrounded && canAttack) {
			//Trigger en el animator es como un boleano con la diferencia que se desactiva sola
			_animator.SetTrigger ("attack");
			canAttack = false;
		}
		_animator.SetFloat ("speed", Mathf.Abs (h));
		_animator.SetFloat ("verticalSpeed", verticalSpeed);
		_animator.SetBool ("isGrounded", isGrounded);
		_animator.SetBool ("hurt", hurt);
  	}
	void ReceiveInputs(){

		if (controlPlayer) {
			h = Input.GetAxis ("Horizontal");
			if (isGrounded) {
				if (Input.GetKeyDown (KeyCode.Space)) {
					jump = true;
				}
			}
		} else {
			h = 0;
		}
  	}
	void ManageFlipping(){

		if (h < 0) {
			_spriteRenderer.flipX = true;
		}
		if(h > 0){
			_spriteRenderer.flipX = false;
		}
	}
	void HandleKnockBack(){
		if (knockBack > 0) {
			knockBack -= Time.deltaTime * 10f;
			verticalSpeed = -5;
			if (knockBack <= 0) {
				controlPlayer = true;
			}
		}

	}
	void ManageBlinking(){

		if(gameObject.layer == 10){
			Color newColor = _spriteRenderer.color;
			//Mathf.Lerp sirve para recorrer de forma gradual
			//Mathf.Lerp(origen,destino,velocidad)
			newColor.a = Mathf.Lerp (newColor.a, targetAlpha, Time.deltaTime * 20);
			if (newColor.a < 0.05f) {
				targetAlpha = 1;
			}
			if (newColor.a > 0.95f) {
				targetAlpha = 0;
			}
			_spriteRenderer.color = newColor;
		}
  	}
	void Hurt(){
		if (health.health < previousHealth) {
			//layer 10 es la capa Invulnerable
			gameObject.layer = 10;
			controlPlayer = false;
			knockBack = 5;
			// si el player esta a la izquierda del enemigo
			if (transform.position.x < health.lastAttacker.transform.position.x) {
				KnockBackToRight = false;
			} else {
				KnockBackToRight = true;
			}
			Invoke ("MakePlayerVulnerable",layerTime);
		}
		previousHealth = health.health;
  	}
	void MakePlayerVulnerable(){
		gameObject.layer = 8;
		Color newColor = _spriteRenderer.color;
		newColor.a = 1;
		_spriteRenderer.color = newColor;
		//Unity no te permite hacer esto _spriteRenderer.color.a = 1; (exepciones)
	}
}