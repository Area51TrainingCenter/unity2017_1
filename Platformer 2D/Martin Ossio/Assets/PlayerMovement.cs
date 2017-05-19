using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
	public float speedX = 5;
	public float jumpForce = 8;
	public float gravity = -10;

	public float rayLength = 0.6f;
	private Rigidbody _rigidbody;
	private float verticalSpeed;
	private bool isGrounded;
	private bool isCrashed;
	private bool isCrashedLeft;
	private bool isCrashedRight;

	private float h;
	private bool pressedJump;
	// Use this for initialization
	void Start () {
		//guardamos la referencia la componente Rigidbody 
		//en nuestra variable
		_rigidbody = GetComponent<Rigidbody>();
	}
	// Update is called once per frame
	void Update(){
		//necesitamos leer los inputs en cada frame
		//por eso es que lo colocamos en Update
		//y guardamos el resultado en variables globales que 
		//se usaran en FixedUpdate
		h = Input.GetAxis ("Horizontal");

		//si presionas espacio pressedJump permanecera en true
		//hasta que se aplique el salto dentro de FixedUpdate
		if (Input.GetKeyDown (KeyCode.Space)) {
			pressedJump = true;	
		}

	}

	//FixedUpdate se ejecuta cada 0.02 segundos
	//aqui incluimos todo el codigo que manipule los rigidbodies
	void FixedUpdate () {
		//creamos un Vector3 que comienza en zero
		Vector3 moveVector = new Vector3(0,0,0);

		moveVector.x = h*speedX;

		Vector3 down = new Vector3 (0, -1, 0);
		Vector3 up = new Vector3 (0, 1, 0);

		Vector3 left = new Vector3 (-1, 0, 0);
		Vector3 right = new Vector3 (1, 0, 0);

		//Physics.Raycast genera un rayo invisible
		//que te devuelve true si el rayo toca algo
		//y false si el rayo no toca nada
	
		//bool isGrounded = Physics.Raycast (transform.position, down, rayLength);

		Vector3 boxSize = new Vector3 (transform.localScale.x, transform.localScale.y, transform.localScale.z);
		boxSize = boxSize * 0.99f;
		isGrounded = Physics.BoxCast (transform.position, boxSize/2, down, Quaternion.identity, rayLength);
		isCrashed= Physics.BoxCast (transform.position, boxSize/2, up, Quaternion.identity, rayLength);

		isCrashedLeft= Physics.BoxCast (transform.position, boxSize/2, left, Quaternion.identity, rayLength);
		isCrashedRight= Physics.BoxCast (transform.position, boxSize/2, right, Quaternion.identity, rayLength);

		if (isCrashedLeft && h < 0) {
			moveVector.x = 0;

		}

		if (isCrashedRight && h > 0) {
			moveVector.x = 0;

		}

//		if ((isCrashedLeft || isCrashedRight) && isGrounded == false) {
//			moveVector.x = - Mathf.RoundToInt((moveVector.x / moveVector.x)) * 0.1f;
//		}

		if (isCrashed) {
			//si estoy en el piso el verticalSpeed es 
			//un valor negativo pequeño... esto es para 
			//asegurarnos que el player toque el piso
			//y no impida el movernos de lado a lado
			verticalSpeed = -1f;
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
		Vector3 pos = transform.position + (down * rayLength);
		Gizmos.DrawWireCube (pos, boxSize);
	}
}
