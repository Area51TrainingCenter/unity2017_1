using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
	public float speedX = 10f;
	public float gravity = -10;
	private Rigidbody _rigidbody;
	private float VerticalSpeed;
	public float RayLenght=0.6f;
	bool PoderSaltar = false;
	bool Jump=false;
	// Use this for initialization
	void Start () {
		_rigidbody = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		MovimientoLateral ();
	}

	void MovimientoLateral(){
		Vector3 moveVector = new Vector3 (0, 0, 0);
		float h = Input.GetAxis ("Horizontal");

		moveVector.x = h * speedX;

		bool isGrounded = Physics.Raycast (transform.position, new Vector3 (0, -1, 0), RayLenght);

		if (isGrounded) {
			VerticalSpeed = -0.1f;
			PoderSaltar = true;
		} else {
			VerticalSpeed += gravity * Time.deltaTime;
		}

		Jump = Input.GetKeyDown (KeyCode.Space);

		if (Jump && PoderSaltar) {
			VerticalSpeed = 5;
			VerticalSpeed -= gravity * Time.deltaTime;
			PoderSaltar = false;
		}

		moveVector += new Vector3 (0, VerticalSpeed);

		_rigidbody.velocity = moveVector;
	}		
}