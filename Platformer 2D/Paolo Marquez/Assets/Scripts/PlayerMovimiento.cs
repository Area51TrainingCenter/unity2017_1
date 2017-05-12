using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovimiento : MonoBehaviour {
	public float speedX = 0.1f;
	public float gravity = -10;
	private Rigidbody _rigidbody;
	//los float por defecto valen cero
	private float verticalSpeed;
	public float rayLenght=0.6f;

	// Use this for initialization
	void Start () {
		_rigidbody = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		Movimiento ();
		//Debug.Log ("deltatime=" + Time.deltaTime);
	}

	void Movimiento()
	{
		Vector3 moveVector =new Vector3(0,0,0);

		//movimiento WASD
		float h=Input.GetAxis("Horizontal");
		//float j=Input.GetAxis("Vertical");
		//h se multiplica por la velocidad dada
		moveVector.x = h * speedX;

		Vector3 down = new Vector3 (0, -1, 0);
		//raycast genera un rayo invisble que te devuelve true si choca al algun suelo o false si no toca nada
		bool isGrounded=Physics.Raycast (transform.position, down, rayLenght);
		if(isGrounded==true){
			//si estoy en el piso el vertical speed es un valor negativo pequeño, para que el jugador toque el piso
			verticalSpeed = -0.1f;
		}
		else{
			//la gravedad se va aplicando al verticalSpeed
			verticalSpeed += gravity*Time.deltaTime;
		}

		moveVector += new Vector3 (0, verticalSpeed, 0);

//		if(isGrounded==false){
//			//la gravedad se va aplicando
//			verticalSpeed += gravity*Time.deltaTime;
//
//		}	


		//al presionar SHift se duplicara la velocidad
		bool keyLeftShiftPressed = Input.GetKeyDown(KeyCode.LeftShift);

		if (keyLeftShiftPressed)
		{
//			moveVector.x *= 2;
//			moveVector.y *= 2;
			//rayLenght = 2;
		}
		//if(keyLeftShiftPressed==false){rayLenght = 0.6f;}

		//convierte la velocidad por frames a velocidad por segundo

		//transform.Translate(moveX * Time.deltaTime, moveY * Time.deltaTime, 0);
		_rigidbody.velocity=moveVector;
		//transform.Translate(moveVector*Time.deltaTime);
	}

	void OnTriggerEnter(Collider other){
		Debug.Log ("Colisione");
		if(other.CompareTag("enemigo")){
			Destroy (gameObject);
			Destroy (other.gameObject);
		}	
	}	

}
