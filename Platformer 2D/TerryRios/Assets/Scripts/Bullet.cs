using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
	public float speed = 10;
	private Rigidbody2D _rigidbody;
	// Use this for initialization
	void Start () {
		_rigidbody = GetComponent<Rigidbody2D> ();
		_rigidbody.velocity = transform.right*speed;
	}

	// Update is called once per frame
	void Update () {
		
	}
}
