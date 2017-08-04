using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetingSystem : MonoBehaviour {
	[Range(0,10)]
	public float _distance;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void FixedUpdate () {
		Collider[] hits = Physics.OverlapSphere (transform.position, _distance);
		for (int i = 0; i <hits.Length; i++) {
			if (hits[i].CompareTag("enemy")){
				hits [i].name;
			}
		}
	}
	void OnDrawGizmos() {
		Gizmos.color = Color.magenta;
		Gizmos.DrawWireSphere (transform.position, _distance);

		Vector3 leftSideCone = Quaternion.Euler (0, -45, 0) * transform.forward;
		Gizmos.DrawRay (transform.position, leftSideCone * 5);
		Vector3 rightSideCone = Quaternion.Euler (0, 45, 0) * transform.forward;
		Gizmos.DrawRay (transform.position, rightSideCone * 5);
	}
}
