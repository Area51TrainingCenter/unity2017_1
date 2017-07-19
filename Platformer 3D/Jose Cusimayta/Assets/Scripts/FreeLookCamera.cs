using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeLookCamera : MonoBehaviour {
	public Transform target;
	public Vector3 offset;
	public float distance=5;
	public float rotateSpeed = 5;
	public float angle=45;
	public float sensibilidad=5;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButton ("Crounch")) {
			offset.y = 3;
		} else {
			offset.y = 4;
		}
		float mouseX =  Input.GetAxis ("Mouse X");
		angle += mouseX;
		Quaternion newRotation = Quaternion.Euler (0, angle*sensibilidad, 0);
		Vector3 behind = newRotation * Vector3.back;

		transform.position = target.position + offset+behind*distance;
		transform.LookAt (target.position + offset);
	}
}
