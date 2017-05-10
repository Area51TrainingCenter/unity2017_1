using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
	public float speedX = 5;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		//creamos un Vector3 que comienza en zero
		Vector3 moveVector = new Vector3(0,0,0);

		float h = Input.GetAxis ("Horizontal");
		moveVector.x = h*speedX;
		Debug.Log (h);
		/*
		if (Input.GetKey(KeyCode.A)) {
			moveVector.x = -speedX;
		}
		if (Input.GetKey(KeyCode.D)) {
			moveVector.x = speedX;
		}
		*/
		//en lugar de pasarle los 3 numeros por separado
		//le pasamo a la funcion Translate el Vector3
		//cuando multiplicas un numero por un Vector3
		//Mulitplicas el X, Y y Z por ese numero.
		transform.Translate (moveVector*Time.deltaTime);
		//transform.Translate (moveX * Time.deltaTime, 0, 0);
	}
}
