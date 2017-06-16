using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
	private Rigidbody2D _rigdbody;
	public float speed = 8;
	// Use this for initialization
	void Start () {
		_rigdbody = GetComponent<Rigidbody2D> ();
		_rigdbody.velocity = transform.right * speed;// el numero rerepsenta cual rapido ira la bala
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
