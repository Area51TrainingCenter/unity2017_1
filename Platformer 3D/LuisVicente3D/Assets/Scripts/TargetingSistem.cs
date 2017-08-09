using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetingSistem : MonoBehaviour {
	[Range(0f,10f)]
	public float distance;
	[Range(0,180)]
	public float _angle = 45;

	public Transform _target;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate(){
		Collider[] hits = Physics.OverlapSphere (transform.position, distance);
		Transform newTarget = null;
		float minAngle = 999;
		for (int i = 0; i < hits.Length; i++) {
			if (hits [i].CompareTag("Enemy")) {
			//	Debug.Log (hits [i].name);
				Vector3 dirToEnemy = hits [i].transform.position - transform.position;
				dirToEnemy.y = 0;
				float angle = Vector3.Angle (dirToEnemy, transform.forward);
				if (angle <= _angle) {
					if (angle < minAngle) {
						minAngle = angle;
						newTarget = hits [i].transform;
					}
				}
			}
		}
		_target = newTarget;
	}

	void OnDrawGizmos(){
		Gizmos.color = Color.blue;
		Gizmos.DrawWireSphere (transform.position, distance);

		Vector3 leftSiceCone = Quaternion.Euler (0, - _angle, 0) * transform.forward;
		Vector3 rightSiceCone = Quaternion.Euler (0, _angle, 0) * transform.forward;
		Gizmos.color = Color.red;
		Gizmos.DrawRay (transform.position, leftSiceCone * distance);
		Gizmos.DrawRay (transform.position, rightSiceCone * distance);
	}

}
