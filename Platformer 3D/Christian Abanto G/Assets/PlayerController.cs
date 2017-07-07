using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	public float speed = 5f;
	private CharacterController _controller;
	private float gravityVector;
	public float gravity;
	public float jump = 10;

	// Use this for initialization
	void Start () {
		_controller = GetComponent<CharacterController> ();
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
				if (_controller.isGrounded) 
				{ gravityVector = -0.1f; }
				else
				{ gravityVector -= gravity * Time.deltaTime; }
				Vector3 verticalVector = new Vector3 (0, gravityVector , 0);
			//  normalizar movimiento ( para que siempre sea 1 la direccion )
				moveVector.Normalize (); 
			//  actualizar vector ( usando la velocidad y gravedad )
				moveVector *= speed;
				moveVector += verticalVector;
				moveVector *= Time.deltaTime;
			//  aplicar direccion de movimiento
				//transform.Translate(moveVector, Space.World);
				_controller.Move (moveVector); // similar a translate, la diferencia es que colisiona ( se detiene si hay un bloque )
			//  reestablecer Y				
				moveVector.y = 0; // ( gravedad no debe aplicarle )
				float ejeY = 0;
				if (Input.GetKeyDown (KeyCode.Space)) {
					moveVector.y = jump;
				}
		//  ROTAR
			// rotara en base a su direccion de movimiento ( moveVector )
			transform.LookAt( transform.position + moveVector );
	}
}
