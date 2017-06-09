﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {
	public float rayLength = 0.03f;
	public LayerMask _mask;
	private bool _goToTheRight;
	private Rigidbody2D _rigidbody;
	private health _healthscript;
	private float _previoushealth;
	private MeshRenderer _renderer;
	// Use this for initialization
	void Start () {
		_rigidbody = GetComponent<Rigidbody2D> ();
		_healthscript = GetComponent<health> ();
		_renderer = GetComponent<MeshRenderer> ();
	}
	void Update(){

		if (_healthscript.Health < _previoushealth) 
		{
			_renderer.material.color = new Color (1, 1, 1);
		} 

		Color finalcolor = Color.Lerp (_renderer.material.color, Color.red, Time.deltaTime * 10);

		_renderer.material.color = finalcolor;
			
		_previoushealth = _healthscript.Health;
		if (_healthscript.Health <= 0) {
			Destroy (gameObject);
		}


	}
	
	void FixedUpdate () {
		Vector3 boxSize = new Vector3 (transform.localScale.x, transform.localScale.y, transform.localScale.z);
		boxSize = boxSize * 0.99f;
		RaycastHit2D hitInfo;
		hitInfo = Physics2D.BoxCast (transform.position, boxSize, 0, Vector2.up, rayLength,_mask.value);

//		if (hitInfo.collider != null) {
//			if (hitInfo.collider.gameObject.CompareTag("Player")) {
//				hitInfo.collider.GetComponent<health>().ChangeHealth(20);
//			}
//		}

		hitInfo = Physics2D.BoxCast (transform.position, boxSize, 0, Vector2.right, rayLength,_mask.value);

		if (hitInfo.collider != null) {
			if (hitInfo.collider.gameObject.CompareTag ("Player")) {
//				hitInfo.collider.GetComponent<health>().ChangeHealth(20);
			} else {
				_goToTheRight = !_goToTheRight;
			}
		}

		hitInfo = Physics2D.BoxCast (transform.position, boxSize, 0, Vector2.left, rayLength,_mask.value);
		if (hitInfo.collider !=null) {
			if (hitInfo.collider.gameObject.CompareTag("Player")) {
//				hitInfo.collider.GetComponent<health>().ChangeHealth(20);
			}
			else {
				_goToTheRight = !_goToTheRight;
			}
		}

		Vector3 moveVector = new Vector3 (-5, 0, 0);
		if (_goToTheRight) {
			moveVector *= -1;
		}
		_rigidbody.velocity = moveVector;

	}
}
