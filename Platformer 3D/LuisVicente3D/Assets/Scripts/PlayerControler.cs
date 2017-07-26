using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour {
	public float Speed = 5;
	[System.NonSerialized]
	public float verticalSpeed = 0;
	private CharacterController _controler;
	public float gravity = 0;
	public float Correr = 0;
	public float CrouchSpeed = 1;
	public Animator _animation;
	private float EjeX;
	private float EjeZ;
	public float JumpForce;
	private Vector3 moveVector;
	public LayerMask _layermask;
	private bool techito;
	public GameObject Camara;
	public bool canControl = true;
	public Collider _weapon;

	void Start () {
		_controler = GetComponent <CharacterController> ();
		_animation = GetComponent <Animator> ();
	}
	void Update () {
			// Hacia los Costados
		EjeX = Input.GetAxis("Horizontal") ;
			// Hacia Adelante y Atras
		EjeZ = Input.GetAxis("Vertical") ;
		if (canControl) {
			MovimientoSuelo ();
			Saltar ();
			Agachar ();	
		}
		moveVector *= Time.deltaTime;
		_controler.Move (moveVector );
		moveVector.y = 0;
		transform.LookAt (transform.position + moveVector);
		Animaciones ();
	}

	void FixedUpdate(){
		bool AgacharS = _animation.GetBool ("Agachar");
		if (AgacharS) {
			if (Physics.Raycast (transform.position, Vector3.up, 2.30f, _layermask)) {
				Debug.DrawRay (transform.position, Vector3.up * 2.30f, Color.red);
				techito = true;
			} else {
				Debug.DrawRay (transform.position, Vector3.up * 2.30f, Color.green);
				techito = false;
			}
		}
	}

	void Saltar(){
		if (_controler.isGrounded) {
			verticalSpeed = -0.1f;
			if (Input.GetButtonDown("Jump")) {
				verticalSpeed = JumpForce;
			}
		} else {
			verticalSpeed -= gravity * Time.deltaTime;
		}

		Vector3 Gravedad = new Vector3 (0,verticalSpeed,0);


		moveVector += Gravedad;
	}

	void Agachar(){
		bool AgacharS = _animation.GetBool ("Agachar");
		if (AgacharS) {
			_controler.height = 1;
			Vector3 newCenter = _controler.center;
			newCenter.y = 0.45f;
			_controler.center = newCenter; 
		} else {
			_controler.height = 1.8f;
			Vector3 newCenter = _controler.center;
			newCenter.y = 0.85f;
			_controler.center = newCenter; 
		}
	}

	void Animaciones (){
		float end;
		float endS;
		if (EjeX != 0 || EjeZ != 0) {
			if (Input.GetButton("Correr")) {
				end = 2;
			}else {
			end = 1;
			}
		} else {
			end = 0;
		}	
	
		float star = _animation.GetFloat ("Speed");
		float result = Mathf.Lerp (star, end, Time.deltaTime * 5);
		_animation.SetFloat ("Speed", result);
		if (!_controler.isGrounded) {
			_animation.SetFloat ("VerticalSpeed", verticalSpeed);
		}
		_animation.SetBool ("isGrounded", _controler.isGrounded);

		if (Input.GetButton("Agachar") || techito) {
			_animation.SetBool ("Agachar", true);

		} else {
			_animation.SetBool ("Agachar", false);
			}
		if (Input.GetMouseButton (0)) {
			bool AgacharX = _animation.GetBool ("agachado");
			if (_controler.isGrounded && !AgacharX && canControl ) {
				_animation.SetTrigger ("atack");
			}
		} 
	}


	void MovimientoSuelo(){
		
			Vector3 CamaraRight = Camara.transform.right;
			CamaraRight.y = 0f;
			CamaraRight.Normalize ();
			Vector3 CamaraForward = Camara.transform.forward;
			CamaraForward.y = 0f;
			CamaraForward.Normalize ();
			moveVector = (CamaraRight * EjeX ) + (CamaraForward * EjeZ);
			moveVector.Normalize ();
			if (Input.GetButton("Agachar") || techito) {
				moveVector *= CrouchSpeed;
			} else {
				if (Input.GetButton("Correr")) {
					moveVector *= Correr;
				} else {
					moveVector *= Speed ;
				}
			}
	}
}
