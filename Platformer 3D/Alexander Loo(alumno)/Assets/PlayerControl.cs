using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {
	public float speed = 5;
	private float verticalSpeed = 0;
	private CharacterController _controller;
	public float gravity = 10;
	public float jumpForce = 20;
	// Use this for initialization
	void Start () {
		_controller = GetComponent<CharacterController> ();	
	}
	
	// Update is called once per frame
	void Update () {
		float v = Input.GetAxis ("Vertical");
		float h = Input.GetAxis ("Horizontal");

		Vector3 moveVector = new Vector3 (h, 0, v);
		moveVector.Normalize ();
		moveVector *= speed;

		if (_controller.isGrounded) {
			verticalSpeed = -0.1f;
			if (Input.GetKeyDown(KeyCode.Space)) {
				verticalSpeed = jumpForce;
			}
		}else{
			verticalSpeed -= gravity*Time.deltaTime;
		}


		Vector3 gravityVector = new Vector3 (0, verticalSpeed, 0); 
		moveVector += gravityVector;
		moveVector *= Time.deltaTime;
		//transform.Translate (moveVector,Space.World);
		_controller.Move (moveVector);
		moveVector.y = 0;
		transform.LookAt (transform.position + moveVector);
	}
}
