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

	private Rigidbody _rigibody;
	private float verticalSpeed;
	private bool isGrounded; // abajo
	private bool isGrounded2; // arriba
	private bool isGrounded3;// izquierda
	private bool isGrounded4;// derecha

	private float h;
	private bool KeySpacePressed;
	
	// Use this for initialization
	void Start () {
		// Guardamos la referencia la componente RigiBody
		_rigibody = GetComponent<Rigidbody> ();

	}
	
	// Update is called once per frame
	void Update () {
		h = Input.GetAxis ("Horizontal");

			if (Input.GetKeyDown (KeyCode.Space) && isGrounded) {
				KeySpacePressed = true;
			}
		
	}



	// creamos nuestra funcion movimiento
	void FixedUpdate() {
		
		Vector3 moveVector = new Vector3(0,0,0);
		moveVector.x = h * speedX;	

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

		//BoxCast = devuelve un boleano: true o false
		isGrounded = Physics.BoxCast(transform.position,boxSize/2,down,Quaternion.identity,raylength); //Quaternion.identity => rotacion= 0,0,0 
		isGrounded2 = Physics.BoxCast(transform.position,boxSize/2,up,Quaternion.identity,raylength);   // Arriba
		isGrounded3 = Physics.BoxCast(transform.position,boxSize/2,left,Quaternion.identity,raylength);  // Izquierda
		isGrounded4 = Physics.BoxCast(transform.position,boxSize/2,right,Quaternion.identity,raylength);  // Derecha

		if (isGrounded4 && h>0) {
			moveVector.x = 0;
		} 

		if (isGrounded3 && h<0) {
			moveVector.x = 0;
		} 

		// Para que no se quede pegado en el techo
		if (isGrounded2) {
			verticalSpeed = 0;
		} 


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


}
