using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercontrol : MonoBehaviour {

	public float speed = 5;
	public float runspeed = 10;
	public float crouchspeed = 1;
	public float gravity =-10;
	private float verticalspeed = 0;
	private CharacterController _controler;
	private Animator _animator;
	// Use this for initialization
	void Start () {

		_controler = GetComponent<CharacterController> ();
		_animator = GetComponent<Animator> ();
		
	}
	
	// Update is called once per frame
	void Update () {
		float h = Input.GetAxis ("Horizontal");
		float v = Input.GetAxis ("Vertical");

		Vector3 movevector = new Vector3 (h,0,v);



		movevector.Normalize ();
		movevector *= speed;
		if (Input.GetButton("Crouch")) {
			
			movevector *= crouchspeed;
		} else {

			if (Input.GetButton("Run")) {
				movevector *= runspeed;
			} else {
				movevector *= speed;
			}

		}
	
		float end;
		if (h !=0 &&_controler.isGrounded == true || v!=0 &&_controler.isGrounded == true) {
			end=1;
			if (Input.GetButton("Run")) {
				end = 2;
			}
		}else{
			end =0;
		}
		float oncrouch = 0; 

		if (Input.GetButton("Crouch")&&_controler.isGrounded == true) {
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

		float start = _animator.GetFloat("speed");

		float result= Mathf.Lerp(start,end,Time.deltaTime*5);
		_animator.SetFloat("speed",result);
			

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
		movevector *= Time.deltaTime;

		//transform.Translate (movevector,Space.World);
		_controler.Move (movevector);
		movevector.y = 0;
		transform.LookAt (transform.position+movevector);

		
	}
}
