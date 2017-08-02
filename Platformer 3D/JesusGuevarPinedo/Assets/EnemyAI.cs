using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {

	private Health _health;
	private Animator _animator;
	private float _vidaActual;

	private Vector3 _impact;

	void Start () {
		_health = GetComponent<Health> ();
		_animator = GetComponent<Animator> ();
	}
	

	void Update () {


		ManageAnimatorParameters ();
		ManageKnockback ();
		_vidaActual = _health.health;

	}

	void ManageKnockback(){

		_impact = Vector3.Lerp (_impact, Vector3.zero, Time.deltaTime*3);
		if (_impact.magnitude < 2) {
			_impact = Vector3.zero;
		}
		GetComponent<CharacterController> ().Move (_impact*Time.deltaTime);
	}

	public void AddImpact(Vector3 direction,float force ){
		_impact = direction * force;
	}


	void ManageAnimatorParameters(){
	
		if(_health.health < _vidaActual && _health.health>0){
			_animator.SetTrigger ("isHurt");						
		}else if (_health.health == 0) {
			_animator.SetTrigger ("isDie");
			this.enabled = false;

		}

	}



}
