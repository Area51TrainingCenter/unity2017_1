using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAi : MonoBehaviour {
	public Vida _vida;
	private Animator _animator;
	private float _vidaTemporal;

	private Vector3 _impact;

	private CharacterController _controller;

	// Use this for initialization
	void Start () {
		_vida = GetComponent<Vida> ();
		_vidaTemporal = _vida.vida;
		_animator = GetComponent<Animator>();
		_controller = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {

		ManageAnimations();

		_vidaTemporal = _vida.vida;

		ManageKnockBack();
	}

	void ManageKnockBack() {
		_impact = Vector3.Lerp(_impact, Vector3.zero, Time.deltaTime * 3 );

		if ( _impact.magnitude == 2 ) {
			_impact = Vector3.zero;
		}

		_controller.Move(_impact * Time.deltaTime);
	}

	public void AddImpact( Vector3 direction, float force ) {
		_impact = direction * force;
	}

	void ManageAnimations() {
		if (_vida.vida < _vidaTemporal  ) {			
			if (_vida.vida <= 0) {			
				//Destroy (gameObject);
				_animator.SetTrigger("isDead");
				this.enabled =false;
			} else {
				_animator.SetTrigger("isHurt");
			}
		}
	}

}
