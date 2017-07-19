using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamara : MonoBehaviour {
	public Transform target;
	public Vector3 offset;
	public float Distance = 5;
	public float angle = 0;
	public float SpeedMouse = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float mouseX = Input.GetAxis ("Mouse X" );

		angle += mouseX * SpeedMouse;
	
		Quaternion NewRotation = Quaternion.Euler(0, angle ,0);
		Vector3 Behind = NewRotation * -Vector3.forward;
		transform.position = target.position + offset + (Behind * Distance);
		transform.LookAt (target.position + offset);
	}
}
