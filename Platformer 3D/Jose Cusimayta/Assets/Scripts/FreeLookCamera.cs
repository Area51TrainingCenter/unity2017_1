using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeLookCamera : MonoBehaviour {
	public Transform target;
	public Vector3 offset;
	public float distance=5;
	private float currentDistance;
	private float targetDistance;
	public float rotateSpeed = 5;
	public float angleX=0;
	public float angleY=0;
	public float sensibilidad=5;
	public LayerMask _mask;
	private Vector3 currentVelocity;
	// Use this for initialization
	void Start () {
		targetDistance = distance;
	}
	
	// Update is called once per frame
	void Update () {
		/*if (Input.GetButton ("Crounch")) {
			offset.y = 3;
		} else {
			offset.y = 4;
		}*/
		float mouseX = Input.GetAxis ("Mouse X");
		float mouseY = Input.GetAxis ("Mouse Y");
		float mouseScroll = Input.GetAxis ("Mouse ScrollWheel");
		angleX += mouseX * sensibilidad;
		angleY -= mouseY * sensibilidad;
		currentDistance -= mouseScroll;
		//angleY = Mathf.Clamp (angleY, -2, 10);
		if (angleY < 2)
			angleY = 2;
		if (angleY > 10)
			angleY = 10;
		Quaternion newRotation = Quaternion.Euler (angleY, angleX, 0);
		Vector3 behind = newRotation * Vector3.back;
		currentDistance = Mathf.Lerp (currentDistance, targetDistance, Time.deltaTime*10);
		Vector3 finalPos= target.position + offset + behind * currentDistance;
		transform.position= Vector3.SmoothDamp (transform.position,finalPos, ref currentVelocity,0.1f);
		transform.LookAt (target.position + offset);
	}
	void FixedUpdate(){
		Vector3 targetPos = target.position + offset;
		RaycastHit hitInfo;
		bool isCameraBehindObstacle = false;
		Vector3 direction = transform.position - targetPos;
		if (Physics.Raycast (target.position, direction, out hitInfo, direction.magnitude)) {			
			Debug.DrawRay (target.position, direction, Color.green);
			isCameraBehindObstacle = true;
		} else {
			Debug.DrawRay (target.position, direction, Color.red);
		}
		if (isCameraBehindObstacle) {
			if(targetDistance>1.3f)
					targetDistance -= Time.fixedDeltaTime * 15;
		} else {
			if (!Physics.Raycast (target.position, direction, out hitInfo, targetDistance + 1) && targetDistance < distance) {
				targetDistance += Time.fixedDeltaTime * 15;
			}
		}

	}
}