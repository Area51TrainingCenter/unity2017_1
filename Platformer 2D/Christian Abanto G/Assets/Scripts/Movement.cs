using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
	public float speedX = 10f;
	public float gravity = -10;
	private Rigidbody _rigidbody;
	private float VerticalSpeed;
	public float RayLenght=0.6f;
	bool PoderSaltar = false;
	// salto y movimiento horizontal
	bool pressedJump=false;
	float h;

	public float jumpForce;

	private bool isGrounded;
	private bool tocaTecho;
	private bool tocaParedIzq;

	// Use this for initialization
	void Start () {
		_rigidbody = GetComponent<Rigidbody> ();
	}

	void Update(){
		// update, usarlo mas para capturar entradas de input
		// se ejecuta cada frame

		h = Input.GetAxis ("Horizontal");
		if ( Input.GetKeyDown (KeyCode.Space) && isGrounded ){
			// si detecta entrada de input, le asignamos true permanentemente
			pressedJump = true; 
			// luego en FixedUpdate aplicamos el salto y resetamos ( ir a code: $RESET pressedJump)
		}
	}

	void FixedUpdate () {
		// FixedUpdate, usarlo mas al trabajar con Rigidbody y Physics
		// se ejecuta cade aprox 0.3s


		Vector3 moveVector = new Vector3 (0, 0, 0);

		moveVector.x = h * speedX;

		Vector3 down = new Vector3(0,-1,0);
		Vector3 up = new Vector3(0,1,0);
		Vector3 left = new Vector3(-1,0,0);

		// Physics.Raycast genera un rayo invisible
		// que te devuelve true si el rayo toca algo
		// y false si el rayo no toca nada
		// bool isGrounded = Physics.Raycast (transform.position, new Vector3 (0, -1, 0), RayLenght);


		Vector3 boxSize = new Vector3 (transform.localScale.x, transform.localScale.y, transform.localScale.z) * 0.99f;
			// multiplocarlo por 0.99f, es solo para corregir efimeramente el BoxCast;
			
		tocaTecho = Physics.BoxCast (transform.position, boxSize/2, up, Quaternion.identity, RayLenght);
			// Quaternion.identity es lo mismo que decir rotacion (0,0,0)

		if (tocaTecho) {
			// si estoy en el piso el verticalSpeed es
			// un valor negativo pequelo... esto es para
			// asegurarno que el player toque el piso
			// y no impída movernos de lado a lado.		
			VerticalSpeed = 0f;
		} 

		isGrounded = Physics.BoxCast (transform.position, boxSize/2, down, Quaternion.identity, RayLenght); 
			// Quaternion.identity es lo mismo que decir rotacion (0,0,0)

		if (isGrounded) {
			// si estoy en el piso el verticalSpeed es
			// un valor negativo pequelo... esto es para
			// asegurarno que el player toque el piso
			// y no impída movernos de lado a lado.

		
			VerticalSpeed = -0.1f;	

			if (pressedJump) {
				VerticalSpeed = jumpForce;
				// $RESET pressedJump 
				// una vez completado el salto lo resetamos
				pressedJump = false;

			}
		} else {
			// la gravedad se va aplicando al verticalSpeed
			VerticalSpeed += gravity * Time.deltaTime;
		}


		tocaParedIzq = Physics.BoxCast (transform.position, boxSize/2, left, Quaternion.identity, RayLenght);

		if (tocaParedIzq) {
			if ( h < 0  ){
				moveVector.x = 0;
			}
		}
			


		moveVector += new Vector3 (0, VerticalSpeed);





		// en lugar de pasarle los 3 numero por separado
		// le pasamo a la funcion Transale el Vector3
		// cuando multiplicas un numero por un Vector3
		// Multiplicas el X,Y,Z por ese numero
		_rigidbody.velocity = moveVector;
	}		

	void OnDrawGizmos(){
		// OnDrawGizmos, solo es una guia ( no hace el checko de la fisica ), lo hace el update
		
		Vector3 boxSize = new Vector3 (transform.localScale.x, transform.localScale.y, transform.localScale.z)*0.99f;

		if (isGrounded) {
			Gizmos.color = Color.red; // pinta si esta tocando piso
		} else {
			Gizmos.color = Color.cyan; // pinta si esta en el aire
		}

		Gizmos.DrawWireCube (transform.position, boxSize); // dibuja el borde la caja

		Vector3 down = new Vector3(0,-1,0);
		Vector3 posDown = transform.position + down * RayLenght;
		Gizmos.DrawWireCube(posDown, boxSize);

		Vector3 up = new Vector3(0,-1,0);
		Vector3 posUp = transform.position + down * RayLenght;
		Gizmos.DrawWireCube(posDown, boxSize);
	}
}