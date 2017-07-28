using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeLookCamera : MonoBehaviour {

	public Transform target;
	//vector que mide la distancia entre la cámara y el objetivo
	public Vector3 offset;
	public float distance;
	private float currentDistance;
	private float targetDistance;
	private float angleX, angleY;
	public float rotationSpeed;

	private Vector3 currentVelocity;

	void Start(){
		targetDistance = distance;
	}

	void Update(){

		float mouseX = Input.GetAxis ("Mouse X");
		float mouseY = Input.GetAxis ("Mouse Y");
		angleX += rotationSpeed * mouseX;
		angleY += rotationSpeed * mouseY;
		/*
		if (angleY > 70) {
			angleY = 70;
		}
		if (angleY < -50) {
			angleY = -50;
		}*/
		//Mathf.Clamp sirve para restringir límintes usando un mínimo y un máximo
		angleY = Mathf.Clamp (angleY, -50, 70);
		//Euler te permite crear un Quaternion en base a los valores x,y,z
		Quaternion newRotation = Quaternion.Euler (angleY, angleX, 0);
		/*Cuando multiplicas unas rotación por un vector lo que estas haciendo es rotar el vector en base
		 a la rotación...y el vector resultante lo guardamos en la variable behind*/
		Vector3 behind = newRotation * -Vector3.forward;
		currentDistance = Mathf.Lerp (currentDistance, targetDistance,Time.deltaTime * 10);
		Vector3 finalPos = target.position + offset + (behind * currentDistance);
		 //para suavizar el movimiento de la camara, al igual que lerp solo hace le calculo no lo ejecuta por eso lo almacenamos en una variable
		//en este caso lo guardamos en transform.position para que lo ejecute
		transform.position = Vector3.SmoothDamp (transform.position, finalPos, ref currentVelocity, 0.1f);
		//para asegurarnos que siempre mire al objetivo
		transform.LookAt (target.position + offset);
	}

	void FixedUpdate(){

		bool isCameraBehindObstacle = false;
		//posición del target, se suma offset para que no apunte a los pies(el origen de los modelos 3d);
		Vector3 targetPos = target.position + offset;
		RaycastHit hitInfo;
		//para calcular el vector entre dos puntos, tomando en cuenta que es destino - origen (dirección)
		Vector3 direction = transform.position - targetPos;
		//direction.magnitude obtiene la magnitud de un vector
		if (Physics.Raycast (targetPos, direction, out hitInfo, direction.magnitude)) {
			Debug.DrawRay (targetPos, direction, Color.green);
			isCameraBehindObstacle = true;
		} else {
			Debug.DrawRay (targetPos, direction, Color.red);
		}
		//si hay un obstaculo, la cámara se acerca
		if (isCameraBehindObstacle) {
			targetDistance -= Time.fixedDeltaTime * 5;
		} else {
			//creamos un raycast mas grande y sólo si no detectamos nada con este retrocedemos la cámara
			if(!Physics.Raycast (targetPos, direction, out hitInfo, targetDistance + 1)){
				targetDistance += Time.fixedDeltaTime * 5;
			//para que no se aleje hacia el infinito
			if (targetDistance >= distance) {
				targetDistance = distance;
				}
			}
		}
	}
}
