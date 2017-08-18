using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {

	public float Speed;
	private CharacterController _controller;
	private Animator _animator;
	public float multiplier = 1;
	private float crouchingSpeed = 0.3f;
	public float gravitySpeed = 50;
	public float jumpForce = 20;
	public bool canControl = true;

	[System.NonSerialized]
	public float verticalSpeed = -10;

	public LayerMask _mask;

	private Vector3 moveVector;
	private bool BadIdeaToStandUp;

	public GameObject camara;

	public Collider _weapon;


	// Use this for initialization
	void Start () {
		_controller = GetComponent<CharacterController> ();
		_animator = GetComponent<Animator> ();

		DisableWeaponTrail();

		Speed = 10f;

	}
	
	// Update is called once per frame
	void Update () {
		
		bool isCrouching = _animator.GetBool ("isCrouching");

		if ( (canControl) && (_controller.isGrounded) && (Input.GetButton("Atacar")) && (!isCrouching) ) {
			_animator.SetTrigger("Attack");
		}

		Vector3 oldPlayerPosition = transform.position;

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

		Vector3 newPlayerPosition = transform.position;

		CamaraMovement (oldPlayerPosition,newPlayerPosition);
	}

	void CamaraMovement(Vector3 oldPlayerPosition, Vector3 newPlayerPosition) {
		Vector3 difference = newPlayerPosition - oldPlayerPosition;

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

			if (Input.GetButton("Jump") && !( _animator.GetBool("isCrouching")) && canControl ){
				verticalSpeed = jumpForce;
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

		if (!canControl) {
			return;
		}

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

	public void EnableWeaponTrail() {
		_weapon.GetComponentInChildren<TrailRenderer>().time = 0.3f;
	}

	public void DisableWeaponTrail() {
		_weapon.GetComponentInChildren<TrailRenderer>().time = 0.0f;
	}
}
