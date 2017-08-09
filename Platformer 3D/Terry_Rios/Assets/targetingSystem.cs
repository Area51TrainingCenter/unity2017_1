using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class targetingSystem : MonoBehaviour {

	[Range(1,20)]
	public float _distance;
	[Range(1,180)]
	public float _angle;
	public Transform _target;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {



	}

	void FixedUpdate () {

		Collider[] hits = Physics.OverlapSphere(transform.position, _distance);
		Transform newtarget = null;
		float minangle = 999;
		for (int i = 0; i < hits.Length; i++) {

			if (hits[i].CompareTag("Enemy")) {

				Debug.Log (hits [i].name);

				Vector3 dirtoenemy = hits [i].transform.position - transform.position;
				dirtoenemy.y = 0;
				float angle = Vector3.Angle (dirtoenemy, transform.forward);
				if (angle<=_angle) {

					if (angle < minangle) {

						minangle = angle;
						newtarget= hits [i].transform;
					}
				}				
			}
		}

		_target = newtarget;
		
	}

	void OnDrawGizmos(){
		
		Gizmos.color = Color.blue;
		Gizmos.DrawWireSphere (transform.position, _distance);

		Vector3 leftsidecone = Quaternion.Euler(0,-_angle,0)*transform.forward;
		Gizmos.DrawRay (transform.position, leftsidecone * _distance);
		Vector3 rightsidecone = Quaternion.Euler(0,_angle,0)*transform.forward;
		Gizmos.DrawRay (transform.position, rightsidecone * _distance);
	}
}
