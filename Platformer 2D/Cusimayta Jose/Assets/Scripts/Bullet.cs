using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
	public float velocidad;
	private Rigidbody2D _rigidBody2D;
	// Use this for initialization
	void Start () {
		_rigidBody2D = GetComponent<Rigidbody2D> ();
		_rigidBody2D.velocity = transform.right*-velocidad;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
