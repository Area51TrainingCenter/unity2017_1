using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {

	private float Speed = 10f;
	private CharacterController _controller;
	private Animator _animator;
	private float verticalSpeed = -10;
	private float multiplier = 1;
	public float gravitySpeed = 50;



	// Use this for initialization
	void Start () {
		_controller = GetComponent<CharacterController> ();
		_animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {

		float h = Input.GetAxis("Horizontal");
		float v = Input.GetAxis("Vertical");

		if (Input.GetKey(KeyCode.LeftShift) && (_controller.isGrounded)) {
			multiplier = 4;
		} else {
			if (_controller.isGrounded) { multiplier = 1; }
		}

		float myDestiny;

		if ( (Mathf.Abs (h) + Mathf.Abs (v) ) > 0) {
			myDestiny = 1 * multiplier;
		} else {
			myDestiny = 0;
		}



		float now = _animator.GetFloat ("inTheMove");
		float inertia = Mathf.Lerp (now, myDestiny, Time.deltaTime * 5);
		_animator.SetFloat("inTheMove",inertia);


			
		Vector3 moveVector = new Vector3 (h, 0, v);
		moveVector.Normalize();
		moveVector *= Speed*multiplier;



		if (_controller.isGrounded) {
			verticalSpeed = -0.10f * Time.deltaTime;

			if (Input.GetKey("space")) {
				verticalSpeed = 20;
			};

		} else {
			verticalSpeed -= gravitySpeed * Time.deltaTime;
		}

		Vector3 gravity = new Vector3 (0, verticalSpeed, 0);

		moveVector += gravity;

		moveVector *= Time.deltaTime;

		_controller.Move (moveVector);
	
		moveVector.y = 0;

		transform.LookAt (transform.position + moveVector);



	}
}
