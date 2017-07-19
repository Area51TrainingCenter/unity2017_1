using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeLookCamera : MonoBehaviour {
	public Transform target;
	public Vector3 offset;
	public float distance;
	public float angle = 0;
	public float speedRotation = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float mouseX = Input.GetAxis("Mouse X");

		if ( mouseX != 0  ) {
			angle += mouseX * speedRotation;
		} 


		Quaternion newRotation = Quaternion.Euler(0, angle, 0);
		// cuando multiplicas una rotacion por un vector
		// lo que estas haciendo es rotar el vector en base a la
		// rotacion... y el vector resultante lo guardamos en
		// la variable behind
		Vector3 behind = newRotation * -Vector3.forward; // new Vector3(0,0,-1);
		// le asignamos la nueva posicion a la camara
		transform.position = target.position + offset + ( behind * distance );
		// hacemos que la camara mire al player
		transform.LookAt( target.position + offset );
	}
}
