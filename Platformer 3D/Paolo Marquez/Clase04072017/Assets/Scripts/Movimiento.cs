using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour {
	private float h1;
	private float h2;
	public float caminarAgachado=0.5f;
	public float velocidad=5f;
	public float velocidadAlterada=5f;
	//esto sirve para que las variables publicas no aparescan en el editor
	[System.NonSerialized]
	public float verticalSpeed=0;
	private float acelerador=1;
	public bool agachado;
	private CharacterController personajeController;
	private Animator animacion;
	public LayerMask _mask;
	public GameObject Camara;
	private bool golpeAlTecho;
	public bool canControl=true;

	public Collider _weapon1;
	public Collider _weapon2;
	// Use this for initialization
	void Start () {
		Camara = GameObject.FindGameObjectWithTag ("MainCamera");
		personajeController = GetComponent<CharacterController> ();
		animacion= GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (canControl) {
			movimiento ();
			Agacharse ();
			saltar ();
		}

		//correr ();
		manejarAnimacion ();
		atacar ();

	}

	void FixedUpdate () {
		bool isCrouched=animacion.GetBool("agachado");
		if (isCrouched) {
			if (Physics.Raycast(transform.position,Vector3.up,4.0f,_mask)) {
				Debug.DrawRay(transform.position,Vector3.up*4.0f,Color.green);
				golpeAlTecho = true;
			}
			else{
				  Debug.DrawRay(transform.position,Vector3.up*4.0f,Color.red);
				golpeAlTecho = false;
			}
		}

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

		Vector3 cameraForward = Camera.main.transform.forward;
		cameraForward.Normalize ();

		Vector3 cameraRight = Camera.main.transform.right;
		cameraRight.Normalize ();

		//Vector3 moveVector = new Vector3(h1,0,h2); Camara.main
		Vector3 moveVector = h1*cameraRight+h2*cameraForward;
		moveVector.Normalize ();
		if (agachado) {
			//Debug.Log ("Estoy agachado");
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
			agachado = true;
			personajeController.height = 1;
			Vector3 newCenter = personajeController.center;
			newCenter.y = 0.45f;
			personajeController.center = newCenter;
		}

		else {
			//si estas bajo un techo, y estas agachado, no podras levantarte hasta que salgas de la zona del techo
			if (!golpeAlTecho) {
				agachado = false;
				personajeController.height = 1.8f;
				personajeController.center=new Vector3(0,0.85f,0);
			}

		} 
	}

	void atacar() {
		if (Input.GetButton("Atacar")) {
			bool isCrouched=animacion.GetBool("agachado");
			if (personajeController.isGrounded && !isCrouched && canControl) {
				//Debug.Log ("estoy atacando");
				//animacion.applyRootMotion = true;
				animacion.SetTrigger ("attack");
			}

		}
		if (Input.GetButton("Atacar2")) {
			bool isCrouched=animacion.GetBool("agachado");
			if (personajeController.isGrounded && !isCrouched && canControl) {
				//Debug.Log ("estoy atacando 2");
				//animacion.applyRootMotion = true;
				animacion.SetTrigger ("attack2");
			}

		}
		//else animacion.applyRootMotion = false;

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

	public void EnableWeaponTrail(){
		//Debug.Log("EnableWeaponTrail");
		_weapon1.GetComponentInChildren<TrailRenderer>().time=0.3f;
		//_weapon2.GetComponentInChildren<TrailRenderer>().time=0.3f;
	}
	public void EnableWeaponTrail2(){
		//Debug.Log("EnableWeaponTrail");

		_weapon2.GetComponentInChildren<TrailRenderer>().time=0.3f;
	}

	public void DisableWeaponTrail(){
		//Debug.Log("DisableWeaponTrail");
		_weapon1.GetComponentInChildren<TrailRenderer>().time=0.0f;
		//_weapon2.GetComponentInChildren<TrailRenderer>().time=0.0f;
	}
	public void DisableWeaponTrail2(){
		//Debug.Log("DisableWeaponTrail");

		_weapon2.GetComponentInChildren<TrailRenderer>().time=0.0f;
	}
//	void FixedUpdate () {
//		movimiento ();
//		Vector3 moveVector = new Vector3(0,0,0);
//		moveVector.x = h1 * velocidad;
//		moveVector.z = h2 * velocidad;
//		rigidbody.velocity = moveVector;
//	}
}
