using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercontrol : MonoBehaviour {

	public float speed = 5;
	public float runspeed = 10;
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
		if (Input.GetKey (KeyCode.LeftShift)) {
			movevector *= runspeed;
		} else {
			movevector *= speed;
		}
		float end;
		if (h !=0 || v!=0) {
			end=1;
			if (Input.GetKey (KeyCode.LeftShift)&&_controler.isGrounded == true) {
				end = 2;
			}
		}else{
			end =0;
		}
		float start = _animator.GetFloat("speed");
		float result= Mathf.Lerp(start,end,Time.deltaTime*5);
		_animator.SetFloat("speed",result);
			

		if (_controler.isGrounded == true) {
			verticalspeed = -0.1f;
			if (Input.GetKeyDown(KeyCode.Space)) {
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
