using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
	public float speedX = 5;
	public float gravity = -10f;
	//public float speedy = 5;
	private Rigidbody _rigidbody;
	public float verticalSpeed;
	public float rayLengh = 0.7f;
	// Use this for initialization
	void Start () {
		//guardamos la referencia la cmponente Rigidbody
		//en nuestra variable
		_rigidbody = GetComponent<Rigidbody>(); 
	}
	
	// Update is called once per frame
	void Update () {
		//creamos un Vector3 que comienza en zero
		Vector3 moveVector = new Vector3(0,0,0);

		float h = Input.GetAxis ("Horizontal");
		moveVector.x = h * speedX;

		/*float v = Input.GetAxis ("Vertical");
		moveVector.y = v * speedy;*/


		Vector3 down = new Vector3 (0, -1, 0);
		//Physics.Raycast genera un rayo invisible
		//que te devuelve true si el rayo toca algo
		//y false si el rayo no toca nada
		bool isGrounder = Physics.Raycast (transform.position, down, rayLengh);


		if (isGrounder) 
		{
			//si estoy en el piso el verticalSpeed es
			//un valor negativo pequeño... esto es para
			//asegurarnos que le player toq el piso
			//y no impida moverse de lado a lado
			verticalSpeed = -0.1f;
		} 
		else {
			//la gravedad se va aplicando al verticalSpeed
			verticalSpeed += gravity * Time.deltaTime;	
		}


		/*if (Input.GetKey(KeyCode.A)) {
		/*moveVector.x = -speedX;
		}
		if (Input.GetKey(KeyCode.D)) {
		moveVector.x = speedX;
		}

		en lugar de pasarle los 3 numeros por separado
		le pasamo a la funcion Translate el Vector3
		cuando multiplicas un numero por un Vector3
		Mulitplicas el X, Y y Z por ese numero.
		transform.Translate (moveVector*Time.deltaTime);
		transform.Translate (moveX * Time.deltaTime, 0, 0);*/
		//+= es agregarle al ya creado

		moveVector += new Vector3 (0, verticalSpeed, 0);
		_rigidbody.velocity = moveVector;
	}
}
