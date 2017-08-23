using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RAIN.Core;

public class EnemyAI : MonoBehaviour {
	private Health _healthScript;
	private Animator _animator;
	private float previousHealth;
	private CharacterController _controller;
	[System.NonSerialized]
	public float verticalSpeed = 0;
	public GameObject _ball;
	private BoxCollider _sword;

	public float gravity = 10;
	private Vector3 moveVector;
	private Vector3 _impact;
	private AIRig _aiRig;

	// Use this for initialization
	void Start () {
		_animator = GetComponent<Animator> ();
		_healthScript = GetComponent<Health> ();
		previousHealth = _healthScript.health;
		_controller = GetComponent<CharacterController> ();
		_aiRig =GetComponentInChildren<AIRig> ();
		_sword = GetComponentInChildren<BoxCollider> ();

	}
	
	// Update is called once per frame
	void Update () {

		ManageKnockback ();

		ManageAnimatorParameters ();

		VerticalMovement ();
		moveVector *= Time.deltaTime;
		_controller.Move (moveVector);
		moveVector.y = 0;
		transform.LookAt (transform.position + moveVector);
		Hurt ();

		//esto va al ultimo
		previousHealth = _healthScript.health;

	}
	void VerticalMovement(){
		if (_controller.isGrounded) {
			verticalSpeed = -0.1f;

		}else{
			verticalSpeed -= gravity*Time.deltaTime;
		}


		Vector3 gravityVector = new Vector3 (0, verticalSpeed, 0); 
		moveVector += gravityVector;

	}

	void ManageKnockback(){

		_impact = Vector3.Lerp (_impact, Vector3.zero, Time.deltaTime * 3);
		if (_impact.magnitude < 2) {
			_impact = Vector3.zero;
			_aiRig.AI.WorkingMemory.SetItem<bool> ("IsHurt", false);
			_sword.enabled = true;
		}

		_controller.Move (_impact*Time.deltaTime);

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
	void Hurt(){
		if (_healthScript.health < previousHealth) {
			
			if (_healthScript.health <= 0) {
				_aiRig.enabled = false;
				_sword.enabled = false;
			} else {
				_aiRig.AI.WorkingMemory.SetItem<bool> ("IsHurt", true);
				_aiRig.AI.WorkingMemory.SetItem<string> ("state", "patrol");
				_sword.enabled = false;
			}
		}
	}

	public void CreateBall()  {
	//	Instantiate (_ball, transform.position, transform.rotation);
	}
		
}
