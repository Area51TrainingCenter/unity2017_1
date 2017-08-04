using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamara : MonoBehaviour {
	public Transform target;
	public Vector3 offset;

	[Range(0.0f,10.0f)]
	public float Distance = 5;

	private float targetDistance;
	private float currentDistance;
	private float angleX = 0;
	private float angleY = 0;

	public float minYAngle = -26;
	public float maxYAngle = 70;
	public float sensitivity = 6;

	private Vector3 currentVelocity;

	//public float angle = 0;
	//public float SpeedMouse = 0;
	// Use this for initialization
	void Start () {
		targetDistance = Distance;
		currentDistance = Distance;
	}

	void FixedUpdate(){
		Vector3 targetPos = target.position + offset;
		RaycastHit hitInfo;
		bool isCameraBehindObstacle = false;
		Vector3 direction = transform.position - targetPos;
		if (Physics.Raycast (targetPos, direction, out hitInfo, direction.magnitude)) {
			Debug.DrawRay (targetPos, direction, Color.green);
			isCameraBehindObstacle = true;
		} else {
			Debug.DrawRay (targetPos, direction, Color.red);
		}

		if (isCameraBehindObstacle) {
			targetDistance -= Time.fixedDeltaTime * 15; 
		} else {
			if (!Physics.Raycast (targetPos, direction, out hitInfo, targetDistance+1)) {
				targetDistance += Time.fixedDeltaTime*15;
				if (targetDistance > Distance) {
					targetDistance = Distance;
				}
			}
		}
	}

	// Update is called once per frame
	void Update () {
		float mouseX = Input.GetAxis ("Mouse X" );
		float mouseY = Input.GetAxis ("Mouse Y" );
		angleX += mouseX * sensitivity;
		angleY += mouseY * sensitivity;

		//angle += mouseX * SpeedMouse;

		if (angleY < minYAngle) {
				angleY = minYAngle;
		}
		if (angleY > maxYAngle) {
				angleY = maxYAngle;
		}
		angleY = Mathf.Clamp (angleY, minYAngle, maxYAngle);
		Quaternion NewRotation = Quaternion.Euler(angleY, angleX ,0);
		Vector3 Behind = NewRotation * Vector3.forward;
		currentDistance = Mathf.Lerp (currentDistance, targetDistance, Time.deltaTime * 12);
		Vector3 finalPos = target.position+offset+(Behind*currentDistance);
		transform.position = Vector3.SmoothDamp (transform.position, finalPos, ref currentVelocity, 0.1f);
		transform.LookAt (target.position+offset);

		//transform.position = target.position + offset + (Behind * Distance);
		//transform.LookAt (target.position + offset);
	}
}
