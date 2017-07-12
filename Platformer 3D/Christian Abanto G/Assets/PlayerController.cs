using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	public float speed = 5f;
	public float runSpeed = 10f;
	public float crouchSpeed = 1;
	private CharacterController _controller;
	private float verticalSpeed;
	public float gravity;
	public float jump = 10;

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
			//  definir vector movimiento
				Vector3 moveVector = new Vector3 (ejeH, 0, ejeV);
			// 	definir vector gravedad
				if (!_controller.isGrounded) { 
					verticalSpeed -= gravity * Time.deltaTime; 
					//_animator.SetBool ("isGrounded", true);
				} else { 
					saltar ();
					//_animator.SetBool ("isGrounded", false);
				}
				Vector3 gravityVector = new Vector3 (0, verticalSpeed , 0);
			//  normalizar movimiento ( para que siempre sea 1 la direccion )
				moveVector.Normalize (); 
			//  actualizar vector ( usando la velocidad y gravedad )
				//moveVector *= Input.GetKey (KeyCode.LeftShift) ? runSpeed :  speed ; // determinamos velocidad es aumentado o normal
				moveVector *= Input.GetButton ("Correr") ? runSpeed :  speed ; // determinamos velocidad es aumentado o normal
				moveVector += gravityVector;
				moveVector *= Time.deltaTime;
			//	actualizar vector ( si esta agachado, disminuir velocidad )
				moveVector = _animator.GetBool ("isCrouch") ? moveVector*crouchSpeed : moveVector;
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
				if (Input.GetButton ("Agacharse")) {
					_animator.SetBool ("isCrouch", true);
				} else {
					_animator.SetBool ("isCrouch", false);
				}
					
					
	}

	void saltar(){
		if (Input.GetButton ("Saltar")) {
			verticalSpeed = jump;
		} else {
			verticalSpeed = -0.1f;
		}
	}

	void FixedUpdate(){
		
	}

	///////////////////////// RECICLAJE
	// ¿esta corriendo?
	//bool isRun =  Input.GetKey (KeyCode.LeftShift);
	//_animator.SetBool ("isRun", isRun);
}
