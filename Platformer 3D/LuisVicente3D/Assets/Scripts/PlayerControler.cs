using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour {
	public float Speed = 5;
	public float verticalSpeed = 0;
	private CharacterController _controler;
	public float gravity;

	// Use this for initialization
	void Start () {
		_controler = GetComponent <CharacterController> ();
	}
	
	// Update is called once per frame
	void Update () {
			// Hacia los Costados
		float EjeX = Input.GetAxis("Horizontal") ;
			// Hacia Adelante y Atras
		float EjeZ = Input.GetAxis("Vertical") ;
		if (!_controler.isGrounded) {
			verticalSpeed -= 1;
		} else {
			Saltar ();
		}

		Vector3 Gravedad = new Vector3 (0,verticalSpeed,0);
		Vector3 moveVector = new Vector3 (EjeX,0,EjeZ);
		moveVector.Normalize ();
		/*if (_controler.isGrounded) {
			verticalSpeed = 0.1f;
		} else {
			verticalSpeed -= gravity * Time.deltaTime;
		}*/
		moveVector += Gravedad;
		moveVector *= Speed ; 
		moveVector *= Time.deltaTime;
		//transform.Translate (moveVector,Space.World);
		_controler.Move (moveVector );
		moveVector.y = 0;
		transform.LookAt (transform.position + moveVector);

	}
	void Saltar(){
		if (Input.GetKeyDown (KeyCode.Space)) {
			verticalSpeed = 7f;
		}
	}
}
