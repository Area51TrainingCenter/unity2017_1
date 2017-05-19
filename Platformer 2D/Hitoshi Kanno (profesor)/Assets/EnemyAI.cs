using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {
	public float rayLength = 0.03f;
	private bool _goToTheRight;
	private Rigidbody _rigidbody;
	// Use this for initialization
	void Start () {
		_rigidbody = GetComponent<Rigidbody> ();
	}
	
	void FixedUpdate () {
		Vector3 boxSize = new Vector3 (transform.localScale.x, transform.localScale.y, transform.localScale.z);
		boxSize = boxSize * 0.99f;
		RaycastHit hitInfo;
		bool hitUp = Physics.BoxCast (transform.position, boxSize/2, Vector3.up,out hitInfo, Quaternion.identity, rayLength);

		if (hitUp) {
			if (hitInfo.collider.gameObject.CompareTag("Player")) {
				Destroy (gameObject);
			}
		}

		bool hitRight= Physics.BoxCast (transform.position, boxSize/2, Vector3.right,out hitInfo, Quaternion.identity, rayLength);

		if (hitRight) {
			if (hitInfo.collider.gameObject.CompareTag ("Player")) {
				Destroy (hitInfo.collider.gameObject);
			} else {
				_goToTheRight = !_goToTheRight;
			}
		}

		bool hitLeft = Physics.BoxCast (transform.position, boxSize/2, Vector3.left,out hitInfo, Quaternion.identity, rayLength);
		if (hitLeft) {
			if (hitInfo.collider.gameObject.CompareTag("Player")) {
				Destroy (hitInfo.collider.gameObject);
			}
			else {
				_goToTheRight = !_goToTheRight;
			}
		}

		Vector3 moveVector = new Vector3 (-5, 0, 0);
		if (_goToTheRight) {
			moveVector *= -1;
		}
		_rigidbody.velocity = moveVector;

	}
}
