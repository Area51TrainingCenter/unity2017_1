using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {
	public float rayLength = 0.03f;
	public float speed = 5;
	private Rigidbody _rigibody;
	GameObject player;
	float h  = 0;
	// Use this for initialization
	void Start () {
		_rigibody = GetComponent<Rigidbody> ();
		player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Vector3 MoveVector = new Vector3 (0,0,0);
		Vector3 boxSize = new Vector3 (transform.localScale.x, transform.localScale.y, transform.localScale.z) * 0.99f;
		MoveVector.x = h * speed;
		RaycastHit hitInfo;
		RaycastHit hitInfo2;
		RaycastHit hitInfo3;
		bool isTocar = Physics.BoxCast (transform.position, boxSize / 2, Vector3.up, out hitInfo, Quaternion.identity, rayLength);
		if (isTocar) {
			if (hitInfo.collider.gameObject.CompareTag ("Player")) {
				Destroy (gameObject);
			}
		}
		bool isRight = Physics.BoxCast (transform.position, boxSize / 2, Vector3.right, out hitInfo2, Quaternion.identity, rayLength);
		if (isRight) {
			if (hitInfo2.collider.gameObject.CompareTag ("Player")) {
				Destroy (player.gameObject);

			}
		}
		bool isLeft = Physics.BoxCast (transform.position, boxSize / 2, Vector3.left, out hitInfo3, Quaternion.identity, rayLength);
		if (isLeft) {
			if (hitInfo3.collider.gameObject.CompareTag ("Player")) {
				Destroy (player.gameObject);
			}
		}
		_rigibody.velocity = MoveVector;
	}
}
