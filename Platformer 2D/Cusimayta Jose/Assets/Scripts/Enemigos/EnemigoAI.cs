using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoAI : MonoBehaviour {
	public float rayLength=0.03f;
	public float speedX = 10f;
	private Rigidbody _rigidbody;
	GameObject Player;
	int h = 1;
	// Use this for initialization
	void Start () {
		_rigidbody = GetComponent<Rigidbody> ();
		Player = GameObject.FindGameObjectWithTag ("Player");
	}
	

	void FixedUpdate () {
		Vector3 moveVector = new Vector3 (0, 0, 0);
		Vector3 boxSize = new Vector3 (transform.localScale.x, transform.localScale.y, transform.localScale.z) * 0.99f;
		RaycastHit hitinfoUP;
		RaycastHit hitinfoLEFT;
		RaycastHit hitinfoRIGHT;
		bool hitUp = Physics.BoxCast (transform.position, boxSize / 2, Vector3.up, out hitinfoUP, Quaternion.identity, rayLength);
		bool hitLeft = Physics.BoxCast (transform.position, boxSize / 2, Vector3.left, out hitinfoLEFT, Quaternion.identity, rayLength);
		bool hitRigth = Physics.BoxCast (transform.position, boxSize / 2, Vector3.right, out hitinfoRIGHT, Quaternion.identity, rayLength);
		if (hitUp) {
			if (hitinfoUP.collider.gameObject.CompareTag ("Player")) {
				Destroy (gameObject);
			}
		}
		if (hitLeft) {
			if (hitinfoLEFT.collider.gameObject.CompareTag ("Player")) {	
				Destroy (Player.gameObject);
			} else {
				h = 1;
			}
		}
		if (hitRigth) {
			if (hitinfoRIGHT.collider.gameObject.CompareTag ("Player")) {
				Destroy (Player.gameObject);
			} else {
				h = -1;
			}
		}
		moveVector.x = h * speedX;
		_rigidbody.velocity = moveVector;
	}
}