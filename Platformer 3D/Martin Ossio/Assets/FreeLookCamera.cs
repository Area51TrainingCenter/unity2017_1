using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeLookCamera : MonoBehaviour {

	public Transform target;
	public Vector3 CameraOffset;
	public Vector3 newCameraOffset;
	public Vector3 newCameraOffsetRotation;
	public float angle = 0;
	public float angle2 = 0;

	public float distance = 5;

	// Use this for initialization
	void Start () {
		newCameraOffset = transform.position - target.position;
		newCameraOffset.z = 0;
		// newCameraOffsetRotation = transform.rotation - target.rotation;
	}
	
	// Update is called once per frame
	void Update () {

		float mouseX = Input.GetAxis ("Mouse X");
		angle += mouseX * 6;
		float mouseY = Input.GetAxis ("Mouse Y");
		angle2 += mouseY * 6;

		Quaternion newRotation = Quaternion.Euler (angle2, angle, 0); 

		Vector3 behind = newRotation * -Vector3.forward;

		transform.position = target.position + newCameraOffset + (behind*distance);

		transform.LookAt (target.position+newCameraOffset);
	}
}
