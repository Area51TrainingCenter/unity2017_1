﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {

	private Rigidbody2D _rigibody;
	public float speed;

	public float raylength = 0.6f;
	private bool _goToTheRight;
	private Health _healthScript;

	public LayerMask _mask;

	// Use this for initialization

	void Start () {
		_rigibody = GetComponent<Rigidbody2D> ();		
		_healthScript = GetComponent<Health> ();
	}


	void Update(){
		
		// Destruir al enemigo
		if (_healthScript.health <= 0) {
			Destroy (gameObject);
		}

	}

	// Update is called once per frame
	void FixedUpdate () {
		
		Vector3 boxSize = new Vector3 (transform.localScale.x, transform.localScale.y,transform.localScale.z);// tamaño de la caja

		boxSize = boxSize * 0.99f;
		RaycastHit2D hitinfo;

		 hitinfo = Physics2D.BoxCast(transform.position,boxSize,0,Vector3.up,raylength,_mask.value);  

		if(hitinfo.collider != null){			
			if (hitinfo.collider.gameObject.CompareTag("Player")) {				
				hitinfo.collider.GetComponent<Health>().health -= 20;
			}
		}

	
		hitinfo = Physics2D.BoxCast(transform.position,boxSize,0,Vector3.left,raylength,_mask.value);  
		if(hitinfo.collider != null ){

			if (hitinfo.collider.gameObject.CompareTag("Player")) {
				//Destroy(hitinfo.collider.gameObject);
				hitinfo.collider.GetComponent<Health>().health -= 20;
			} else {
				speed = -speed;
			}
		}

		hitinfo =  Physics2D.BoxCast(transform.position,boxSize,0,Vector3.right,raylength,_mask.value);
		if(hitinfo.collider != null ){
				
		
			if (hitinfo.collider.gameObject.CompareTag("Player")) {
				//Destroy(hitinfo.collider.gameObject);
				hitinfo.collider.GetComponent<Health>().health -= 20;
			}else {
				speed = -speed;
			}
		}


		_rigibody.velocity = new Vector3 (speed, 0, 0);


	}



}
