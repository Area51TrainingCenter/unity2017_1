using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeLookCamera : MonoBehaviour {

	public Transform target;
	public Vector3 CameraOffset;
	public Vector3 newCameraOffset;
	public Vector3 newCameraOffsetRotation;

	private float currentCameraDistance;
	private float targetDistance;

	[System.NonSerialized]
	public float angle = 0;
	[System.NonSerialized]
	public float angle2 = 0;
	public float angle2max = 50;
	public float angle2min = -10;

	public float distance = 5;

	// Use this for initialization
	void Start () {
		newCameraOffset = transform.position - target.position;
		newCameraOffset.z = 0;
		// newCameraOffsetRotation = transform.rotation - target.rotation;

		currentCameraDistance = distance;

	}

	void FixedUpdate() {
		Vector3 targetPos = target.position + newCameraOffset;
		RaycastHit miHitInfo;
		bool isCameraBehindObstacle = false;

		Vector3 direction =  transform.position - targetPos;

		if (Physics.Raycast (targetPos, direction, out miHitInfo, direction.magnitude)) {
			Debug.DrawRay (targetPos, direction, Color.green);
			isCameraBehindObstacle = true;
		} else {
			Debug.DrawRay (targetPos, direction, Color.red);
		}

		if (isCameraBehindObstacle) {
			targetDistance -= Time.fixedDeltaTime*20;
		} else {
			if (!(Physics.Raycast (targetPos, direction, out miHitInfo, direction.magnitude + (Time.fixedDeltaTime * 20) ))) {
				targetDistance += Time.fixedDeltaTime * 20;
				if (targetDistance > distance) {
					targetDistance = distance;
				}
			}
		}

	}

	// Update is called once per frame
	void Update () {

		float mouseX = Input.GetAxis ("Mouse X");
		angle += mouseX * 6;
		float mouseY = Input.GetAxis ("Mouse Y");
		angle2 += mouseY * 6;

		angle2 = Mathf.Clamp (angle2, angle2min, angle2max);

		Quaternion newRotation = Quaternion.Euler (angle2, angle, 0); 

		Vector3 behind = newRotation * -Vector3.forward;
		currentCameraDistance = Mathf.Lerp (currentCameraDistance, targetDistance, Time.deltaTime*10);
		transform.position = target.position + newCameraOffset + (behind*currentCameraDistance);

		transform.LookAt (target.position+newCameraOffset);
	}
}
