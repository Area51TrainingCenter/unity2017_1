using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour {
	private Rigidbody2D _rigidbody;

	// Use this for initialization
	void Start () {
		_rigidbody = GetComponent<Rigidbody2D> ();
		_rigidbody.velocity = transform.right * -5;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
