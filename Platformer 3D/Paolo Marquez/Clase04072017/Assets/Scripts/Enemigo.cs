using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour {
	public Animator _animator;
	private health salud;
	private float saludAhora;
	private Vector3 impact;
	private CharacterController enemigoControlador;
	public float verticalSpeed=5f;
	public float gravity=10f;
	public GameObject ball;
	Vector3 moveVector;
	// Use this for initialization
	void Start () {
		enemigoControlador = GetComponent<CharacterController> ();
		salud=GetComponent<health>();
		moveVector = Vector3.zero;
	}
	
	// Update is called once per frame
	void Update () {
		manageAnimatorParameters ();
		ManageKnockBack ();
		//verticarSpeed ();
		saludAhora = salud.saludActual;
	}

	void manageAnimatorParameters(){
		if (salud.saludActual<saludAhora) {
			if(salud.saludActual<=0){
				//Instantiate
				morir();
			}
			else{
				//Instantiate
				Debug.Log("Enemigo herido");
				_animator.SetTrigger("hurt");
			}
		}

	}

	void ManageKnockBack(){
		impact = Vector3.Lerp (impact, Vector3.zero, Time.deltaTime*3);
		if (impact.magnitude<2) {
			impact = Vector3.zero;
		}
		enemigoControlador.Move (impact*Time.deltaTime);
		moveVector = impact;
	}

	public void AddImpact(Vector3 direction,float force){
		impact = direction * force;
	}

	public void morir() {
		_animator.SetTrigger("morir");
		this.enabled = false;
		//Destroy(gameObject);
	}

	public void verticarSpeed(){
		if (enemigoControlador.isGrounded) {
			verticalSpeed = 0.01f;
		}else{
			verticalSpeed -= gravity * Time.deltaTime;
		}
		Vector3 direccion = new Vector3 (0,verticalSpeed,0);
		moveVector += direccion;
		moveVector*=Time.deltaTime;

	}

	public void createBall() {
		Instantiate (ball, transform.position, transform.rotation);
	}
}
