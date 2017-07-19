using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeLookCamera : MonoBehaviour {
	public Transform target;
	public Vector3 Offset;
	public float distance= 5;
	public float angle1= 0;
	public float angle2= 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float mouseX = Input.GetAxis ("Mouse X");
		float mouseY = Input.GetAxis ("Mouse Y");
		if (mouseX>0) {
			angle1 =	angle1 + 5;
		}
		if (mouseX<0) {
			angle1 =	angle1 -5;
		}
		if (mouseY>0) {
			angle2 =	angle2 + 5;
		}
		if (mouseY<0) {
			angle2 =	angle2 -5;
		}

		Debug.Log (mouseY);
		Quaternion newRotation = Quaternion.Euler (angle2, angle1, 0);
		Vector3 behind = newRotation * new Vector3 (0, 0, -1);
		transform.position = target.position + Offset+ (behind* distance);
		transform.LookAt (target.position + Offset);
	
		
	}
}
