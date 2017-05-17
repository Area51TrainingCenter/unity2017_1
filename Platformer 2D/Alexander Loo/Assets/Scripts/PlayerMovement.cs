using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public float speedX = 5;
	private Rigidbody _rigidbody;
	private float verticalSpeed;
	public float gravity = -10;
	public float rayleght = 1.1f;
	private bool isGrounded;
	public float jumpForce;
	private float h;
	private bool jump;

	void Start () {
		_rigidbody = GetComponent<Rigidbody> ();
	}

	void Update () {
		h = Input.GetAxis ("Horizontal");
		if (isGrounded) {
			if (Input.GetKeyDown (KeyCode.Space)) {
				jump = true;
			}
		}
	}

	void FixedUpdate(){
		//Creamos un Vector3 que comienza en cero
		Vector3 moveVector = new Vector3 (0, 0, 0);
		Vector3 down = new Vector3 (0, -1, 0);
		moveVector.x = h * speedX;
		//Physics.Raycast genera un rayo invisible
		//que te devuelve true si el rayo toca algo
		//y false si el rayo no toca nada
		//bool isGrounded = Physics.Raycast (transform.position, down, rayleght);
		Vector3 boxSize = new Vector3 (transform.localScale.x, transform.localScale.y, transform.localScale.z);
		boxSize *= 0.99f;
		isGrounded = Physics.BoxCast (transform.position, boxSize/2, down, Quaternion.identity, rayleght);
		if (isGrounded) {
			/*si estoy en el piso el verticalspeed es un valor negativo pequeño...esto es para asegurarnos que el
			 player toque el piso y no impida el movernos de lado a lado*/
			verticalSpeed = -0.1f;
			if (jump) {
				verticalSpeed = jumpForce;
				jump = false;
			}
		} else {
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
}