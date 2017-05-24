using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
	public float speedX = 10f;
	public float gravity = -10;
	private Rigidbody2D _rigidbody;
	private float VerticalSpeed;
	public float RayLenght=0.6f;
	bool PoderSaltar = false;
	// salto y movimiento horizontal
	bool pressedJump=false;
	float h;

	public float jumpForce;

	private bool isGrounded = false;

	// crear un filtro tipo Mascara, como parametro lo pasamos al final de Phishics2D.BoxCast
	// esto es necesario ya que se usa fisica 2D ( detecta su boxcast dentro de su propio collider ), en fisica 3D esto ya esta por default
	public LayerMask _mask;

	// animator
	private Animator _animator;

	// sprite rendered
	private SpriteRenderer _spriterender;

	// Use this for initialization
	void Start () {
		_rigidbody = GetComponent<Rigidbody2D> ();
		_animator = GetComponent<Animator> ();
		_spriterender = GetComponent<SpriteRenderer> ();
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


		// manipular cambio de estado -> animator
		float absH = Mathf.Abs(h); // sacamos el valor absoluto, osea siempre positivo
		_animator.SetFloat( "speed", absH );

		if ( h < 0) {
			_spriterender.flipX = true;
		} 
		if (h > 0) {
			_spriterender.flipX = false;
		} 
	}

	void FixedUpdate () {
		// FixedUpdate, usarlo mas al trabajar con Rigidbody y Physics
		// se ejecuta cade aprox 0.3s


		Vector3 moveVector = new Vector3 (0, 0, 0);
		moveVector.x = h * speedX;



		// Physics.Raycast genera un rayo invisible
		// que te devuelve true si el rayo toca algo
		// y false si el rayo no toca nada
		// bool isGrounded = Physics.Raycast (transform.position, new Vector3 (0, -1, 0), RayLenght);

		Vector3 boxSize = new Vector3 (transform.localScale.x, transform.localScale.y, transform.localScale.z) * 0.99f;
			// multiplocarlo por 0.99f, es solo para corregir efimeramente el BoxCast;


		/////////////////////////////////////////////////

		RaycastHit2D hitInfo;

		/////////////////////////////////////////////////

		Vector3 down = new Vector3(0,-1,0);
		hitInfo = Physics2D.BoxCast (transform.position, boxSize, 0, down, RayLenght, _mask.value);
		if ( hitInfo.collider != null ) {
			isGrounded = true;
		} else {
			isGrounded = false;
		}

		/////////////////////////////////////////////////

		Vector3 up = new Vector3(0,1,0);	
		bool hitUp = false;
		//hitUp = Physics.BoxCast (transform.position, boxSize/2, up, Quaternion.identity, RayLenght);
			// Quaternion.identity es lo mismo que decir rotacion (0,0,0)
		hitInfo = Physics2D.BoxCast( transform.position, boxSize, 0, up, RayLenght, _mask.value );

		if (hitInfo.collider != null) {
			hitUp = true;
		} else {
			hitUp = false;
		}

		if ( hitUp) {
			// si estoy en el piso el verticalSpeed es
			// un valor negativo pequelo... esto es para
			// asegurarno que el player toque el piso
			// y no impída movernos de lado a lado.		
			VerticalSpeed = 0f;
		}

		/////////////////////////////////////////////////

		Vector3 left = new Vector3(-1,0,0);	
		bool hitLeft = false;
		hitLeft = Physics2D.BoxCast( transform.position, boxSize, 0, left, RayLenght, _mask.value );
		/***********************/
		if (hitLeft) {
			if (h < 0) {
				moveVector.x = 0;
			}			
		}
		/***********************/

		/////////////////////////////////////////////////

		Vector3 right = new Vector3(1,0,0);	
		bool hitRight = false;
		hitRight = Physics2D.BoxCast( transform.position, boxSize, 0, right, RayLenght, _mask.value );
		/***********************/
		if (hitRight) {
			if (h > 0) {
				moveVector.x = 0;
			}			
		}
		/***********************/

		/////////////////////////////////////////////////


		// isGrounded = Physics.BoxCast (transform.position, boxSize/2, down, Quaternion.identity, RayLenght); 
			// Quaternion.identity es lo mismo que decir rotacion (0,0,0)
		//isGrounded = Physics2D.BoxCast (transform.position, boxSize, 0, down, RayLenght); 

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