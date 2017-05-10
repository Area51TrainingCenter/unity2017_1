using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public float speedX = 5f;
	public float speedY = 5f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		Movimiento ();
	}

	void Movimiento (){
		
		Vector3 moveVector = new Vector3 (0, 0, 0);

		//El Input.GetAxis ("Horizontal") le añade un suavizado al movimiento
		float h = Input.GetAxis ("Horizontal");

		moveVector.x = h * speedX;

		/*if (Input.GetKey(KeyCode.A)){
			moveVector.x = -speedX;
		}

		if (Input.GetKey (KeyCode.D)){
			moveVector.x = speedX;
		}*/

		transform.Translate (moveVector*Time.deltaTime);
		//transform.Translate(moveX * Time.deltaTime, moveY * Time.deltaTime, 0);
	}
}
