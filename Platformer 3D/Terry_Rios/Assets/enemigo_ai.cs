using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemigo_ai : MonoBehaviour {

	private health _scripthealth;
	private Animator _Animations;
	private float _previoushealth;
	private Vector3 _impact;
	private CharacterController _charactercontroler;

	// Use this for initialization
	void Start () {

		_scripthealth = GetComponent<health> ();
		_Animations = GetComponent<Animator> ();
		_charactercontroler = GetComponent<CharacterController> ();
		_previoushealth = _scripthealth._health;

	}

	// Update is called once per frame
	void Update(){

		ManageAnimatorParameters ();

		ManageKnockback ();

		_previoushealth = _scripthealth._health;



	}

	void ManageKnockback(){

		_impact = Vector3.Lerp (_impact, Vector3.zero, Time.deltaTime * 3);
			if(_impact.magnitude<2){
				_impact = Vector3.zero;
			}
		_charactercontroler.Move (_impact*Time.deltaTime);
				
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
