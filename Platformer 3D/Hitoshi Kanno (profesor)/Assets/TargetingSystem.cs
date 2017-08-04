using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetingSystem : MonoBehaviour {
	[Range(1,20)]
	public float _distance = 10;
	[Range(0,180)]
	public float _angle = 45;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate(){
		Collider[] hits = Physics.OverlapSphere (transform.position, _distance);
		for (int i = 0; i < hits.Length; i++) {
			if (hits[i].CompareTag("enemy")) {
				Debug.Log (hits [i].name);
			}
		}
	}

	void OnDrawGizmos(){
		Gizmos.color = Color.blue;
		Gizmos.DrawWireSphere (transform.position, _distance);
	
		Vector3 leftSideCone = Quaternion.Euler (0, -_angle, 0) * transform.forward;
		Gizmos.DrawRay (transform.position, leftSideCone * _distance);

		Vector3 rightSideCone = Quaternion.Euler (0, _angle, 0) * transform.forward;
		Gizmos.DrawRay (transform.position, rightSideCone * _distance);
	}
}
