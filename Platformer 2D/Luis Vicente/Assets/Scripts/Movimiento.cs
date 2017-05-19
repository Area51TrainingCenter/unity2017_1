using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour {
	public float SpeddX = 5;
	public float Gravity = -10;
	public float rayLength = 0.6f;
	private Rigidbody _rigibody;
	private float VerticalSpeed = 0;
	private bool isGrounded;
	private bool isTocar;
	private bool isRight;
	private bool isLeft;
	bool Salto = false;
	float h = 0;
	// Use this for initialization
	void Start () {
		_rigibody = GetComponent <Rigidbody>();
	}
	void Update (){
		h = Input.GetAxis ("Horizontal");
		if (Input.GetKeyDown (KeyCode.Space) && isGrounded) {
			Salto = true;
		}	
	}
	// Update is called once per frame
	void FixedUpdate () {
		
		Vector3 MoveVector = new Vector3 (0,0,0);
		Vector3 down = new Vector3 (0, -1, 0);
		Vector3 up = new Vector3 (0, 1, 0);
		Vector3 right = new Vector3 (1, 0, 0);
		Vector3 left = new Vector3 (-1, 0, 0);
		MoveVector.x = h * SpeddX;


		//bool isGrounded = Physics.Raycast (transform.position,down,rayLength);
		Vector3 boxSize = new Vector3 (transform.localScale.x,transform.localScale.y,transform.localScale.z)*0.99f;
		isGrounded = Physics.BoxCast (transform.position,boxSize/2,down,Quaternion.identity,rayLength);
		isTocar = Physics.BoxCast (transform.position,boxSize/2,up,Quaternion.identity,rayLength);
		isRight = Physics.BoxCast (transform.position,boxSize/2,right,Quaternion.identity,rayLength);
		isLeft = Physics.BoxCast (transform.position,boxSize/2,left,Quaternion.identity,rayLength);

		if (isRight) {
			if (h >= 0) {
				MoveVector.x = 0;
			} 
		}
		if (isLeft) {
			if (h <= 0) {
				MoveVector.x = 0;
			} 
		}
		if (isTocar) {
			VerticalSpeed = -0.1f;
		}

		if (isGrounded) {
			VerticalSpeed = -0.1f;

			if (Salto) {
				VerticalSpeed = 7f;
				Salto = false;
			}
		}
			else {
			VerticalSpeed += Gravity * Time.deltaTime;
			}
		


		MoveVector += new Vector3 (0, VerticalSpeed, 0);

		_rigibody.velocity = MoveVector;
		//transform.Translate (MoveVector * Time.deltaTime);
		//transform.Translate (moveX * Time.deltaTime,0,0);
	}
		void OnDrawGizmos(){

			Gizmos.color = Color.red;
			Vector3 boxSize = new Vector3 (transform.localScale.x,transform.localScale.y,transform.localScale.z)*0.99f;
		if (isGrounded) {
			Gizmos.color = Color.blue;

		} 
		else {
			Gizmos.color = Color.green;
		}
			Gizmos.DrawWireCube (transform.position,boxSize);
			Vector3 down = new Vector3 (0, -1, 0);
			Gizmos.DrawWireCube (transform.position+ (down * rayLength),boxSize);
	}
}
