using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoAI : MonoBehaviour {

	private Rigidbody2D _rigidbody;
	public float RayLenght=1f;
	private float speedX = 0.01f; 

	public LayerMask _layerMask;

	// Use this for initialization
	void Start () {
		_rigidbody = GetComponent<Rigidbody2D> ();
	}

	void Update(){
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
		Vector3 boxSize = new Vector3 (transform.localScale.x, transform.localScale.y, transform.localScale.z) * 0.99f;
		boxSize *= 0.99f;

		RaycastHit2D hitInfo; // este obtiene un detalle del objeto

		// COLISION POR ARRIBA
		hitInfo = Physics2D.BoxCast (transform.position, boxSize, 0, Vector3.up, RayLenght, _layerMask.value);
		// evaluamos si toco por arriba
		if (hitInfo.collider != null) {
			// verificamos si la colision fue realizada con el player
			if (hitInfo.collider.gameObject.CompareTag ("Player")) {
				//Destroy (gameObject);
				Destroy (hitInfo.collider.gameObject);
			}
		}
		// COLISION POR DERECHA
		hitInfo = Physics2D.BoxCast (transform.position, boxSize, 0, Vector3.right, RayLenght, _layerMask.value);
		// evaluamos si toco por arriba
		if ( hitInfo.collider != null ) {
			// verificamos si la colision fue realizada con el player
			if (hitInfo.collider.gameObject.CompareTag ("Player")) {
				Destroy (hitInfo.collider.gameObject);
			}

		}
		// COLISION POR IZQUIERDA
		hitInfo = Physics2D.BoxCast (transform.position, boxSize, 0, Vector3.left, RayLenght, _layerMask.value);
		// evaluamos si toco por arriba
		if ( hitInfo.collider != null  ) {
			// verificamos si la colision fue realizada con el player
			if (hitInfo.collider.gameObject.CompareTag ("Player")) {
				Destroy (hitInfo.collider.gameObject);
			}
		}




	}
}
