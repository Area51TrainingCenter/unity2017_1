using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public float speedX = 5;
	private Rigidbody _rigidbody;
	private float verticalSpeed;
	public float gravity = -10;
	public float rayleght = 1.1f;
	void Start () {
		_rigidbody = GetComponent<Rigidbody> ();
	}
	void Update () {
		Movement ();		
	}
	void Movement(){
		//Creamos un Vector3 que comienza en cero
		Vector3 moveVector = new Vector3 (0, 0, 0);
		float h = Input.GetAxis ("Horizontal");
		moveVector.x = h * speedX;
		//Physics.Raycast genera un rayo invisible
		//que te devuelve true si el rayo toca algo
		//y false si el rayo no toca nada
		bool isGrounded = Physics.Raycast (transform.position, new Vector3 (0, -1, 0), rayleght);
		//la gravedad se va aplicando al verticaSpeed
		verticalSpeed += gravity * Time.deltaTime;
		moveVector += new Vector3 (0, verticalSpeed, 0);
		if (isGrounded) {
			/*si estoy en el piso el verticalspeed es un valor negativo pequeño...esto es para asegurarnos que el
			 player toque el piso y no impida el movernos de lado a lado*/
			verticalSpeed = 0.1f;
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
		_rigidbody.velocity = moveVector;
	}
}
