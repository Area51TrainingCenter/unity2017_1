﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAI : MonoBehaviour {
	private Rigidbody2D _rigidbody;
	public float rayLength = 0.3f;
	public LayerMask _mask ;
	public float speed =  5;
	// Use this for initialization
	void Start () {
		_rigidbody = GetComponent <Rigidbody2D> ();
	}

	// Update is called once per frame
	void FixedUpdate () {

		Vector3 boxSize = new Vector3 (transform.localScale.x, transform.localScale.y, transform.localScale.z); 
		boxSize = boxSize * 0.99f;
		RaycastHit2D hitInfo;
		hitInfo = Physics2D.BoxCast(transform.position, boxSize, 0,Vector3.up, rayLength,_mask.value);
		if (hitInfo.collider != null) { 
			if(hitInfo.collider.gameObject.CompareTag("Player")) 	{
				Destroy (gameObject);
			}
		}

		hitInfo = Physics2D.BoxCast(transform.position, boxSize, 0,Vector3.left, rayLength,_mask.value);
		if (hitInfo.collider != null) { 
			Debug.Log (hitInfo.collider.name);
			if(hitInfo.collider.gameObject.CompareTag("Player")) 	{
				Destroy (hitInfo.collider.gameObject);
			} else {
				speed = speed * -1;
			}


		}
		hitInfo = Physics2D.BoxCast(transform.position, boxSize, 0,Vector3.right, rayLength,_mask.value);
		if (hitInfo.collider != null) { 
			if(hitInfo.collider.gameObject.CompareTag("Player")) 	{
				Destroy (hitInfo.collider.gameObject);
					}	
			else {
				speed = speed * -1;
			}
		}
		_rigidbody.velocity = new Vector3 (speed, 0, 0);

	}
}
