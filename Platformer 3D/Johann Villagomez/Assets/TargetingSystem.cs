using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetingSystem : MonoBehaviour {
	[Range(1,10)]
	public float _distance;
	[Range(0,100)]
	public float _angle;
	public Transform _target;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void FixedUpdate () {
		Collider[] hits = Physics.OverlapSphere (transform.position, _distance);
		Transform newTarget = null;
		float minAngle = 999;
		for (int i = 0; i <hits.Length; i++) {
			if (hits[i].CompareTag("enemy")){
				
				//calculas el vector desde el player hacia el enemigos y lo llamamos dirToenemy
				Vector3 dirToEnemy = hits [i].transform.position - transform.position;
				dirToEnemy.y = 0;
				//calculamos el angulo entre disToEnemy y el forward del player
				float angle = Vector3.Angle (dirToEnemy, transform.forward);

				if (angle <=_angle ) {
					if (angle < minAngle) {
						minAngle = angle;
						newTarget = hits [i].transform;
						Debug.Log (hits [i].name);
					}
				} 
			}
		}
		_target = newTarget;
	}
	void OnDrawGizmos() {
		Gizmos.color = Color.magenta;
		Gizmos.DrawWireSphere (transform.position, _distance);

		Vector3 leftSideCone = Quaternion.Euler (0, -_angle, 0) * transform.forward;
		Gizmos.DrawRay (transform.position, leftSideCone * 5);
		Vector3 rightSideCone = Quaternion.Euler (0, _angle, 0) * transform.forward;
		Gizmos.DrawRay (transform.position, rightSideCone * 5);
	}
}
