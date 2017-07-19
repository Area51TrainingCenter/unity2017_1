using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class freelookcamera : MonoBehaviour {

	public Transform _target;
	public Vector3 _offset;
	private float x;
	private float y;
	public float _distance = 5;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		float mouseX = Input.GetAxis("Mouse X");
		float mouseY = Input.GetAxis("Mouse Y");

		x += mouseX * 6;
		y += mouseY * 6;


		Debug.Log (mouseX);

		Quaternion newRotation = Quaternion.Euler (y,x,0);

		Vector3 behind = newRotation * -Vector3.forward;
		 
		transform.position = _target.position+_offset+(behind*_distance);

		transform.LookAt (_target.position + _offset);
		
	}
}
