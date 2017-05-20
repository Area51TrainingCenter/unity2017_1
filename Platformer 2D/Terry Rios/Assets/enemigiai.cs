using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemigiai : MonoBehaviour {
	private Rigidbody _rigidbody;
	public float rayLength = 0.6f;
	private float move = -3;

	// Use this for initialization
	void Start () {

		_rigidbody = GetComponent<Rigidbody> ();
		
	}
	
	// Update is called once per frame
	void Update () {

		Vector3 boxSize = new Vector3 (transform.localScale.x, transform.localScale.y, transform.localScale.z);

		boxSize = boxSize * 0.99f;
		RaycastHit hitinfo;

		transform.Translate (move*Time.deltaTime, 0, 0);
		bool hitLM = Physics.BoxCast (transform.position, boxSize/2,Vector3.left, Quaternion.identity, rayLength);
		if (hitLM) {
			move =-move;
		}
		bool hitRM = Physics.BoxCast (transform.position, boxSize/2,Vector3.right,Quaternion.identity,rayLength);
		if (hitRM) {
			move = -3;
		}

		bool hitup = Physics.BoxCast (transform.position, boxSize/2,Vector3.up,out hitinfo, Quaternion.identity, rayLength);


		if (hitup) {
			if (hitinfo.collider.gameObject.CompareTag ("Player")) {
				Destroy (gameObject);
			}
		}

		bool hitL = Physics.BoxCast (transform.position, boxSize/2,Vector3.left,out hitinfo, Quaternion.identity, rayLength);
		if (hitL) {
			if (hitinfo.collider.gameObject.CompareTag ("Player")) {
				Destroy (hitinfo.collider.gameObject);
			}
		}
		bool hitR = Physics.BoxCast (transform.position, boxSize/2,Vector3.right,out hitinfo,Quaternion.identity,rayLength);
		if (hitR) {
			if (hitinfo.collider.gameObject.CompareTag ("Player")) {
				Destroy (hitinfo.collider.gameObject);
			}
		}





	}

}
