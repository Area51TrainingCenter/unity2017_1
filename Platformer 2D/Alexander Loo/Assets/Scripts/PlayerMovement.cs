using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public float speedX = 5;
	void Start () {
		
	}
	void Update () {
		Movement ();		
	}
	void Movement(){
		//Creamos un Vector3 que comienza en cero
		Vector3 moveVector = new Vector3 (0, 0, 0);
		float h = Input.GetAxis ("Horizontal");
		moveVector.x = h * speedX;
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
		transform.Translate (moveVector * Time.deltaTime);
	}
}
