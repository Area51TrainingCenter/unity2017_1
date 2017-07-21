using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeLookCamera : MonoBehaviour {
	public Transform target;
	public Vector3 offset;
	public float distance = 5;

	private float targetDistance;
	private float currentDistance;
	private float angleX = 0;
	private float angleY = 0;

	public float minYAngle = -26;
	public float maxYAngle = 70;
	public float sensitivity = 6;
	// Use this for initialization
	void Start () {
		targetDistance = distance;
		currentDistance = distance;
	}

	void FixedUpdate(){
		Vector3 targetPos = target.position + offset;
		RaycastHit hitInfo;
		bool isCameraBehindObstacle = false;
		//para calcular el vector entre dos puntos 
		//restas las coordenadas de ambos puntos 
		//tomando en cuenta que es:  destino-origen
		Vector3 direction = transform.position - targetPos;
		//hacemos un raycast desde la camara hacia el player
		if (Physics.Raycast (targetPos, direction, out hitInfo, direction.magnitude)) {
			Debug.DrawRay (targetPos, direction, Color.green);
			isCameraBehindObstacle = true;
		} else {
			Debug.DrawRay (targetPos, direction, Color.red);
		}


		if (isCameraBehindObstacle) {
			targetDistance -= Time.fixedDeltaTime*15;
		} else {
			if (!Physics.Raycast (targetPos, direction, out hitInfo, targetDistance+1)) {
				targetDistance += Time.fixedDeltaTime*15;
				if (targetDistance > distance) {
					targetDistance = distance;
				}
			}
		}

	}

	// Update is called once per frame
	void Update () {

		float mouseX = Input.GetAxis ("Mouse X");
		float mouseY = Input.GetAxis ("Mouse Y");
		angleX += mouseX * sensitivity;
		angleY += mouseY * sensitivity;

		if (angleY < minYAngle) {
			angleY = minYAngle;
		}
		if (angleY > maxYAngle) {
			angleY = maxYAngle;
		}

		//clamp restringe un valor entre un minimo y un maximo
	//	angleY = Mathf.Clamp (angleY, minYAngle, maxYAngle);

		//el Euler te permite crear un Quaternion en base a 
		//valores x,y,z
		Quaternion newRotation = Quaternion.Euler (angleY, angleX, 0);
		//cuando multiplicas una rotacion por un vector
		//lo que estas haciendo es rotar el vector en base a la
		//rotacion... y el vector resultante lo guardamos en
		//la variable behind
		Vector3 behind = newRotation * -Vector3.forward;
		currentDistance = Mathf.Lerp (currentDistance, targetDistance, Time.deltaTime * 12);
		transform.position = target.position+offset+(behind*currentDistance);

		transform.LookAt (target.position+offset);
	}
}
