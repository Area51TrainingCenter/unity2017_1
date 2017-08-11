using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemigo_ai : MonoBehaviour {

	private health _scripthealth;
	private float gravity = 10;
	private Animator _Animations;
	private float _previoushealth;
	private Vector3 _impact;
	private CharacterController _charactercontroler;
	private float _verticalspeed;
	private Vector3 _moveVector;

	// Use this for initialization
	void Start () {

		_scripthealth = GetComponent<health> ();
		_Animations = GetComponent<Animator> ();
		_charactercontroler = GetComponent<CharacterController> ();
		_previoushealth = _scripthealth._health;

	}

	// Update is called once per frame
	void Update(){

		VerticalMovement ();

		ManageKnockback ();

		_charactercontroler.Move (_moveVector*Time.deltaTime);

		ManageAnimatorParameters ();

		_previoushealth = _scripthealth._health;

	}
		
	void ManageKnockback(){

		_impact = Vector3.Lerp (_impact, Vector3.zero, Time.deltaTime * 3);
			if(_impact.magnitude<2){
				_impact = Vector3.zero;
			}

		_moveVector += _impact;		
	}

	void VerticalMovement (){

		if (_charactercontroler.isGrounded) {

			_verticalspeed = -0.1f;
		} else {

			_verticalspeed = gravity * Time.deltaTime;

		}

		Vector3 gravityVector = new Vector3 (0, _verticalspeed, 0); 
		_moveVector = gravityVector;

	}

	public void AddImpact(Vector3 direction,float force){

		_impact = direction * force;

	}

	void ManageAnimatorParameters(){

		if (_scripthealth._health < _previoushealth) {

			if (_scripthealth._health <= 0) {

				_Animations.SetTrigger ("health");
				this.enabled = false;

			} else {
				_Animations.SetTrigger ("hurt");

			}
				
		}

	}
		
}
