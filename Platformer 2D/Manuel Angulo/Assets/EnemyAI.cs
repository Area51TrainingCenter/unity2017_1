using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {
	private Rigidbody2D _rigidboddy;
	public float rayLeght = 0.03f;
	public string targetTag;
	public float speedx = 5;
	private Health _healthScript;

	public LayerMask _mask;
	// Use this for initialization
	void Start () {
		_rigidboddy = GetComponent<Rigidbody2D> ();
		_healthScript = GetComponent <Health> ();
	}
	void Update () {
		
		if (_healthScript.health<=0) {
			Destroy (gameObject);
		}
	}
	void FixedUpdate () {
		Vector3 boxSize = new Vector3 (transform.localScale.x, transform.localScale.y, transform.localScale.z);
		boxSize = boxSize * 0.99f;
		RaycastHit2D hitInfo;
		Vector3 up = new Vector3 (0, 1, 0);
		hitInfo = Physics2D.BoxCast (transform.position, boxSize, 0, up, rayLeght, _mask.value);
		if (hitInfo.collider != null) {
			if (hitInfo.collider.gameObject.CompareTag(targetTag)) {
				hitInfo.collider.GetComponent<Health> ().health -= 20;
			}
		}

		hitInfo = Physics2D.BoxCast (transform.position, boxSize, 0, Vector3.left, rayLeght, _mask.value);
		if (hitInfo.collider != null) {
			if (hitInfo.collider.gameObject.CompareTag(targetTag)) {
				hitInfo.collider.GetComponent<Health> ().health -= 20;
			} else {
				speedx = -speedx;
			}
		}

		hitInfo = Physics2D.BoxCast (transform.position, boxSize, 0, Vector3.right, rayLeght, _mask.value);
		if (hitInfo.collider != null) {
			if (hitInfo.collider.gameObject.CompareTag(targetTag)) {
				hitInfo.collider.GetComponent<Health> ().health -= 20;
			} else {
				speedx = -speedx;
			}
		}

		Vector3 movx = new Vector3 (0, 0, 0);
		movx.x = speedx;

		_rigidboddy.velocity = movx;

	}

}
