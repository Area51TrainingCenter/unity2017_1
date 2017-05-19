using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoAI : MonoBehaviour {

	private Rigidbody _rigidbody;
	public float RayLenght=1f;
	private float speedX = 0.01f; 

	// Use this for initialization
	void Start () {
		_rigidbody = GetComponent<Rigidbody> ();
	}

	void Update(){
		transform.Translate (speedX = 1, 0, 0);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Vector3 boxSize = new Vector3 (transform.localScale.x, transform.localScale.y, transform.localScale.z) * 0.99f;
		boxSize *= 0.99f;

		RaycastHit hitInfo; // este obtiene un detalle del objeto

		// COLISION POR ARRIBA
		bool hitUp = Physics.BoxCast (transform.position, boxSize/2, Vector3.up, out hitInfo, Quaternion.identity, RayLenght);
		// evaluamos si toco por arriba
		if (hitUp) {
			// verificamos si la colision fue realizada con el player
			if (hitInfo.collider.gameObject.CompareTag ("Player")) {
				Destroy (gameObject);
			}
		}
		// COLISION POR DERECHA
		bool hitRight = Physics.BoxCast (transform.position, boxSize/2, Vector3.right, out hitInfo, Quaternion.identity, RayLenght);
		// evaluamos si toco por arriba
		if ( hitRight ) {
			// verificamos si la colision fue realizada con el player
			if (hitInfo.collider.gameObject.CompareTag ("Player")) {
				Destroy (hitInfo.collider.gameObject);
			}


		}
		// COLISION POR IZQUIERDA
		bool hitLeft = Physics.BoxCast (transform.position, boxSize/2, Vector3.left, out hitInfo, Quaternion.identity, RayLenght);
		// evaluamos si toco por arriba
		if ( hitLeft ) {
			// verificamos si la colision fue realizada con el player
			if (hitInfo.collider.gameObject.CompareTag ("Player")) {
				Destroy (hitInfo.collider.gameObject);
			}
		}


		///////////////////////////////////////////////
		/// no va
		bool paredLeft = Physics.BoxCast (transform.position, boxSize/2, Vector3.left, out hitInfo, Quaternion.identity, RayLenght);

		if (paredLeft && !hitInfo.collider.gameObject.CompareTag ("Player")) {
			speedX = -speedX;
		}

		bool paredRight = Physics.BoxCast (transform.position, boxSize/2, Vector3.right, out hitInfo, Quaternion.identity, RayLenght);

		if (paredRight && !hitInfo.collider.gameObject.CompareTag ("Player")) {
			speedX = speedX;
		}


	}
}
