using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {
	public float speed = 5;
	public float RunningSpeed = 10;
	private float verticalSpeed = 0;
	private CharacterController _controller;
	public float gravity = 10;
	public float jumpForce = 20;
	private Animator _animator; 
	// Use this for initialization
	void Start () {
		_controller = GetComponent<CharacterController> ();	
		_animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		float v = Input.GetAxis ("Vertical");
		float h = Input.GetAxis ("Horizontal");
		float end;


		Vector3 moveVector = new Vector3 (h, 0, v);
		moveVector.Normalize ();

		if (Input.GetKey(KeyCode.LeftShift)) {
			moveVector *= RunningSpeed;

		} else {
			moveVector *= speed;
		}
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


		if (v != 0 || h != 0 ) {
			end = 1;
			if (Input.GetKey(KeyCode.LeftShift)){
				end = 2;
			}
		} else {
			end = 0;
		}
		float start = _animator.GetFloat ("Speed");
		float result = Mathf.Lerp (start, end, Time.deltaTime * 5);
		_animator.SetFloat ("Speed",result);

	}
}
