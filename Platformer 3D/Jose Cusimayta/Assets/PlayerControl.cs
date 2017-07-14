using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {
	public float speed;
	private float verticalSpeed ;
	public float runSpeed;
	public float crouchSpeed;
	public LayerMask _mask;
	private CharacterController _controller;
	public float gravity;
	public float jumpForce;
	public Animator _animator;
	Vector3 moveVector;
	bool isLowCelling;
	// Use this for initialization
	void Start () {
		_controller = GetComponent<CharacterController> ();	
	}
	
	// Update is called once per frame
	void Update () {
		float v = Input.GetAxis ("Vertical");
		float h = Input.GetAxis ("Horizontal");
		ManageGroundMovement (v, h);
		ManageJumps ();
		ManageMovement ();
		ManageAnimation (v, h);
		ManageCrouch ();
	}

	void FixedUpdate(){
		bool isCrouched = _animator.GetBool ("isCrouch");
		if (isCrouched) {
			if (Physics.Raycast (transform.position, Vector3.up, 2f, _mask)) {
				Debug.DrawRay (transform.position, Vector3.up * 2f, Color.green);
				isLowCelling = true;
			} else {
				Debug.DrawRay (transform.position, Vector3.up*2f, Color.red);
				isLowCelling = false;
			}
		}
	}

	public void ManageMovement(){		
		moveVector *= Time.deltaTime;
		_controller.Move (moveVector);
		moveVector.y = 0;
		transform.LookAt (transform.position + moveVector);
	}

	public void ManageGroundMovement(float v, float h){
		//moveVector = new Vector3 (h, 0, v);
		Vector3 cameraForward=Camera.main.transform.forward;
		cameraForward.y = 0;
		cameraForward.Normalize();

		Vector3 cameraRight=Camera.main.transform.right;
		cameraRight.y = 0;
		cameraRight.Normalize();


		moveVector = h * cameraRight + v * cameraForward;
		moveVector.Normalize ();

		if (Input.GetButton ("Crounch") || isLowCelling) {
			moveVector *= crouchSpeed;
		} else {
			if (Input.GetButton ("Run")) {
				moveVector *= runSpeed;
			} else {
				moveVector *= speed;
			}
		}
	}

	public void ManageJumps(){
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
	}

	public void ManageCrouch(){
		Vector3 newCenter = _controller.center;
		if (Input.GetButton ("Crounch")) {			
			newCenter.y = 0.58f;
			_controller.center = newCenter;
			_controller.height = 1;
		} else if(!isLowCelling) {
			newCenter.y = 1.09f;
			_controller.center = newCenter;
			_controller.height = 2;
		}

	}

	public void ManageAnimation(float v, float h){
		float end;
		float endv;
		if (v != 0 || h != 0) {
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

		if (Input.GetButton ("Crounch")) {
			_animator.SetBool ("isCrouch", true);
		} else {
			if (!isLowCelling) {
				_animator.SetBool ("isCrouch", false);
			}
		}


		if (!_controller.isGrounded) {
			_animator.SetFloat ("verticalSpeed", verticalSpeed);
		}
		_animator.SetBool ("isGrounded", _controller.isGrounded);
	}	

}
