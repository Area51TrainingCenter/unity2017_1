using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class freelookcamera : MonoBehaviour {

	public Transform _target;
	public Vector3 _offset;
	private float x;
	private float y;
	private float targetdistance;
	private float currentdistance;
	public float _distance = 5;

	// Use this for initialization
	void Start () {


		targetdistance = _distance;
		currentdistance = _distance;
		
	}

	void FixedUpdate(){

		Vector3 targetpos =_target.position + _offset;
		RaycastHit hitinfo;
		bool isCameraBehindObstacle = false;
		Vector3 direction = transform.position - targetpos;
		if (Physics.Raycast (targetpos, direction, out hitinfo, direction.magnitude)) {
												
			Debug.DrawRay (targetpos, direction, Color.green);

		   isCameraBehindObstacle = true;		
		} 
		else 
		{
			Debug.DrawRay (targetpos, direction, Color.red);
		}

		if (isCameraBehindObstacle) {

			targetdistance -= Time.fixedDeltaTime*5;			
		} 
		else 
		{
			if (Physics.Raycast (targetpos, direction, out hitinfo,targetdistance+1)) {
				
				targetdistance += Time.fixedDeltaTime * 5;

				if (targetdistance >= _distance) {
					
					targetdistance = _distance;
				}
				
			}
		}				
	}
	
	// Update is called once per frame
	void Update () {

		float mouseX = Input.GetAxis("Mouse X");
		float mouseY = Input.GetAxis("Mouse Y");

		x += mouseX * 6;
		y += mouseY * 6;

		if (y >= 89) {
			y = 89;
			
		}
		if (y<= -20) {
			y = -20;
		}

		//y = Mathf.Clamp ();

		Quaternion newRotation = Quaternion.Euler (y,x,0);

		Vector3 behind = newRotation * -Vector3.forward;
		 
		transform.position = _target.position+_offset+(behind*currentdistance);

		transform.LookAt (_target.position + _offset);
		
	}
}
