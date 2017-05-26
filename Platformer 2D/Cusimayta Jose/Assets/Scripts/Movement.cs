using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
	public float speedX = 10f;
	public float gravity = -10;
	public float JumpForce=5;
	private Rigidbody2D _rigidbody;
	private float VerticalSpeed;
	public float RayLenght=0.03f;
	bool Jump=false;
	bool isGrounded, isTop, isRight, isLeft;
	float h;
	public Camera camara;
	public LayerMask _mask;
	private Animator _animator;
	private SpriteRenderer _spriteRenderer;
	// Use this for initialization
	void Start () {
		_rigidbody = GetComponent<Rigidbody2D> ();
		_animator = GetComponentInChildren<Animator> ();
		_spriteRenderer = GetComponentInChildren<SpriteRenderer> ();
	}
	

	void Update(){ // Update es llamada en cada frame 
		
		//Les pasamos los inputs a esta función
		h = Input.GetAxis ("Horizontal"); //Detectamos las teclas para el movimiento horizontal

		if (Input.GetKeyDown (KeyCode.Space) && isGrounded) // Detectamos la tecla de salto cuando el personaje esta en el piso
			Jump = true; //Cambiamos el bool Jump a true, para que el personaje este apto para saltar, si no se le pone esto, el personaje saltara por si solo
		//Para girar al personaje, para ello, se cambio la gravedad y sensibilidad a 10 en el input manager y en el animator se redujo al demora a 0, en al transición, para evitar el patinaje 
		if (h < 0)	//Para saber si se mueve hacia la izquierda
			_spriteRenderer.flipX = true;	//Cambiamos el girar en el eje X a verdadero
		if (h > 0)	//Para saber si se mueve hacia la derecha
			_spriteRenderer.flipX = false;	//Cambiamos el girar en el eje X a falso


		float absH = Mathf.Abs (h);  //Aplicamos el valor absoluto a la variable "h"
		_animator.SetFloat ("speed", absH); //En el animator modificamos la variable de "speed" y darle el valor de H en valor absoluto

		_animator.SetFloat ("verticalSpeed", VerticalSpeed); //Se le pasa la variable VerticalSpeed, ya sea negativo o positivo, para saber si esta saltando o cayendo
		_animator.SetBool ("isGrounded", isGrounded); //Se le pasa el bool isGrounded, para saber si esta en tierra o no

		 
		if (Input.GetMouseButtonDown (0) && isGrounded) //Detectamos el clic izquierdo del mouse
		{
			_animator.SetTrigger ("Attack"); //El trigger se activa al llamarlo, se pone en verdadero, y al frame siguiente, se convierte en falso automaticamente

		}

	}
	void FixedUpdate () { // UpdateFixed es llamada cada que el motor de fisica se actualiza
		MovimientoLateral ();
	}

	void MovimientoLateral(){
		Vector3 moveVector = new Vector3 (0, 0, 0);
		moveVector.x = h * speedX;
		RaycastHit2D hitInfo;
		Vector3 boxSize = new Vector3 (transform.localScale.x, transform.localScale.y, transform.localScale.z);
		boxSize = boxSize * 0.99f;

		hitInfo = Physics2D.BoxCast (transform.position, boxSize, 0, Vector3.down, RayLenght, _mask.value);

		if (hitInfo.collider != null) {
			isGrounded = true;
		} else {
			isGrounded = false;
		}
	

		hitInfo = Physics2D.BoxCast (transform.position, boxSize, 0, Vector3.up, RayLenght, _mask.value);

		if(hitInfo.collider!=null ){
			isTop = true;
		}else{
			isTop = false;
		}

		hitInfo = Physics2D.BoxCast (transform.position, boxSize, 0, Vector3.right, RayLenght, _mask.value);

		if(hitInfo.collider!=null ){
			isRight = true;
		}else{
			isRight = false;
		}

		hitInfo = Physics2D.BoxCast (transform.position, boxSize, 0, Vector3.left, RayLenght, _mask.value);

		if(hitInfo.collider!=null ){
			isLeft = true;
		}else{
			isLeft = false;
		}
			
		if(isTop) {
			VerticalSpeed = -0.1f;
		}
		if (isRight) {
			if (h >= 0) {
				moveVector.x = 0;
			}
		}
		if (isLeft) {
			if (h <= 0) {
				moveVector.x = 0;
			}
		}

		if (isGrounded) {
			VerticalSpeed = -0.1f;
			if (Jump) {				
				VerticalSpeed = JumpForce;
				Jump = false;
			}
		} else {
			VerticalSpeed += gravity * Time.deltaTime;
		}
			
		moveVector += new Vector3 (0, VerticalSpeed,0);
		_rigidbody.velocity = moveVector;		
	}		
	void OnDrawGizmos(){
		if (isGrounded)
			Gizmos.color = Color.green;
		else
			Gizmos.color = Color.red;	
		Vector3 boxSize = new Vector3 (transform.localScale.x, transform.localScale.y, transform.localScale.z)*0.99f;
		Gizmos.DrawWireCube (transform.position, boxSize);
		Gizmos.DrawWireCube (transform.position + new Vector3 (0, -1, 0) * RayLenght, transform.localScale);
	}

}