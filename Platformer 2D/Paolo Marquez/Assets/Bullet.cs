﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
	private Rigidbody2D _rigidBody;
	public float velocidad;

	// Use this for initialization
	void Start () {
		_rigidBody = GetComponent<Rigidbody2D> ();
		_rigidBody.velocity = -transform.up*velocidad;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
