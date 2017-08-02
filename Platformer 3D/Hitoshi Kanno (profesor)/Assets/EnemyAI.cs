using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {
	private Health _healthScript;
	private Animator _animator;
	private float previousHealth;

	private Vector3 _impact;

	// Use this for initialization
	void Start () {
		_animator = GetComponent<Animator> ();
		_healthScript = GetComponent<Health> ();
		previousHealth = _healthScript.health;
	}
	
	// Update is called once per frame
	void Update () {

		ManageKnockback ();

		ManageAnimatorParameters ();


		previousHealth = _healthScript.health;

	}

	void ManageKnockback(){

		_impact = Vector3.Lerp (_impact, Vector3.zero, Time.deltaTime * 3);
		if (_impact.magnitude < 2) {
			_impact = Vector3.zero;
		}

		GetComponent<CharacterController> ().Move (_impact*Time.deltaTime);
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
