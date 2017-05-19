using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoAI : MonoBehaviour {

	private Rigidbody _rigidbody;
	public float rayLenght = 0.03f;
	public float speed;

	void Start(){

		_rigidbody = GetComponent<Rigidbody> ();
	}

	void FixedUpdate(){

		Vector3 boxSize = new Vector3 (transform.localScale.x, transform.localScale.y, transform.localScale.z);
		boxSize = boxSize * 0.99f;
		RaycastHit hitInfo;

		//Vector3.up es un atajo por default
		bool hitUp = Physics.BoxCast (transform.position, boxSize / 2, Vector3.up, out hitInfo,Quaternion.identity, rayLenght);
		if(hitUp){
			if (hitInfo.collider.CompareTag ("Player")) {
				Destroy (gameObject);
			}
		}
		bool hitLeft = Physics.BoxCast (transform.position, boxSize / 2, Vector3.left, out hitInfo, Quaternion.identity, rayLenght);
		if (hitLeft) {
			
			if (hitInfo.collider.CompareTag ("Player")) {
				Destroy (hitInfo.collider.gameObject);
			} else {
				speed = -speed;
			}
		}
		bool hitRight = Physics.BoxCast (transform.position, boxSize / 2, Vector3.right, out hitInfo, Quaternion.identity, rayLenght);
		if (hitRight) {
			
			if (hitInfo.collider.CompareTag ("Player")) {
				Destroy (hitInfo.collider.gameObject);
			} else {
				speed = -speed;
			}
		}
		_rigidbody.velocity = new Vector3 (speed, 0, 0);
	}
}
