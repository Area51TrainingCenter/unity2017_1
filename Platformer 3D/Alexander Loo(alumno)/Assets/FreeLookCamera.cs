using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeLookCamera : MonoBehaviour {

	public Transform target;
	//vector que mide la distancia entre la cámara y el objetivo
	public Vector3 offset;
	public float distance;
	public float angle;
	public float rotationSpeed;

	void Start(){

	}

	void Update(){

		float mouseX = Input.GetAxis ("Mouse X");
		Debug.Log (mouseX);
		angle += rotationSpeed * mouseX;
		//Euler te permite crear un Quaternion en base a los valores x,y,z
		Quaternion newRotation = Quaternion.Euler (0, angle, 0);
		/*Cuando multiplicas unas rotación por un vector lo que estas haciendo es rotar el vector en base
		 a la rotación...y el vector resultante lo guardamos en la variable behind*/
		Vector3 behind = newRotation * -Vector3.forward;
		transform.position = target.position + offset + (behind * distance);
		//para asegurarnos que siempre mire al objetivo
		transform.LookAt (target.position + offset);
	}
}
