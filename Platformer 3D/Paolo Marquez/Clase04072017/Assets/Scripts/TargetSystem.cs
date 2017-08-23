using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSystem : MonoBehaviour {
	
	public float distancia;
	public float _angle=45;
	public Transform _target;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate(){
		Collider[] hits= Physics.OverlapSphere (transform.position,distancia);
		Transform newTarget = null;
		float minAngle = 999;

		for(int i=0;i<hits.Length;i++){
			if(hits[i].CompareTag("Enemigo")){
				//Debug.Log(hits[i].name);
				Vector3 dirToEnemy = hits [i].transform.position - transform.position;
				dirToEnemy.y = 0;

				float angle = Vector3.Angle (dirToEnemy, transform.forward);

				if (angle<=_angle) {
					if (angle<minAngle) {
						minAngle = angle;
						newTarget = hits [i].transform;
					}
				}
			}
		}
		_target = newTarget;
	}

	void OnDrawGizmos(){
		Gizmos.color = Color.black;
		Gizmos.DrawWireSphere (transform.position,distancia);

		Vector3 leftSideCone = Quaternion.Euler (0, -45, 0) * transform.forward;
		Gizmos.DrawRay (transform.position,leftSideCone*distancia);

		Vector3 rightSideCone = Quaternion.Euler (0, 45, 0) * transform.forward;
		Gizmos.DrawRay (transform.position,rightSideCone*distancia);
	}
}
