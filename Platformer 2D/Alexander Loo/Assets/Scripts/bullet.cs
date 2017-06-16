using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour {

	private Rigidbody2D _rigidbody;
	public float speed;

	void Start(){
		_rigidbody = GetComponent<Rigidbody2D> ();
		//transform.right para que se mueva en dirección x local...
		_rigidbody.velocity = transform.right * speed;
	}
}
