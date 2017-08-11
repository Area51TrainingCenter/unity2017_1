using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour {
	public float Speed = 5; // variable para la velocidad del personaje 
	[System.NonSerialized]
	public float verticalSpeed = 0; // variable para poder saltar 
	private CharacterController _controler; 
	public float gravity = 0; // variable para uso de la gravedad
	public float Correr = 0; // variable para correr
	public float CrouchSpeed = 1; // variable para la velocidad cuando estas agachado
	private Animator _animation;
	private float EjeX; // variable para los movimientos horizontales  
	private float EjeZ; // variable para los movimientos vecticales
	public float JumpForce; // variable para la fuerza del salto 
	private Vector3 moveVector; // 
	public LayerMask _layermask; 
	private bool techito; // variable para que no te puedas levantar si estas debajo de algo
	public GameObject Camara;
	public bool canControl = true;
	public Collider _weapon;
	private Vida _vida;
	private float vidaTemporal;
	private TargetingSistem _targetScript;

	void Start () {
		_targetScript = GetComponent<TargetingSistem> ();  // hacemos llamado al script de TargentingSistem
		_controler = GetComponent <CharacterController> (); // hacemos llamado el componente de character controler que tiene Ethan
		_animation = GetComponent <Animator> (); // hacemos llamado al animator de Ethan
		_vida = GetComponent<Vida> (); // hacemos el llamado al script de Vida
		vidaTemporal = _vida.vida; // Es una variable temporal para restar salud al personaje
	}
	void Update () {
			// Hacia los Costados
		EjeX = Input.GetAxis("Horizontal") ; 
			// Hacia Adelante y Atras
		EjeZ = Input.GetAxis("Vertical") ;
		if (canControl) { // El canControl si es true puede ejecutar las funciones de adentro
			MovimientoSuelo ();
			Saltar ();
			Agachar ();	
		}
		moveVector *= Time.deltaTime; // Este Vector lo multiplcamos por el Timedeltatime
		_controler.Move (moveVector );
		moveVector.y = 0; // Decimos que el Vector Y sea 0 para que no mire arriba 

		AnimatorStateInfo stateInfo = _animation.GetCurrentAnimatorStateInfo(0);
		if (!stateInfo.IsName("Base Layer.Attack1")) {
			transform.LookAt (transform.position + moveVector);
		}

		Animaciones ();
		Morir ();
		vidaTemporal = _vida.vida; 
	}
	void Morir(){

		if (_vida.vida < vidaTemporal ) { //vemos que la salud sea menor que la variable temporal de salud para segui con el chequeo
			if (_vida.vida <= 0) { // y si la vida es 0 que el canControl sea falso para no poder moverte y que salga la animacion de muerte 
				canControl = false;
				_animation.SetTrigger ("Muerte");
				this.enabled = false; // y desactivar el script 
			} else {
				_animation.SetTrigger ("hurt"); // si todavia tiene vida sale la animacion de daño 
			}
		}
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
		if (_controler.isGrounded) { // _controler.isGrounded es para fijar si el personaje esta en el piso 
			verticalSpeed = -0.1f; // ponemos el verticalSpeed a -0.1 para que pueda moverse sino no se mueve
			if (Input.GetButtonDown("Jump")) {
				verticalSpeed = JumpForce; // hacemos que el salto sea un numero de la jumpforce para la impulso del salto
			}
		} else {
			verticalSpeed -= gravity * Time.deltaTime; // sino el verticalSpeed lo restamos la gravedad y multiplicamos por Time.deltatime
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

	public void EnableWeaponTrail(){
		_weapon.GetComponentInChildren<TrailRenderer> ().time = 0.3f;
	}
	public void DisableWeaponTrail(){
		_weapon.GetComponentInChildren<TrailRenderer> ().time = 0;
	}
	public void faceTarget(){
		//transform.LookAt(transform.position + moveVector);
		if (_targetScript._target != null) {
			Vector3 objetive = _targetScript._target.transform.position;
			objetive.y = transform.position.y;
			transform.LookAt (objetive);

		}
	}
}
