using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour {
	public float SpeddX = 5;
	public float Gravity = -10;
	public float rayLength = 0.6f;
	private Rigidbody _rigibody;
	private float VerticalSpeed = 0;
	// Use this for initialization
	void Start () {
		_rigibody = GetComponent <Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {

		Vector3 MoveVector = new Vector3 (0,0,0);
		Vector3 down = new Vector3 (0, -1, 0);
		float h = Input.GetAxis ("Horizontal");
		MoveVector.x = h * SpeddX;


		bool isGrounded = Physics.Raycast (transform.position,down,rayLength);
		VerticalSpeed += Gravity * Time.deltaTime;
		if (isGrounded) {
			VerticalSpeed = -0.1f;
		}

		bool Salto = Input.GetKeyDown (KeyCode.Space);
		if (Salto) {
			VerticalSpeed = 5f;
			VerticalSpeed += Gravity * Time.deltaTime;
		}
		MoveVector += new Vector3 (0, VerticalSpeed, 0);

		_rigibody.velocity = MoveVector;
		//transform.Translate (MoveVector * Time.deltaTime);
		//transform.Translate (moveX * Time.deltaTime,0,0);
	}
}
