using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {
	public float gravity = 10;
	private Health _healthScript;
	private Animator _animator;
	private CharacterController _controller;
	private float previousHealth;

	private Vector3 _moveVector;
	private float _verticalSpeed;
	private Vector3 _impact;

	// Use this for initialization
	void Start () {
		_animator = GetComponent<Animator> ();
		_healthScript = GetComponent<Health> ();
		_controller = GetComponent<CharacterController> ();
		previousHealth = _healthScript.health;
	}
	
	// Update is called once per frame
	void Update () {

		ManageKnockback ();

		VerticalMovement ();

		_controller.Move (_moveVector*Time.deltaTime);


		ManageAnimatorParameters ();

		previousHealth = _healthScript.health;

	}

	void ManageKnockback(){
		_impact = Vector3.Lerp (_impact, Vector3.zero, Time.deltaTime * 3);
		if (_impact.magnitude < 2) {
			_impact = Vector3.zero;
		}
		_moveVector = _impact;
	}

	void VerticalMovement(){
		if (_controller.isGrounded) {
			_verticalSpeed = -0.1f;

		}else{
			_verticalSpeed -= gravity*Time.deltaTime;
		}


		Vector3 gravityVector = new Vector3 (0, _verticalSpeed, 0); 
		_moveVector += gravityVector;

	}



	public void AddImpact (Vector3 direction, float force){
		_impact = direction * force;
	}

	void ManageAnimatorParameters(){
		if (_healthScript.health < previousHealth) {

			if (_healthScript.health <= 0) {
				_animator.SetTrigger ("die");
				this.enabled = false;
			} else {
				_animator.SetTrigger ("hurt");
			}
		}
	}
}
