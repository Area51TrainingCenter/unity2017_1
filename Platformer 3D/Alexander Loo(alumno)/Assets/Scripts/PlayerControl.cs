using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {

	/*Las variables globales ocupan espacio en la memoria (por que no se destruyen),
	 por eso es más eficiente usar la menor cantidad de variables globales*/
	
	private CharacterController _controller;
	private Animator _animator;

	private bool isCrouch;
	public float speed;
	public float turbo;
	public float crouchSpeed;
	private bool running;
	private float verticalSpeed;
	public float gravity;
	public float jumpForce;
	private Vector3 moveVector;

	public LayerMask _mask;
	private bool isTechito;

	void Start () {
		_controller = GetComponent<CharacterController> ();
		_animator = GetComponent<Animator> ();
	}

	void Update () {
		 float v = Input.GetAxis ("Vertical");
		 float h = Input.GetAxis ("Horizontal");
		isCrouch = Input.GetButton("Crouch");

		GroundMovement (h,v);
		VerticalMovement ();
		Crouch ();

		moveVector *= Time.deltaTime;
		//transform.Translate (moveVector,Space.World);
		_controller.Move (moveVector);
		//para que no mire el piso. el Move(moveVector) no se ve afectado ya que la función lo ejecuta antes
		moveVector.y = 0;
		//para ver hacia una dirección (posición del objeto + dirección de movimiento)
		transform.LookAt (transform.position + moveVector);
		AnimationsManager (h,v);
	} 

	void FixedUpdate(){

		bool isCrouched = _animator.GetBool ("isCrouch");
		if (isCrouched) {
			if (Physics.Raycast(transform.position,Vector3.up,4,_mask)) {
				//para poder visualizar el raycast, el tamaño del ray es 1 por defecto, por lo que se multiplica por 4 para que sea mas visible
				Debug.DrawRay (transform.position, Vector3.up * 4, Color.green);
				isTechito = true;
			}else{
				Debug.DrawRay (transform.position, Vector3.up * 4, Color.red);
				isTechito = false;
			}
		}
	}

	void AnimationsManager(float h,float v){

		/*if (Mathf.Abs (v) > 0 || Mathf.Abs(h) > 0) {
			_animator.SetBool ("movement", true);
		} else {
			_animator.SetBool ("movement", false);
		}*/
		float end;
		if (h != 0 || v != 0) {
			if (running) {
				end = 2;
			} else {
				end = 1;
			}
		} else {
			end = 0;
		}
		//el valor inicial es el valor actual del parametro speed
		float start = _animator.GetFloat ("Speed");
		//la función lerp SOLAMANETE CALCULA EL NÚMERO no hace nada con el animator
		//por lo que almacenamos el resultado de lerp en una variable
		float result = Mathf.Lerp (start, end, Time.deltaTime * 5);
		//y luego lo aplicamos al parametro speed del animator
		_animator.SetFloat ("Speed", result);
		_animator.SetBool ("isGrounded", _controller.isGrounded);
		if (!_controller.isGrounded) {
			_animator.SetFloat ("VerticalSpeed", verticalSpeed);
		}
		_animator.SetBool ("isCrouch", isCrouch || isTechito);
	}

	void GroundMovement(float h, float v){
		
		//Camera.main es un atajo que busca la cámara principal sin necesidad de crear una variable para buscarla
		Vector3 cameraForward = Camera.main.transform.forward;
		cameraForward.y = 0;
		cameraForward.Normalize ();
		Vector3 cameraRight = Camera.main.transform.right;
		cameraRight.y = 0;
		cameraRight.Normalize ();
		/*

		(h,0,v)
		(h,0,0) + (0,0,v)
		h*(1,0,0)   +   v*(0,0,1)
		h*Vector3.right    +   v*Vector3.forward

		h*camera.transform.right    +   v*camera.transform.forward

		*/
		moveVector = cameraRight * h + cameraForward * v; 
		moveVector.Normalize ();

		//La velocidad de los lados también actua mientras está en el aire, por eso escribimos las condicionales fuera del "isGrounded"
		if (isCrouch || isTechito) {
			moveVector *= crouchSpeed;
		}
		else if (Input.GetKey (KeyCode.LeftShift)) {
			moveVector *= turbo;
			running = true;
		} else {
			moveVector *= speed;
			running = false;
		}
	}

	void VerticalMovement(){

		if (_controller.isGrounded) {
			verticalSpeed = -0.1f;
			if (Input.GetButton ("Jump")) {
				verticalSpeed = jumpForce;
			}
		} else {
			verticalSpeed -= gravity * Time.deltaTime;
		}
		Vector3 gravityVector = new Vector3 (0, verticalSpeed, 0); 
		moveVector += gravityVector;
	}

	void Crouch(){

		bool isCrouched = _animator.GetBool ("isCrouch");
		if (isCrouched) {
			_controller.height = 1;
			//cuando usamos vector3 no podemos modificar sus variables individuales directamente(Controller.center.y = 0.45f)
			//tenemos que almacenarlo en un nuevo Vector3 para poder hacerlo
			Vector3 newCenter = _controller.center;
			newCenter.y = 0.45f;
			// y lo asignamos para que funcione
			_controller.center = newCenter;
		} 
		else {
			if (!isTechito) {
				_controller.height = 1.8f;
				//otra forma eficiente de hacerlo
				_controller.center = new Vector3 (0, 0.85f, 0);
			}
		}
	}
}
