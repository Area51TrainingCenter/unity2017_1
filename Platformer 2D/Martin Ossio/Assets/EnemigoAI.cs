using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoAI : MonoBehaviour {
	public Transform malo;
	public float speed = 5;

	public float rayLength = 0.3f;
	private Rigidbody _rigidbody;
	private Vector3 direccion;

	// Use this for initialization
	void Start () {
		_rigidbody = GetComponent<Rigidbody> ();
		malo = GameObject.FindGameObjectWithTag ("malo").GetComponent<Transform>();
		direccion = Vector3.right;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Vector3 boxSize = new Vector3 (transform.localScale.x, transform.localScale.y, transform.localScale.z);
		boxSize = boxSize * 0.99f;
		RaycastHit hitInfo;

		transform.Translate (direccion * speed * Time.deltaTime);

		bool hitUp = Physics.BoxCast (transform.position, boxSize/2, Vector3.up, out hitInfo, Quaternion.identity, rayLength);
	
		if (hitUp) {
			if (hitInfo.collider.gameObject.CompareTag("Player")) {
				Destroy (gameObject);
			}
		}


		bool hitLeft = Physics.BoxCast (transform.position, boxSize/2, Vector3.left, out hitInfo, Quaternion.identity, rayLength);

		if (hitLeft) {
			if (hitInfo.collider.gameObject.CompareTag ("Player")) {
				Destroy (hitInfo.collider.gameObject);
			} else {
				direccion = direccion * -1;
			}
		}

		bool hitRight = Physics.BoxCast (transform.position, boxSize/2, Vector3.right, out hitInfo, Quaternion.identity, rayLength);

		if (hitRight) {
			if (hitInfo.collider.gameObject.CompareTag ("Player")) {
				Destroy (hitInfo.collider.gameObject);
			} else {
				direccion = direccion * -1;
			}
		}

	}
}
