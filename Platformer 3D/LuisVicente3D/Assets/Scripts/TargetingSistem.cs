using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetingSistem : MonoBehaviour {
	[Range(0f,10f)]
	public float distance;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate(){
		Collider[] hits = Physics.OverlapSphere (transform.position, distance);
		for (int i = 0; i < hits.Length; i++) {
			if (hits [i].CompareTag("Enemy")) {
				Debug.Log (hits [i].name);
			}
		}
	}

	void OnDrawGizmos(){
		Gizmos.color = Color.blue;
		Gizmos.DrawWireSphere (transform.position, distance);

		Vector3 leftSiceCone = Quaternion.Euler (0, -45, 0) * transform.forward;
		Vector3 rightSiceCone = Quaternion.Euler (0, 45, 0) * transform.forward;
		Gizmos.color = Color.red;
		Gizmos.DrawRay (transform.position, leftSiceCone * distance);
		Gizmos.DrawRay (transform.position, rightSiceCone * distance);
	}

}
