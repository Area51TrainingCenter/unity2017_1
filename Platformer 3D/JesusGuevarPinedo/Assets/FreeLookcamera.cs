using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeLookcamera : MonoBehaviour {
	public Transform target;
	public Vector3 offset;
	public float distance=5;

	public float angle = 0;

	public float sensitivity = 6f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float mouseX = Input.GetAxis ("Mouse X")*sensitivity;
		float mouseY = -Input.GetAxis ("Mouse Y")*sensitivity;
		angle += mouseX*6;

		//	

		Quaternion newRotation = Quaternion.Euler (0,angle,0);

		Vector3 behind = newRotation * -Vector3.forward;
		transform.position = target.position + offset+(behind*distance);
		transform.LookAt (target.position+ offset);
	}
}
