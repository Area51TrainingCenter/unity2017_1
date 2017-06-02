using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoAI : MonoBehaviour {

	private Rigidbody2D _rigidbody;
	public float rayLenght = 0.03f;
	public float speed;
	public LayerMask _mask;
	private Health health;

	void Start(){

		_rigidbody = GetComponent<Rigidbody2D> ();
		health = GetComponent<Health> ();
	}

	void Update(){

		if (health.health <= 0) {

			Destroy (gameObject);
		}
	}

	void FixedUpdate(){

		Vector3 boxSize = new Vector3 (transform.localScale.x, transform.localScale.y, transform.localScale.z);
		boxSize = boxSize * 0.99f;
		RaycastHit2D hitInfo;

		//Vector3.up es un atajo por default
		hitInfo = Physics2D.BoxCast(transform.position, boxSize, 0, Vector3.up, rayLenght,_mask.value);
		if(hitInfo.collider != null){
			if (hitInfo.collider.CompareTag ("Player")) {
				hitInfo.collider.GetComponent<Health> ().health -= 20;
			}
		}
		hitInfo = Physics2D.BoxCast(transform.position, boxSize, 0, Vector3.left, rayLenght,_mask.value);
		if (hitInfo.collider != null) {
			
			if (hitInfo.collider.CompareTag ("Player")) {
				hitInfo.collider.GetComponent<Health> ().health -= 20;

			} else {
				speed = -speed;
			}
		}
		hitInfo = Physics2D.BoxCast(transform.position, boxSize, 0, Vector3.right, rayLenght,_mask.value);
		if (hitInfo.collider != null) {
			
			if (hitInfo.collider.CompareTag ("Player")) {
				hitInfo.collider.GetComponent<Health> ().health -= 20;

			} else {
				speed = -speed;
			}
		}
		_rigidbody.velocity = new Vector3 (speed, 0, 0);
	}
}
