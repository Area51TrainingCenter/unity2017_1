using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
	public float speedX = 10f;
	public float gravity = -10;
	public float JumpForce=5;
	private Rigidbody _rigidbody;
	private float VerticalSpeed;
	public float RayLenght=0.01f;
	bool Jump=false;
	bool isGrounded;
	float h;
	public Camera camara;
	// Use this for initialization
	void Start () {
		_rigidbody = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update(){
		h = Input.GetAxis ("Horizontal");
		if (Input.GetKeyDown (KeyCode.Space) && isGrounded)
			Jump = true;
	}
	void FixedUpdate () {
		MovimientoLateral ();
	}

	void MovimientoLateral(){
		Vector3 moveVector = new Vector3 (0, 0, 0);
		moveVector.x = h * speedX;
		Vector3 down = new Vector3 (0, -1, 0);
		Vector3 boxSize = new Vector3 (transform.localScale.x, transform.localScale.y, transform.localScale.z)*0.99f;
		isGrounded = Physics.BoxCast (transform.position, boxSize/2, down, Quaternion.identity, RayLenght);
		if (isGrounded) {
			VerticalSpeed = -0.1f;
			if (Jump) {				
				VerticalSpeed = JumpForce;
				Jump = false;
			}
		} else {
			VerticalSpeed += gravity * Time.deltaTime;
		}
		moveVector += new Vector3 (0, VerticalSpeed);
		_rigidbody.velocity = moveVector;
	}		
	void OnDrawGizmos(){
		if (isGrounded)
			Gizmos.color = Color.green;
		else
			Gizmos.color = Color.red;	
		Vector3 boxSize = new Vector3 (transform.localScale.x, transform.localScale.y, transform.localScale.z)*0.99f;
		Gizmos.DrawWireCube (transform.position, boxSize);
		Gizmos.DrawWireCube (transform.position + new Vector3 (0, -1, 0) * RayLenght, transform.localScale);
	}
}