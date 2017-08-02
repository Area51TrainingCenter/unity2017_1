using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	private Health health;
	private Animator _animator;
	private CharacterController _controller;

	public GameObject enemyWeapon;

	private float previousHealth;
	private Vector3 _impact;

	void Start(){

		health = GetComponent<Health> ();
		_animator = GetComponent<Animator> ();
		_controller = GetComponent<CharacterController> ();
		previousHealth = health.health;
	}

	void Update(){

		ManageKnockback ();
		ManageAnimator ();
		previousHealth = health.health;
	}

	void ManageAnimator(){

		if (health.health <= 0) {
			_animator.SetTrigger ("isDead");
			//'this' hace referencia a este script (desactivamos el script para que no baile)
			this.enabled = false;

			//para que suelte el arma cuando muera
			//transform.parent es la posicion del padre, al volverlo nulo lo sacamos del padre
			enemyWeapon.transform.parent = null;
			enemyWeapon.GetComponent<Collider> ().isTrigger = false;
			enemyWeapon.GetComponent<Rigidbody> ().isKinematic = false;
		}
		else if (health.health < previousHealth) {
			_animator.SetTrigger ("hurt");
		}
	}

	void ManageKnockback(){

		_impact = Vector3.Lerp (_impact, Vector3.zero, Time.deltaTime * 3);
		if (_impact.magnitude < 2) {
			_impact = Vector3.zero;
		}
		_controller.Move (_impact * Time.deltaTime);
	}

	public void AddImpact(Vector3 direction, float force){

		_impact = direction * force;
	}
}
