using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetingSystem : MonoBehaviour {
	[Range(1f,10f)]
	public float _distance = 10;
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
		// devuelve un arreglo de todos los colliders que han chocado con la esfera
		Collider[] hits = Physics.OverlapSphere(transform.position, _distance);
		Transform newTarget = null;
		float minAngle = 999;

		for (int i = 0; i < hits.Length; i++) {
			if (hits[i].CompareTag("Enemy")) {
				
				// Debug.Log(hits[i].name);
				Vector3 dirToEnemy = hits[i].transform.position - transform.position;
				dirToEnemy.y = 0;
				float angle = Vector3.Angle(dirToEnemy, transform.forward);

				if (angle <= _angle) {
					if (angle <= minAngle) {
						minAngle = angle;
						newTarget = hits[i].transform;
					}
					newTarget = hits[i].transform;
				}
			}
		}

		_target = newTarget;
	}

	void OnDrawGizmos () {
		Gizmos.color = Color.yellow;
		Gizmos.DrawWireSphere(transform.position, _distance);

		Vector3 leftSideCone  = Quaternion.Euler(0,-_angle,0) * transform.forward ;
		Vector3 rightSideCone = Quaternion.Euler(0,_angle,0) * transform.forward ;

		Gizmos.color = Color.cyan;
		Gizmos.DrawRay(transform.position, leftSideCone * _distance);
		Gizmos.color = Color.cyan;
		Gizmos.DrawRay(transform.position, rightSideCone * _distance);
	}
}
