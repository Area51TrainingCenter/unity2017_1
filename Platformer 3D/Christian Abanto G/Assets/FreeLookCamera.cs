using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeLookCamera : MonoBehaviour {
	public Transform target;
	public Vector3 offset;
	public float distance;

	private float targetDistance;
	private float currentDistance;
	private float angleX = 0;
	private float angleY = 0;
	public float minYAngle = -26;
	public float maxYAngle = 70;

	public float sensitivity = 6;

	public float angle = 0;
	public float speedRotation = 0;


	// Use this for initialization
	void Start () {
		currentDistance = distance;
	}

	void FixedUpdate(){
		Vector3 targetPos = target.position + offset;
		RaycastHit hitInfo; // variable a la cual llenaremos de info luego usando el Raycast
		bool isCameraBehindObstacule = false;
		// para calcular el vector endtre dos puntos
		// restas las coordenadas de ambos puntos
		// tomando en cuenta que es: destino-origen
		Vector3 direction = transform.position - targetPos;
		if (Physics.Raycast (targetPos, direction, out hitInfo, direction.magnitude)) {			
			Debug.DrawRay (targetPos, direction, Color.green);
			isCameraBehindObstacule = true;
		} else {
			Debug.DrawRay (targetPos, direction, Color.red);
			Debug.DrawRay (targetPos + new Vector3(0,1,0), direction, Color.yellow);
			Debug.DrawRay (targetPos + new Vector3(0,-1,0), direction, Color.blue);
		}


		if (isCameraBehindObstacule) {
			targetDistance -= Time.fixedDeltaTime * 20;
		} else {
			if (!Physics.Raycast (targetPos, direction, out hitInfo, targetDistance + 1)) {	
				targetDistance += Time.fixedDeltaTime * 20;
				if (targetDistance > distance) {
					targetDistance = distance;
				}
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		float mouseX = Input.GetAxis("Mouse X");
		float mouseY = Input.GetAxis("Mouse Y");

		angleX += mouseX * speedRotation;
		angleY += mouseY * speedRotation;

		if ( angleY < minYAngle) {
			angleY = minYAngle;
		}

		if ( angleY > maxYAngle) {
			angleY = maxYAngle;
		}
					

		Quaternion newRotation = Quaternion.Euler(angleY, angleX, 0);
		// cuando multiplicas una rotacion por un vector
		// lo que estas haciendo es rotar el vector en base a la
		// rotacion... y el vector resultante lo guardamos en
		// la variable behind
		Vector3 behind = newRotation * -Vector3.forward; // new Vector3(0,0,-1);
		// le asignamos la nueva posicion a la camara
		currentDistance = Mathf.Lerp(currentDistance, targetDistance, Time.deltaTime * 10);
		transform.position = target.position + offset + ( behind * currentDistance );
		// hacemos que la camara mire al player
		transform.LookAt( target.position + offset );
	}
}
