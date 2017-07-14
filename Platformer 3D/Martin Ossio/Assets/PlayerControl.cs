using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {

	public float Speed;
	private CharacterController _controller;
	private Animator _animator;
	private float verticalSpeed = -10;
	public float multiplier = 1;
	private float crouchingSpeed = 0.3f;
	public float gravitySpeed = 50;

	public LayerMask _mask;

	private Vector3 moveVector;
	private bool BadIdeaToStandUp;

	public GameObject camara;


	// Use this for initialization
	void Start () {
		_controller = GetComponent<CharacterController> ();
		_animator = GetComponent<Animator> ();

		Speed = 10f;
	}
	
	// Update is called once per frame
	void Update () {

		// oldPlayerPosition = 

		float h = Input.GetAxis("Horizontal");
		float v = Input.GetAxis("Vertical");

		GroundMovement (h, v);

		VerticalMovement ();

		Crouch ();



		moveVector *= Time.deltaTime;
		_controller.Move (moveVector);	
		moveVector.y = 0;
		transform.LookAt (transform.position + moveVector);

		SetAnimatorParameter (h, v);

		// CamaraMovement (oldPlayerPosition,newPlayerPosition);
	}

	void CamaraMovement() {

	}

	void Crouch(){
		bool isCrouching = _animator.GetBool ("isCrouching");
	
		if (isCrouching) {
			_controller.height = 1;
			Vector3 newCenter = _controller.center;
			newCenter.y = 0.45f;
			_controller.center = newCenter;
		} else {
				_controller.height = 1.8f;
				Vector3 newCenter = _controller.center;
				newCenter.y = 0.85f;
				_controller.center = newCenter;
		}
	}

	void VerticalMovement () {

		if (_controller.isGrounded) {
			verticalSpeed = -0.10f;

			if (Input.GetButton("Jump") && !( _animator.GetBool("isCrouching"))) {
				verticalSpeed = 20;
			};

		} else {
			verticalSpeed -= gravitySpeed * Time.deltaTime;
		}
			

		Vector3 gravity = new Vector3 (0, verticalSpeed, 0);
		moveVector += gravity;
	}

	void FixedUpdate(){
		bool isCrouching = _animator.GetBool ("isCrouching");

		if (isCrouching) {
			if (Physics.Raycast (transform.position, Vector3.up, 7.0f, _mask)) {
				Debug.DrawRay (transform.position, Vector3.up * 7.0f, Color.green);
				BadIdeaToStandUp = true;
			} else {
				Debug.DrawRay (transform.position, Vector3.up * 7.0f, Color.red);
				BadIdeaToStandUp = false;
			}
		}
	}

	void GroundMovement (float h, float v){

		Vector3 cameraForward = Camera.main.transform.forward;
		Vector3 cameraRight = Camera.main.transform.right;

		cameraForward.y = 0;
		cameraRight.y = 0;

		cameraForward.Normalize();
		cameraRight.Normalize();

		Vector3 newH = h * cameraRight;
		Vector3 newV = v * cameraForward;


		moveVector = newH + newV;
		moveVector.y = 0;

		// moveVector = new Vector3 (h, 0, v);
		moveVector.Normalize();


		if (Input.GetButton("Run") && (_controller.isGrounded)) {
			multiplier = 4;
		} else {
			if (_controller.isGrounded) { multiplier = 1; }
		}


		moveVector *= Speed*multiplier;

	}

	void SetAnimatorParameter(float h, float v){

		float myDestiny;

		if ( (Mathf.Abs (h) + Mathf.Abs (v) ) > 0) {
			myDestiny = 1 * multiplier;
		} else {
			myDestiny = 0;
		}


		float now = _animator.GetFloat ("inTheMove");
		float inertia = Mathf.Lerp (now, myDestiny, Time.deltaTime * 5);


		if ( (Input.GetButton("Crouch") && (_controller.isGrounded) ) || BadIdeaToStandUp) {
			multiplier = crouchingSpeed;
			_animator.SetBool ("isCrouching", true);
		} else {
			_animator.SetBool ("isCrouching", false);
		
		}

		_animator.SetFloat("inTheMove",inertia);

		if (!_controller.isGrounded) {
			_animator.SetFloat("verticalSpeed",verticalSpeed);
		}

		_animator.SetBool ("isGrounded", _controller.isGrounded);

	}
}
