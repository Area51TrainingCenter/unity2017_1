using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {
	public float rayLength = 0.03f;
	public float speed = 5;
	private Rigidbody2D _rigibody;
	GameObject player;
	float h  = 0;
	public LayerMask Mascara;
	// Use this for initialization
	void Start () {
		_rigibody = GetComponent<Rigidbody2D> ();
		player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Vector3 MoveVector = new Vector3 (0,0,0);
		Vector3 boxSize = new Vector3 (transform.localScale.x, transform.localScale.y, transform.localScale.z) * 0.99f;
		MoveVector.x = h * speed;
		RaycastHit2D hitInfo;
		RaycastHit2D hitInfo2;
		RaycastHit2D hitInfo3;

		 
		hitInfo = Physics2D.BoxCast (transform.position, boxSize, 0, Vector3.up, rayLength, Mascara.value);
		if (hitInfo.collider != null) {
			if (hitInfo.collider.gameObject.CompareTag ("Player")) {
				Destroy (player.gameObject);
			}
		}
		hitInfo2 = Physics2D.BoxCast (transform.position, boxSize, 0, Vector3.right, rayLength, Mascara.value);
		if (hitInfo.collider != null) {
			if (hitInfo2.collider.gameObject.CompareTag ("Player")) {
				Destroy (player.gameObject);

			}
		}
		hitInfo3 = Physics2D.BoxCast (transform.position, boxSize, 0, Vector3.left, rayLength, Mascara.value);
		if (hitInfo3.collider != null) {
			if (hitInfo3.collider.gameObject.CompareTag ("Player")) {
				Destroy (player.gameObject);
			}
		}
		_rigibody.velocity = MoveVector;
	}
}
