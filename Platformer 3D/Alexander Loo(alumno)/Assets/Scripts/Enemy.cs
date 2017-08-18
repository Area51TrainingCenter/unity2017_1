using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {

	private Health health;
	private Animator _animator;
	private CharacterController _controller;

	public GameObject enemyWeapon;
	public Text finishHimText;

	private float previousHealth;
	private Vector3 _impact;
	private Vector3 movement;
	private float verticalSpeed;

	public float gravity;

	public GameObject _ball;

	void Start(){

		health = GetComponent<Health> ();
		_animator = GetComponent<Animator> ();
		_controller = GetComponent<CharacterController> ();
		previousHealth = health.health;
	}

	void Update(){

		VerticalMovement ();
		ManageKnockback ();
		FinishHim ();
		ManageAnimator ();
		previousHealth = health.health;

		movement *= Time.deltaTime;
		_controller.Move (movement);
	}

	void VerticalMovement(){

		if (_controller.isGrounded) {
			verticalSpeed = -0.1f;
		} else {
			verticalSpeed -= gravity * Time.deltaTime;
		}
		movement = new Vector3 (0, verticalSpeed, 0);
	}

	void ManageAnimator(){

		if (health.health <= 0) {
			
			finishHimText.enabled = false;
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
		movement += _impact;
	}

	public void AddImpact(Vector3 direction, float force){

		_impact = direction * force;
	}

	void FinishHim(){

		if (health.health <= 20) {
			finishHimText.enabled = true;
		}
	}

	public void CreateBall(){
		
		Instantiate (_ball, transform.position, transform.rotation);
	}
}
