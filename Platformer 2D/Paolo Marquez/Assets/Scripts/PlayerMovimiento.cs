using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovimiento : MonoBehaviour {
	public float speedX = 0.1f;
	public float speedY = 0.1f;

	// Use this for initialization
	void Start () {
		
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
		float j=Input.GetAxis("Vertical");
		//h se multiplica por la velocidad dada
		moveVector.x = h * speedX;
		moveVector.y = j * speedY;

//		bool keyWPressed = Input.GetKey(KeyCode.W);
//		if (keyWPressed)
//		{
//			moveVector.y = speedY;
//		}
//
//		bool keyAPressed = Input.GetKey(KeyCode.A);
//		if (keyAPressed)
//		{
//			moveVector.x = -speedX;
//		}
//
//		bool keyDPressed = Input.GetKey(KeyCode.D);
//		if (keyDPressed)
//		{
//			moveVector.x = speedX;
//		}
//
//		bool keySPressed = Input.GetKey(KeyCode.S);
//		if (keySPressed)
//		{
//			moveVector.y = -speedY;
//
//		}



		//al presionar SHift se duplicara la velocidad
		bool keyLeftShiftPressed = Input.GetKey(KeyCode.LeftShift);

		if (keyLeftShiftPressed)
		{
			moveVector.x *= 2;
			moveVector.y *= 2;
		}

		//convierte la velocidad por frames a velocidad por segundo

		//transform.Translate(moveX * Time.deltaTime, moveY * Time.deltaTime, 0);
		transform.Translate(moveVector*Time.deltaTime);
	}

	void OnTriggerEnter(Collider other){
		Debug.Log ("Colisione");
		if(other.CompareTag("enemigo")){
			Destroy (gameObject);
			Destroy (other.gameObject);
		}	
	}	

}
