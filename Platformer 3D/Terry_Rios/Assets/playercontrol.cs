using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercontrol : MonoBehaviour {

	public float speed = 5;
	public float runspeed = 10;
	public float crouchspeed = 1;
	public float gravity =-10;
	private float oncrouch = 0;
	private float verticalspeed = 0;
	private bool islowcelling;
	public LayerMask _mask;
	private CharacterController _controler;
	private Animator _animator;
	private Vector3 movevector;
	// Use this for initialization
	void Start () {

		_controler = GetComponent<CharacterController> ();
		_animator = GetComponent<Animator> ();
	
		
	}
	
	// Update is called once per frame
	void Update () {
		float h = Input.GetAxis ("Horizontal");
		float v = Input.GetAxis ("Vertical");

		GroundMovement(h,v);

		VerticalMovement ();	

		Crouch ();

		movevector *= Time.deltaTime;

		//transform.Translate (movevector,Space.World);
		_controler.Move (movevector);
		movevector.y = 0;
		transform.LookAt (transform.position+movevector);
		SetAnimatorParameters (h,v);
		
	}

	void SetAnimatorParameters(float h,float v)
	{
		float end;
		if (h !=0 &&_controler.isGrounded == true || v!=0 &&_controler.isGrounded == true) {
			end=1;
			if (Input.GetButton("Run")) {
				end = 2;
			}
		}else{
			end =0;
		}

		float start = _animator.GetFloat("speed");

		float result= Mathf.Lerp(start,end,Time.deltaTime*5);
		_animator.SetFloat("speed",result);


		if (Input.GetButton("Crouch")&&_controler.isGrounded == true ||islowcelling&&_controler.isGrounded == true) {
			oncrouch = 1;
			if (h !=0|| v!=0 ) {
				oncrouch = 2;
			}

		} else {
			oncrouch = 0;
		}
		_animator.SetFloat("oncrouch",oncrouch);

		if (!_controler.isGrounded) {
			_animator.SetFloat ("verticalspeed",verticalspeed);
		}

		_animator.SetBool ("isgrounded",_controler.isGrounded);

	}

	void FixedUpdate(){
		
		if (Input.GetButton("Crouch")&&_controler.isGrounded == true) {

			if (Physics.Raycast(transform.position,Vector3.up,4.0f,_mask)) {
				Debug.DrawRay (transform.position, Vector3.up * 4.0f, Color.green);
				islowcelling = true;

			}
			else
			{
				Debug.DrawRay(transform.position,Vector3.up*4.0f,Color.red);
				islowcelling = false;
			}

		} 

	}

	void GroundMovement(float h,float v){


		Vector3 cameraforward = Camera.main.transform.forward;
		cameraforward.y = 0;
		cameraforward.Normalize ();
		Vector3 cameraright = Camera.main.transform.right;
		cameraright.y = 0;
		cameraright.Normalize ();
		movevector = (cameraright*h) + (cameraforward*v);
		movevector.Normalize ();
		movevector *= speed;
		if (Input.GetButton("Crouch")||islowcelling) {

			movevector *= crouchspeed;
		} else {

			if (Input.GetButton("Run")) {
				movevector *= runspeed;
			} else {
				movevector *= speed;
			}

		}

	}
	void VerticalMovement(){

		if (_controler.isGrounded == true) {
			verticalspeed = -0.1f;
			if (Input.GetButton("Jump")) {
				verticalspeed = 10;
			}

		} else {

			verticalspeed -= gravity*Time.deltaTime;
		}
		Vector3 gravedad = new Vector3 (0,verticalspeed,0);
		movevector += gravedad;

	}

	void Crouch(){


		if (Input.GetButton("Crouch")&&_controler.isGrounded == true) {

			_controler.height = 1;
			Vector3 newcenter = _controler.center;
			newcenter.y = 0.45f;
			_controler.center = newcenter;

		} else{
			_controler.height = 1.8f;
			Vector3 newcenter = _controler.center;
			newcenter.y = 0.84f;
			_controler.center = newcenter;

		}
	}
}
