using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {
	private Rigidbody _rigidboddy;
	public float rayLeght = 0.03f;
	public string targetTag;
	public float speedx = 5;


	// Use this for initialization
	void Start () {
		_rigidboddy = GetComponent<Rigidbody> ();
	}
	
	void FixedUpdate () {
		Vector3 boxSize = new Vector3 (transform.localScale.x, transform.localScale.y, transform.localScale.z);
		boxSize = boxSize * 0.99f;
		RaycastHit hitInfo;

		bool hitUp = Physics.BoxCast (transform.position, boxSize / 2, Vector3.up, out hitInfo, Quaternion.identity, rayLeght);
		if (hitUp) {
			if (hitInfo.collider.gameObject.CompareTag(targetTag)) {
				Destroy (gameObject);
			}
		}

		bool hitLeft = Physics.BoxCast (transform.position, boxSize / 2, Vector3.left, out hitInfo, Quaternion.identity, rayLeght);
		if (hitLeft) {
			if (hitInfo.collider.gameObject.CompareTag(targetTag)) {
				Destroy (hitInfo.collider.gameObject);
			} else {
				speedx = -speedx;
			}
		}

		bool hitRight = Physics.BoxCast (transform.position, boxSize / 2, Vector3.right, out hitInfo, Quaternion.identity, rayLeght);
		if (hitRight) {
			if (hitInfo.collider.gameObject.CompareTag(targetTag)) {
				Destroy (hitInfo.collider.gameObject);
			} else {
				speedx = -speedx;
			}
		}

		Vector3 movx = new Vector3 (0, 0, 0);
		movx.x = speedx;

		_rigidboddy.velocity = movx;

	}

}
