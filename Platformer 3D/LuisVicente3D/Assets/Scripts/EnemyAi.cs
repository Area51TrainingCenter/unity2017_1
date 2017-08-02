using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAi : MonoBehaviour{
	public Vida _vida;
	private Animator _animator;
	private float vidaTemporal;
	private Vector3 _impact;
	private CharacterController _controler;
	// Use this for initialization
	void Start () {
		_vida = GetComponent<Vida> ();
		vidaTemporal = _vida.vida;
		_animator = GetComponent<Animator> ();
		_controler = GetComponent<CharacterController> ();
	}
	
	// Update is called once per frame
	void Update () {
		ManageKnockBack ();
		ManageAnimator ();
		vidaTemporal = _vida.vida;
	}

	void ManageKnockBack(){
		_impact = Vector3.Lerp (_impact, Vector3.zero, Time.deltaTime * 3);
		if (_impact.magnitude < 2) {
			_impact = Vector3.zero;
		}
		_controler.Move (_impact * Time.deltaTime);
	}

	public void AddImpact(Vector3 direction, float force){
		_impact = direction * force;
	}
	void ManageAnimator(){
		if (_vida.vida < vidaTemporal ) {
			if (_vida.vida <= 0) {
				_animator.SetTrigger ("Muerte");
				this.enabled = false;
			} else {
				_animator.SetTrigger ("hurt");
			}
		}
	}
}
