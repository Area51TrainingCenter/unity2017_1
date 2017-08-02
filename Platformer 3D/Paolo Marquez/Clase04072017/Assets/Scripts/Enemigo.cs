using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour {
	public Animator _animator;
	private health salud;
	private float saludAhora;
	private Vector3 impact;
	// Use this for initialization
	void Start () {
		salud=GetComponent<health>();
	}
	
	// Update is called once per frame
	void Update () {
		manageAnimatorParameters ();
		ManageKnockBack ();
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
		GetComponent<CharacterController> ().Move (impact*Time.deltaTime);
	}

	public void AddImpact(Vector3 direction,float force){
		impact = direction * force;
	}

	public void morir() {
		_animator.SetTrigger("morir");
		this.enabled = false;
		//Destroy(gameObject);
	}
}
