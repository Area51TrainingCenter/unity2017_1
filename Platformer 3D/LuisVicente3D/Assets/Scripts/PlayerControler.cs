using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour {
	public float Speed = 5;
	public float verticalSpeed = 0;
	private CharacterController _controler;
	public float gravity = 0;
	public float Correr = 0;
	public Animator _animation;
	private float EjeX;
	private float EjeZ;
	// Use this for initialization
	void Start () {
		_controler = GetComponent <CharacterController> ();
		_animation = GetComponent <Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
			// Hacia los Costados

		EjeX = Input.GetAxis("Horizontal") ;
			// Hacia Adelante y Atras
		EjeZ = Input.GetAxis("Vertical") ;


		if (!_controler.isGrounded) {
			verticalSpeed -= gravity * Time.deltaTime;
		} else {
			Saltar ();
		}

		Vector3 Gravedad = new Vector3 (0,verticalSpeed,0);
		Vector3 moveVector = new Vector3 (EjeX,0,EjeZ);
		moveVector.Normalize ();
		if (Input.GetKey (KeyCode.LeftShift)) {
			moveVector *= Correr;
		} else {
			moveVector *= Speed ;
		}

		moveVector += Gravedad;
		moveVector *= Time.deltaTime;
		//transform.Translate (moveVector,Space.World);
		_controler.Move (moveVector );
		moveVector.y = 0;
		transform.LookAt (transform.position + moveVector);
		Animaciones ();
	}


	void Saltar(){
		if (Input.GetKey(KeyCode.Space)) {
			verticalSpeed = 7f;
		}
	}
	void Animaciones (){
		float end;

		if (EjeX != 0 || EjeZ != 0) {
			if (Input.GetKey (KeyCode.LeftShift)) {
				end = 2;
			}else {
			end = 1;
			}
		} else {
			end = 0;
		}	

		float star = _animation.GetFloat ("Speed");
		float result = Mathf.Lerp (star, end, Time.deltaTime * 5);
		_animation.SetFloat ("Speed", result);
	
	}
}
