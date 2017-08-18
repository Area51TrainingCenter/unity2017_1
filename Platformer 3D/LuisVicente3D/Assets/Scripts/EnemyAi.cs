using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAi : MonoBehaviour{
	private Vida _vida;
	private Animator _animator;
	private float vidaTemporal;
	private Vector3 _impact;
	private CharacterController _controler;
	public float gravedad = 0;
	public float verticalSpeed;
	private Vector3 moveVector;
	public GameObject bola;
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
		VerticalMovement ();
		_controler.Move (moveVector);

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
				Invoke ("Destruccion", 4);
				this.enabled = false;

			} else {
				_animator.SetTrigger ("hurt");
			}
		}
	}
	void VerticalMovement(){
		if (_controler.isGrounded) {
			verticalSpeed = 0.1f;
		} else {
			verticalSpeed -= gravedad * Time.deltaTime;
		}
		Vector3 Gravedad = new Vector3 (0,verticalSpeed,0);
		moveVector += Gravedad;
	}
	void Destruccion(){
		Destroy (gameObject);
	}
	public void CrearBola(){
		Instantiate (bola, transform.position, transform.rotation);
	}
}