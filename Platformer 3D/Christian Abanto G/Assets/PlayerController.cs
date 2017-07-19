using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	public float speed = 5f;
	public float runSpeed = 10f;
	public float crouchSpeed = 1;
	private CharacterController _controller;

	[System.NonSerialized] 			// esto solo oculta la variable publica para que no figure en el componente "PlayerController"
	public float verticalSpeed; 	// puedes utilizarlo desde otro codigo

	public float gravity;
	public float jump = 10;
	private Vector3 moveVector;
	private Vector3 gravityVector;
	public LayerMask _mask;

	// variable para saber si hay techo en nuesta cabeza
	private bool isLowCeiling;

	// variables animator
	private Animator _animator;


	// Use this for initialization
	void Start () {
		_controller = GetComponent<CharacterController> ();
		_animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		// 	POSICIONAR
			//  obtener inputs ( H y V, y SPACE )
				float ejeH = Input.GetAxis ("Horizontal");
				float ejeV = Input.GetAxis ("Vertical");
				// generar movimiento horizontal y vertical
				GroundMovement (ejeH, ejeV);
			// aplicar movimiento (al saltar )
				VerticalMovement ();
				moveVector *= Time.deltaTime;
			//	actualizar vector ( si esta agachado, disminuir velocidad )
				//moveVector = _animator.GetBool ("isCrouch") ? moveVector*crouchSpeed : moveVector;
			//  aplicar direccion de movimiento
				//transform.Translate(moveVector, Space.World);
				_controller.Move (moveVector); // similar a translate, la diferencia es que colisiona ( se detiene si hay un bloque )
			//  reestablecer Y				
				moveVector.y = 0; // ( gravedad no debe aplicarle )
				float ejeY = 0;
		//  ROTAR
			// rotara en base a su direccion de movimiento ( moveVector )
			transform.LookAt( transform.position + moveVector );

		//  ANIMATOR 
			SetAnimatorParameters (ejeH, ejeV);
					
	}

	void FixedUpdate(){
		// saber si estas agachado
		if (_animator.GetBool ("isCrouch")) {
			if (Physics.Raycast(transform.position, Vector3.up, 4.0f, _mask)) {
				// Debug,DrawRay dibuja la linea... le damos los mismos parametros que el
				Debug.DrawRay(transform.position, Vector3.up*4.0f, Color.green);
				isLowCeiling = true;
			} else {
				Debug.DrawRay(transform.position, Vector3.up*4.0f, Color.red);
				isLowCeiling = false;
			}
		}
	}

	void saltar(){
		if (Input.GetButton ("Saltar")) {
			verticalSpeed = jump;
		} else {
			verticalSpeed = -0.1f;
		}

	}

	void SetAnimatorParameters( float ejeH, float ejeV ){
		//  ANIMATOR 
			// ¿esta caminando?
				// old ( utilizando animacion independiente )
					//bool isWalk = ejeH != 0 || ejeV != 0 ? true : false;
					//_animator.SetBool ("isWalk", isWalk);
				// new ( utilizando Blend Tree, que es un agrupador de animaciones )
			// definimos speed final
			float end;
			if (ejeH != 0 || ejeV != 0) { 
				end = 1; 
				// verificar si esta corriendo
				if ( Input.GetKey (KeyCode.LeftShift) ) {
					end = 2;
				} 
			} else { 
				end = 0; 
			}

			// obtenemos speed inicial
				float start = _animator.GetFloat ("speed");
			// calculamos resultado
				float result = Mathf.Lerp (start, end, Time.deltaTime * 5);
			// seteamos valor speed
				_animator.SetFloat ("speed", result); 
				// Nota: 
				// en el animator, el Blend Tree con nombre "Movement", 
				// su campo "Threshold" son los valores definidos por nosotros,
				// si al setear el valor de "speed" concuerda con uno de los valores de "Threshold" 			
				// entonces cambiara la animación.

			// ¿esta saltando?
				// si no toca piso ( animacion Airbone )  
				_animator.SetBool("isGrounded", _controller.isGrounded );
				// verificar estado y saltar
				if (!_controller.isGrounded) {
					_animator.SetFloat("verticalSpeed", verticalSpeed);
				}
			// ¿esta agachado?
				// agachado
				if (Input.GetButton ("Agacharse") || isLowCeiling ) {
					_animator.SetBool ("isCrouch", true);
				} else {
					_animator.SetBool ("isCrouch", false);
				}
	}

	void GroundMovement( float ejeH, float ejeV ) {

		/* EJEMPLO DESCOMPONER VECTOR para luego enfocarlo con las posiciones de otro objeto
			( H , 0 , V )
			-------------------------------------------
			( H , 0 , 0 )       +   ( 0 , 0 , V )	
			H * ( 1 , 0 , 0 )   +   V * ( 0 , 0 , 1 ) 
			H * Vector3.right   +   V * Vector3.forward
			-------------------------------------------
			EJEMPLO: 
				H * camara.transform.right  +  V * camara.transform.forward
			NOTA:
				originalmente al mover el objeto, este se mueve en base a las coordenadas globales del escenario
				pero al mover la camara, el movimiento se altera, por eso obtenemos las coordenadas de la misma camara
				asimismo al cambiar de camara, el objeto se mover correctamente
			CURIOSIDAD:
				existe una clase "Camera", la utilizamos asi "Camera.main" y obtengo la camara principal :)
		*/

		// obtenemos la camara
		GameObject camara = GameObject.Find("Camara");
		// obtenemos el Forward, seteamos su Y, luego lo normalizamos
		Vector3 camaraForward = camara.transform.forward;
		camaraForward.y = 0; // es cero porque si giramos la camara en direccion picada, el objeto se ira en picada ( por el forward ) 
		camaraForward.Normalize(); // se normaliza para que el vector tenga direccion, sino sale cosa extraña
		// obtenemos el Right
		Vector3 camaraRight = camara.transform.right;
		camaraRight.y = 0; // es cero porque si giramos la camara en direccion picada, el objeto se ira en picada ( por el forward ) 
		camaraRight.Normalize(); // se normaliza para que el vector tenga direccion, sino sale cosa extraña

		// definir vector movimiento
		// moveVector = new Vector3 (ejeH, 0, ejeV);
		moveVector = ( ejeH * camaraRight ) + ( ejeV * camaraForward );
		gravityVector = new Vector3 (0, verticalSpeed , 0);
		//  normalizar movimiento ( para que siempre sea 1 la direccion )
		moveVector.Normalize (); 

		// 	definir velocidad
		if (Input.GetButton ("Agacharse") || isLowCeiling ) {
			moveVector *= crouchSpeed;
			Crouch();
		} else {
			if (Input.GetButton ("Correr")) {
				moveVector *= runSpeed;
			} else {
				moveVector *= speed;
			}
			Crouch();
		}
	}

	void VerticalMovement () {
		// 	definir vector gravedad
		if (!_controller.isGrounded) { 
			verticalSpeed -= gravity * Time.deltaTime; 
			//_animator.SetBool ("isGrounded", true);
		} else { 
			saltar ();
			//_animator.SetBool ("isGrounded", false);
		}
		//  actualizar vector ( usando la velocidad y gravedad )
		//moveVector *= Input.GetKey (KeyCode.LeftShift) ? runSpeed :  speed ; // determinamos velocidad es aumentado o normal
		//moveVector *= Input.GetButton ("Correr") ? runSpeed :  speed ; // determinamos velocidad es aumentado o normal
		moveVector += gravityVector;


	}

	void Crouch(){
		Vector3 temporalVector = _controller.center;

		if (_animator.GetBool ("isCrouch")) {
			_controller.height = 1f;
			temporalVector.y = 0.45f;
			_controller.center = temporalVector;
		} else {
			if ( !isLowCeiling ) {
				_controller.height = 1.8f;
				temporalVector.y = 0.9f;
				_controller.center = temporalVector;
			}
		}
	}
	///////////////////////// RECICLAJE
	// ¿esta corriendo?
	//bool isRun =  Input.GetKey (KeyCode.LeftShift);
	//_animator.SetBool ("isRun", isRun);
}
