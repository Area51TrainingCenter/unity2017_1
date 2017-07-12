using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour {
	private float h1;
	private float h2;
	public float caminarAgachado=0.5f;
	public float velocidad=5f;
	public float velocidadAlterada=5f;
	private float verticalSpeed=0;
	private float acelerador=1;
	public bool agachado;
	private CharacterController personajeController;
	private Animator animacion;
	// Use this for initialization
	void Start () {
		
		personajeController = GetComponent<CharacterController> ();
		animacion= GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		
		movimiento ();
		Agacharse ();
		//correr ();
		manejarAnimacion ();

	}

	void movimiento () {
		h1=Input.GetAxis ("Horizontal");
		h2=Input.GetAxis ("Vertical");

		if (!personajeController.isGrounded) {
			
			verticalSpeed -=0.5f;
			//saltar ();
		}
		else{
			saltar ();
		}
		Vector3 gravedadVector = new Vector3(0,verticalSpeed,0);
		Vector3 moveVector = new Vector3(h1,0,h2);
		moveVector.Normalize ();
		if (agachado) {
			Debug.Log ("Estoy agachado");
			moveVector *= caminarAgachado;
		}
		else moveVector *= velocidadAlterada;

		moveVector += gravedadVector;
		moveVector *= Time.deltaTime;
		//transform.Translate (moveVector*velocidad*Time.deltaTime,Space.World);
		personajeController.Move (moveVector);
		moveVector.y = 0;
		transform.LookAt (transform.position+moveVector);

	}

	void saltar () {
		if (Input.GetButton("Jump")) {
			verticalSpeed = 15f;
		}
	}

	void Agacharse () {
		if (Input.GetButton("Agachar")) {
			
		}
//		if (Input.GetKey(KeyCode.LeftControl)) {
//			agachado = true;
//
//		} 
		else agachado = false;
	}

	void correr() {
		if (Input.GetButton("Correr")) {
			velocidadAlterada =velocidad*acelerador*Time.deltaTime*10;
			acelerador++;
		}
//		if (Input.GetKey(KeyCode.LeftShift)) {
//			velocidadAlterada =velocidad*acelerador*Time.deltaTime*10;
//			acelerador++;
//		}
		else {
			velocidadAlterada = velocidad;
			acelerador = 1;
		}
	}

	void manejarAnimacion () {
		//animacion.SetFloat ("mover",Mathf.Abs(h1));
		//primera forma
//		if (Mathf.Abs(h1)==0) {
//			animacion.SetFloat ("mover",Mathf.Abs(h2));
//		}
//		if (Mathf.Abs(h2)==0) {
//			animacion.SetFloat ("mover",Mathf.Abs(h1));
//		}
		//animacion.SetFloat ("mover",Mathf.Abs(h2));

		//segunda forma
		float end;
		if (h1 != 0 || h2 != 0) {
			//para correr
			if (Input.GetKey(KeyCode.LeftShift)) {
				end = 2;
			}
			else end = 1;
		} 
		else end = 0;

		//el valor inicial es el valor actual del parametro mover
		float start = animacion.GetFloat ("mover");
		//la funcion lerp solo calcula el numero, no hace nada con el animator
		//guardamos el resultado de lerp en una variable
	   float result = Mathf.Lerp (start,end,Time.deltaTime);

		//forma 2 para afinar salto
//		if (!personajeController.isGrounded) {
//			animacion.SetFloat ("verticalSpeed", verticalSpeed);
//		}
		//forma 1 para afinar salto
		float jumpLerp = Mathf.Lerp (0,verticalSpeed,Time.deltaTime);
		animacion.SetFloat ("verticalSpeed", jumpLerp);

		animacion.SetFloat ("mover", result);
		animacion.SetBool ("isGrounded", personajeController.isGrounded);
		animacion.SetBool("agachado", agachado);

	}


//	void FixedUpdate () {
//		movimiento ();
//		Vector3 moveVector = new Vector3(0,0,0);
//		moveVector.x = h1 * velocidad;
//		moveVector.z = h2 * velocidad;
//		rigidbody.velocity = moveVector;
//	}
}
