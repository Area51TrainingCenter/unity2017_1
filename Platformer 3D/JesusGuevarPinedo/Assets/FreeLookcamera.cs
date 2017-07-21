using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeLookcamera : MonoBehaviour {
	public Transform target;
	public Vector3 offset;
	public float distance=5;

	public float angle = 0; // Y
	public float angle2 = 0; //X

	public float sensitivity = 6f;

	public float minAngle = -7f;
	public float maxAngle = 45f;

	public float currentDistance;

	// Use this for initialization
	void Start () {
		currentDistance = distance;
		
	}

	void FixedUpdate(){
		
		Vector3 targetPos = target.position + offset;
		RaycastHit hitinfo;
		bool isCameraBenindObstacle = false;

		Vector3 direction = transform.position - targetPos;

		if (Physics.Raycast (targetPos, direction, out hitinfo, direction.magnitude)) {
			
			Debug.DrawRay (targetPos, direction, Color.green);
			isCameraBenindObstacle = true;

		} else {
			Debug.DrawRay (targetPos, direction, Color.red);
		}

		if (isCameraBenindObstacle) {
			
			currentDistance -= Time.fixedDeltaTime*10;
		} else {

			if (!Physics.Raycast (targetPos, direction, out hitinfo, currentDistance+1)) {
				currentDistance += Time.fixedDeltaTime*10;
				if(currentDistance > distance){
					currentDistance = distance;				
				}

			}

		}


	}

	// Update is called once per frame
	void Update () {

		float mouseX = Input.GetAxis ("Mouse X");
		float mouseY = -Input.GetAxis ("Mouse Y");

		angle += mouseX*6;
		angle2 += mouseY*6;

		if (angle2 < minAngle ) {
			angle2 = -minAngle ;	
		}		

		if (angle2 > maxAngle ) {
			angle2 = maxAngle ;	
		}

		//angleY = Mathf.Clamp (angle2, minAngle, maxAngle);

		Quaternion newRotation = Quaternion.Euler (angle2,angle,0);

		Vector3 behind = newRotation * -Vector3.forward;
		transform.position = target.position + offset+(behind*currentDistance);
		transform.LookAt (target.position+ offset);
	}
}
