using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {
	public float speed;
	private float verticalSpeed ;
	public float runSpeed;
	public float crouchSpeed;
	private CharacterController _controller;
	public float gravity;
	public float jumpForce;
	public Animator _animator;
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
		if (Input.GetButton("Crounch")) {
			moveVector *= crouchSpeed;
		} else {
			if (Input.GetButton("Run")) {
				moveVector *= runSpeed;
			} else {
				moveVector *= speed;
			}
		}
		if (_controller.isGrounded) {
			verticalSpeed = -0.1f;
			if (Input.GetButton("Jump") && !Input.GetButton("Crounch")) {
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
		ManageAnimation (v,h);

	}
	public void ManageAnimation(float v, float h){
		float end;
		float endv;
		if (v != 0 || h!=0) {
			if (Input.GetKey (KeyCode.LeftShift))
				end = 2;
			else
				end = 1;	
		} else {
			end = 0;
		}
		float start = _animator.GetFloat ("movimiento");
		float result = Mathf.Lerp (start, end, Time.deltaTime * 5);
		_animator.SetFloat ("movimiento", result);

		if (Input.GetButton("Crounch")) {
			_animator.SetBool ("isCrouch", true);
		} else {
			_animator.SetBool ("isCrouch", false);
		}


		if (!_controller.isGrounded) {
			_animator.SetFloat ("verticalSpeed", verticalSpeed);
		}
		_animator.SetBool ("isGrounded", _controller.isGrounded);
	}
}
