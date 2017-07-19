using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeLookCamera : MonoBehaviour {
	public Transform target;
	public Vector3 offset;
	public float distance = 5;
	private float angle = 0;
	public float sensitivity = 6;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		float mouseX = Input.GetAxis ("Mouse X");

		angle += mouseX * sensitivity;

		//el Euler te permite crear un Quaternion en base a 
		//valores x,y,z
		Quaternion newRotation = Quaternion.Euler (0, angle, 0);
		//cuando multiplicas una rotacion por un vector
		//lo que estas haciendo es rotar el vector en base a la
		//rotacion... y el vector resultante lo guardamos en
		//la variable behind
		Vector3 behind = newRotation * -Vector3.forward;
		transform.position = target.position+offset+(behind*distance);

		transform.LookAt (target.position+offset);
	}
}
