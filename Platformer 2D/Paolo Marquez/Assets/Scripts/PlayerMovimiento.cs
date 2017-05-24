using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovimiento : MonoBehaviour {
	public float speedX = 0.1f;
	public float gravity = -20;
	//private Rigidbody _rigidbody;
	private Rigidbody2D _rigidbody;
	private Animator _animator;
	private SpriteRenderer _spriteRenderer;
	//los float por defecto valen cero
	private float verticalSpeed;
	public float rayLenght=0.6f;
	public bool isGrounded=false;
	public bool isTecho=false;
	public bool isIzq=false;
	public bool isDer=false;
	public float salto=10f;
	public bool jump;
	public float h;
	public LayerMask _mask;
	//public bool repulsion=false;

	// Use this for initialization
	void Start () {
		_rigidbody = GetComponent<Rigidbody2D> ();
		_animator = GetComponent<Animator> ();
		_spriteRenderer = GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		
		AjustesMovimientos ();

		//le pasamos el valor absoluto de h
		float absH = Mathf.Abs (h);
		_animator.SetFloat ("speed",absH);
		//Debug.Log ("deltatime=" + Time.deltaTime);
	}

	void FixedUpdate(){
		Movimiento ();
	}	

	void AjustesMovimientos(){
		h=Input.GetAxis("Horizontal");
		//jump = Input.GetKeyDown (KeyCode.Space);
		if (Input.GetKeyDown (KeyCode.Space) && isGrounded) {
			jump = true;
		}
		if(h<0){
			_spriteRenderer.flipX = true;
		}
		if(h>0){
			_spriteRenderer.flipX = false;
		}
	}
	void Movimiento()
	{
		Vector3 moveVector =new Vector3(0,0,0);

		//movimiento WASD

		//float j=Input.GetAxis("Vertical");
		//h se multiplica por la velocidad dada
		//if(repulsion==false){
		moveVector.x = h * speedX;	
		//}
		RaycastHit2D hitInfo;

		Vector3 down = new Vector3 (0, -1, 0);
		Vector3 up = new Vector3 (0, 1, 0);
		Vector3 izq = new Vector3 (-1, 0, 0);
		Vector3 der = new Vector3 (1, 0, 0);
		//raycast genera un rayo invisble que te devuelve true si choca al algun suelo o false si no toca nada
		//bool isGrounded=Physics.Raycast (transform.position, down, rayLenght);

		Vector3 boxSize = new Vector3 (transform.localScale.x,transform.localScale.y,transform.localScale.z);
		boxSize *= 0.99f;

		//suelo
		//isGrounded=Physics.BoxCast (transform.position, boxSize/2, down, Quaternion.identity,rayLenght);
		hitInfo=Physics2D.BoxCast (transform.position, boxSize, 0, down, rayLenght,_mask.value);
		if(hitInfo.collider==null){
			isGrounded = false;
		}
		else{
			isGrounded = true;
		}

		if(isGrounded){
						//si estoy en el piso el vertical speed es un valor negativo pequeño, para que el jugador toque el piso
						verticalSpeed = -0.1f;
			
						if(jump){
							verticalSpeed = salto;
							jump = false;
				        }
						//repulsion=false;
				
					else{
						//la gravedad se va aplicando al verticalSpeed
				       
						verticalSpeed += gravity*Time.deltaTime;
					}
	     }
		if(isGrounded==false){ 
			verticalSpeed += gravity*Time.deltaTime;
		}
			

		//techo
		hitInfo=Physics2D.BoxCast (transform.position, boxSize, 0, up, rayLenght,_mask.value);
		if(hitInfo.collider==null){
			isTecho = false;
			//verticalSpeed = -10;
		}
		if(hitInfo.collider!=null){
			isTecho = true;
        }

		if(isTecho ){
			//verticalSpeed = -1;
			verticalSpeed = -10;
		}

		//derecha
		hitInfo=Physics2D.BoxCast (transform.position, boxSize, 0, der, rayLenght,_mask.value);
		if(hitInfo.collider==null){
			isDer = false;
		}
		else{
			isDer = true;
		}



		//izquierda
		hitInfo=Physics2D.BoxCast (transform.position, boxSize, 0, izq, rayLenght,_mask.value);
		if(hitInfo.collider==null){
			isIzq = false;
		}
		else{
			isIzq = true;
		}

		if((isIzq || isDer) && isGrounded==false){
	
				if(h!=0){
					Debug.Log("Choque con pared izq o der");
					moveVector.x = 0;
					
					//moveVector.x = 100;
					//verticalSpeed = -10;
					//verticalSpeed += gravity*Time.deltaTime;
					//moveVector += new Vector3 (100, -verticalSpeed, 0);
					//repulsion=true;
				}
	
			}

//		isTecho=Physics.BoxCast (transform.position, boxSize/2, up, Quaternion.identity,rayLenght);
//		isIzq=Physics.BoxCast (transform.position, boxSize/2, izq, Quaternion.identity,rayLenght);
//		isDer=Physics.BoxCast (transform.position, boxSize/2, der, Quaternion.identity,rayLenght);
//
//		if((isIzq || isDer) && isGrounded==false){
//
//			if(h!=0){
//				Debug.Log("Choque con pared izq o der");
//				moveVector.x = 0;
//				
//				//moveVector.x = 100;
//				//verticalSpeed = -10;
//				//verticalSpeed += gravity*Time.deltaTime;
//				//moveVector += new Vector3 (100, -verticalSpeed, 0);
//				//repulsion=true;
//			}
//
//		}
//
//		if(isTecho){
//			verticalSpeed = -10;
//		}
//		if(isGrounded==true){
//			//si estoy en el piso el vertical speed es un valor negativo pequeño, para que el jugador toque el piso
//			verticalSpeed = -0.1f;
//
//			if(jump){
//				verticalSpeed = salto;
//				jump = false;
//			}
//			//repulsion=false;
//		}
//		else{
//			//la gravedad se va aplicando al verticalSpeed
//			verticalSpeed += gravity*Time.deltaTime;
//		}
//
		//verticalSpeed += gravity*Time.deltaTime;
		moveVector += new Vector3 (0, verticalSpeed, 0);

		Debug.Log("moveVector="+moveVector);
		_rigidbody.velocity=moveVector;
		//transform.Translate(moveVector*Time.deltaTime);
	}

	void OnTriggerEnter(Collider other){
		Debug.Log ("Colisione");
		if(other.CompareTag("enemigo")){
			Destroy (gameObject);
			Destroy (other.gameObject);
		}	
	}

	void OnDrawGizmos(){
		
		if(isGrounded){
			Gizmos.color = Color.red;
		}
		else {
			Gizmos.color = Color.blue;
		}

		Vector3 boxSize = new Vector3 (transform.localScale.x,transform.localScale.y,transform.localScale.z);
		boxSize *= 0.99f;
		Gizmos.DrawWireCube (transform.position,boxSize);

		Vector3 down = new Vector3 (0, -1, 0);
		Vector3 pos=transform.position +(down * rayLenght);

		Gizmos.DrawWireCube (pos,boxSize);
	}
}
